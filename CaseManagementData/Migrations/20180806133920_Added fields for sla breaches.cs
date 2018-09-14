using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagementData.Migrations
{
    public partial class Addedfieldsforslabreaches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Submissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SubmissionSlaBreach",
                table: "Submissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CaseSlaBreach",
                table: "Cases",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "SubmissionSlaBreach",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "CaseSlaBreach",
                table: "Cases");
        }
    }
}

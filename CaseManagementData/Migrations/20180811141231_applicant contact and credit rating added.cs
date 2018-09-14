using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagementData.Migrations
{
    public partial class applicantcontactandcreditratingadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cellphone",
                table: "Applicants",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Credit",
                table: "Applicants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Applicants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cellphone",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Credit",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Applicants");
        }
    }
}

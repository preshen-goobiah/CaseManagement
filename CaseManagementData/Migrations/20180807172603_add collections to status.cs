using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagementData.Migrations
{
    public partial class addcollectionstostatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Submissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_StatusId",
                table: "Submissions",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Statuses_StatusId",
                table: "Submissions",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Statuses_StatusId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_StatusId",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Submissions");
        }
    }
}

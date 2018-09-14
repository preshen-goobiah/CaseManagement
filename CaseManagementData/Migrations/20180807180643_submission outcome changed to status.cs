using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagementData.Migrations
{
    public partial class submissionoutcomechangedtostatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Outcomes_OutcomeId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_OutcomeId",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "OutcomeId",
                table: "Submissions");

            migrationBuilder.RenameColumn(
                name: "BankResponse",
                table: "Submissions",
                newName: "BankResponseDoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BankResponseDoc",
                table: "Submissions",
                newName: "BankResponse");

            migrationBuilder.AddColumn<int>(
                name: "OutcomeId",
                table: "Submissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_OutcomeId",
                table: "Submissions",
                column: "OutcomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Outcomes_OutcomeId",
                table: "Submissions",
                column: "OutcomeId",
                principalTable: "Outcomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

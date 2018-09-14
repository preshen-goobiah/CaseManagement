using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagementData.Migrations
{
    public partial class Addstatustolibraryassetfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "LibraryAssets",
                newName: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAssets_StatusId",
                table: "LibraryAssets",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryAssets_Statuses_StatusId",
                table: "LibraryAssets",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryAssets_Statuses_StatusId",
                table: "LibraryAssets");

            migrationBuilder.DropIndex(
                name: "IX_LibraryAssets_StatusId",
                table: "LibraryAssets");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "LibraryAssets",
                newName: "Status");
        }
    }
}

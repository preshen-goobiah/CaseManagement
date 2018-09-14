using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagementData.Migrations
{
    public partial class changedCheckoutattributecheckouttocheckedout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckOut",
                table: "CheckoutHistories",
                newName: "CheckedOut");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckedOut",
                table: "CheckoutHistories",
                newName: "CheckOut");
        }
    }
}

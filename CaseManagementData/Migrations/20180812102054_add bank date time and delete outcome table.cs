using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseManagementData.Migrations
{
    public partial class addbankdatetimeanddeleteoutcometable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Outcomes");

            migrationBuilder.DropColumn(
                name: "IsResubmit",
                table: "Submissions");

            migrationBuilder.AddColumn<DateTime>(
                name: "BankResponseDateTime",
                table: "Submissions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankResponseDateTime",
                table: "Submissions");

            migrationBuilder.AddColumn<bool>(
                name: "IsResubmit",
                table: "Submissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Outcomes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outcomes", x => x.Id);
                });
        }
    }
}

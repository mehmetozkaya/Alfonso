using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class SlugAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "Catalog",
                newName: "Summary");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Catalog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Star",
                table: "Catalog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "Star",
                table: "Catalog");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Catalog",
                newName: "Reason");
        }
    }
}

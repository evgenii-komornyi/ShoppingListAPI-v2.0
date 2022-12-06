using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListDAL.Migrations
{
    public partial class removeCategoryFromFileStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Files");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavListUserManagement.Infrastructure.Migrations
{
    public partial class CategoryColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Catergorys",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Catergorys");
        }
    }
}

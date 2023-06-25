using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavListUserManagement.Infrastructure.Migrations
{
    public partial class QuestionDraftChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "QuestionDrafts",
                newName: "Text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "QuestionDrafts",
                newName: "Name");
        }
    }
}

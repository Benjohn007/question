using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavListUserManagement.Infrastructure.Migrations
{
    public partial class QuestionDraft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionDrafts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Answer = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created_By_Id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modified_By = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Last_Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Is_Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Last_update_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Update_by_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionDrafts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionDrafts");
        }
    }
}

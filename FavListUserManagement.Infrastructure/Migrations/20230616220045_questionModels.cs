using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavListUserManagement.Infrastructure.Migrations
{
    public partial class questionModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Catergories",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Vote_Count = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Answers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data_To_Post = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SponsorId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Days_To_Remain_Open = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Min_Answer_Count = table.Column<int>(type: "int", nullable: false),
                    Max_Answer_Count = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MigratedToRedis = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CatergoryId = table.Column<string>(type: "varchar(255)", nullable: true)
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
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_Catergories_CatergoryId",
                        column: x => x.CatergoryId,
                        principalTable: "Catergories",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logo_S3_Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ads_S3_Url = table.Column<string>(type: "longtext", nullable: true)
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
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CatergoryId",
                table: "Questions",
                column: "CatergoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Catergories");
        }
    }
}

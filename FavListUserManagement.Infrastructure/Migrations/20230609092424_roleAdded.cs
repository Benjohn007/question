using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavListUserManagement.Infrastructure.Migrations
{
    public partial class roleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Roles_Roles_idId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleFeatures_Roles_Roles_IdId",
                table: "RoleFeatures");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_RoleFeatures_Roles_IdId",
                table: "RoleFeatures");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Roles_idId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Roles_IdId",
                table: "RoleFeatures");

            migrationBuilder.DropColumn(
                name: "Roles_idId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Modified_By",
                keyValue: null,
                column: "Modified_By",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_By",
                table: "RoleFeatures",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Created_By_Id",
                keyValue: null,
                column: "Created_By_Id",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Created_By_Id",
                table: "RoleFeatures",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "QuestionDefaultParameters",
                keyColumn: "Modified_By",
                keyValue: null,
                column: "Modified_By",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_By",
                table: "QuestionDefaultParameters",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "QuestionDefaultParameters",
                keyColumn: "Created_By_Id",
                keyValue: null,
                column: "Created_By_Id",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Created_By_Id",
                table: "QuestionDefaultParameters",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PortalFeatures",
                keyColumn: "Modified_By",
                keyValue: null,
                column: "Modified_By",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_By",
                table: "PortalFeatures",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PortalFeatures",
                keyColumn: "Created_By_Id",
                keyValue: null,
                column: "Created_By_Id",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Created_By_Id",
                table: "PortalFeatures",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "Modified_By",
                keyValue: null,
                column: "Modified_By",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_By",
                table: "Catergories",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "Created_By_Id",
                keyValue: null,
                column: "Created_By_Id",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Created_By_Id",
                table: "Catergories",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Modified_By",
                table: "RoleFeatures",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Created_By_Id",
                table: "RoleFeatures",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Roles_IdId",
                table: "RoleFeatures",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_By",
                table: "QuestionDefaultParameters",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Created_By_Id",
                table: "QuestionDefaultParameters",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_By",
                table: "PortalFeatures",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Created_By_Id",
                table: "PortalFeatures",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_By",
                table: "Catergories",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Created_By_Id",
                table: "Catergories",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Roles_idId",
                table: "AspNetUsers",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created_By_Id = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Is_Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Is_Admin = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Last_Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Last_update_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified_By = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Roles = table.Column<int>(type: "int", nullable: false),
                    Update_by_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFeatures_Roles_IdId",
                table: "RoleFeatures",
                column: "Roles_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Roles_idId",
                table: "AspNetUsers",
                column: "Roles_idId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Roles_Roles_idId",
                table: "AspNetUsers",
                column: "Roles_idId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleFeatures_Roles_Roles_IdId",
                table: "RoleFeatures",
                column: "Roles_IdId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}

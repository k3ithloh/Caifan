using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caifan.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegreeUser_Degrees_DegreesDegreeId",
                table: "DegreeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_DegreeUser_Users_UsersUserId",
                table: "DegreeUser");

            migrationBuilder.DropTable(
                name: "DegreeUsers");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "DegreeUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "DegreesDegreeId",
                table: "DegreeUser",
                newName: "DegreeId");

            migrationBuilder.RenameIndex(
                name: "IX_DegreeUser_UsersUserId",
                table: "DegreeUser",
                newName: "IX_DegreeUser_UserId");

            migrationBuilder.AddColumn<bool>(
                name: "Primary",
                table: "DegreeUser",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeUser_Degrees_DegreeId",
                table: "DegreeUser",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "DegreeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeUser_Users_UserId",
                table: "DegreeUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegreeUser_Degrees_DegreeId",
                table: "DegreeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_DegreeUser_Users_UserId",
                table: "DegreeUser");

            migrationBuilder.DropColumn(
                name: "Primary",
                table: "DegreeUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DegreeUser",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "DegreeId",
                table: "DegreeUser",
                newName: "DegreesDegreeId");

            migrationBuilder.RenameIndex(
                name: "IX_DegreeUser_UserId",
                table: "DegreeUser",
                newName: "IX_DegreeUser_UsersUserId");

            migrationBuilder.CreateTable(
                name: "DegreeUsers",
                columns: table => new
                {
                    DegreeId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Primary = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeUsers", x => new { x.DegreeId, x.UserId });
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeUser_Degrees_DegreesDegreeId",
                table: "DegreeUser",
                column: "DegreesDegreeId",
                principalTable: "Degrees",
                principalColumn: "DegreeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeUser_Users_UsersUserId",
                table: "DegreeUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

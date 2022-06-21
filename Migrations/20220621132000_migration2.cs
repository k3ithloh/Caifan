using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caifan.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Degrees_DegreeId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Degrees_SecondDegreeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DegreeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SecondDegreeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DegreeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecondDegreeId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "DegreeUser",
                columns: table => new
                {
                    DegreesDegreeId = table.Column<string>(type: "text", nullable: false),
                    UsersUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeUser", x => new { x.DegreesDegreeId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_DegreeUser_Degrees_DegreesDegreeId",
                        column: x => x.DegreesDegreeId,
                        principalTable: "Degrees",
                        principalColumn: "DegreeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DegreeUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DegreeUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    DegreeId = table.Column<int>(type: "integer", nullable: false),
                    Primary = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeUsers", x => new { x.DegreeId, x.UserId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_DegreeUser_UsersUserId",
                table: "DegreeUser",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DegreeUser");

            migrationBuilder.DropTable(
                name: "DegreeUsers");

            migrationBuilder.AddColumn<string>(
                name: "DegreeId",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondDegreeId",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DegreeId",
                table: "Users",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SecondDegreeId",
                table: "Users",
                column: "SecondDegreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Degrees_DegreeId",
                table: "Users",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "DegreeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Degrees_SecondDegreeId",
                table: "Users",
                column: "SecondDegreeId",
                principalTable: "Degrees",
                principalColumn: "DegreeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caifan.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Universities_UniversityName1",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UniversityName1",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "UniversityName1",
                table: "Reviews");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UniversityName",
                table: "Reviews",
                column: "UniversityName");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Universities_UniversityName",
                table: "Reviews",
                column: "UniversityName",
                principalTable: "Universities",
                principalColumn: "UniversityName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Universities_UniversityName",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UniversityName",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "UniversityName1",
                table: "Reviews",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UniversityName1",
                table: "Reviews",
                column: "UniversityName1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Universities_UniversityName1",
                table: "Reviews",
                column: "UniversityName1",
                principalTable: "Universities",
                principalColumn: "UniversityName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

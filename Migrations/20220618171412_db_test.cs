using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Caifan.Migrations
{
    public partial class db_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    BasketId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BasketName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.BasketId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "text", nullable: false),
                    CountryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    MobileNo = table.Column<int>(type: "integer", nullable: false),
                    PasswordEncrypt = table.Column<string>(type: "text", nullable: false),
                    DegreeId = table.Column<string>(type: "text", nullable: false),
                    SecondDegreeId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degrees",
                        principalColumn: "DegreeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Degrees_SecondDegreeId",
                        column: x => x.SecondDegreeId,
                        principalTable: "Degrees",
                        principalColumn: "DegreeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    UniversityName = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    WorldRanking = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    RegionId = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    AcademicCalendar = table.Column<string>(type: "text", nullable: false),
                    AcademicCalendarLink = table.Column<string>(type: "text", nullable: false),
                    GpaRequirement = table.Column<float>(type: "real", nullable: false),
                    NoOfPlacesSem1 = table.Column<int>(type: "integer", nullable: false),
                    NoOfPlacesSem2 = table.Column<int>(type: "integer", nullable: false),
                    IgpaTenPercentile = table.Column<float>(type: "real", nullable: false),
                    IgpaNinetyPercentile = table.Column<float>(type: "real", nullable: false),
                    Accommodation = table.Column<bool>(type: "boolean", nullable: false),
                    Insurance = table.Column<bool>(type: "boolean", nullable: false),
                    Visa = table.Column<bool>(type: "boolean", nullable: false),
                    HostUniversityWebsite = table.Column<string>(type: "text", nullable: false),
                    HostUniversityExchangeWebsite = table.Column<string>(type: "text", nullable: false),
                    CourseCatalogLink = table.Column<string>(type: "text", nullable: false),
                    CreditLoadMin = table.Column<int>(type: "integer", nullable: false),
                    CreditLoadMax = table.Column<int>(type: "integer", nullable: false),
                    CreditTransferRate = table.Column<int>(type: "integer", nullable: false),
                    ApplicationDeadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.UniversityName);
                    table.ForeignKey(
                        name: "FK_Universities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Universities_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DegreeUniversity",
                columns: table => new
                {
                    DegreesDegreeId = table.Column<string>(type: "text", nullable: false),
                    UniversitiesUniversityName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeUniversity", x => new { x.DegreesDegreeId, x.UniversitiesUniversityName });
                    table.ForeignKey(
                        name: "FK_DegreeUniversity_Degrees_DegreesDegreeId",
                        column: x => x.DegreesDegreeId,
                        principalTable: "Degrees",
                        principalColumn: "DegreeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DegreeUniversity_Universities_UniversitiesUniversityName",
                        column: x => x.UniversitiesUniversityName,
                        principalTable: "Universities",
                        principalColumn: "UniversityName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "integer", nullable: false),
                    UniversityName = table.Column<string>(type: "text", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    BasketId = table.Column<int>(type: "integer", nullable: false),
                    LinkToCourseOutline = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Faculty = table.Column<string>(type: "text", nullable: false),
                    Credits = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => new { x.ModuleId, x.UniversityName });
                    table.ForeignKey(
                        name: "FK_Modules_Universities_UniversityName",
                        column: x => x.UniversityName,
                        principalTable: "Universities",
                        principalColumn: "UniversityName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UniversityName = table.Column<string>(type: "text", nullable: false),
                    UniversityName1 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Universities_UniversityName1",
                        column: x => x.UniversityName1,
                        principalTable: "Universities",
                        principalColumn: "UniversityName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketModule",
                columns: table => new
                {
                    BasketsBasketId = table.Column<int>(type: "integer", nullable: false),
                    ModulesModuleId = table.Column<int>(type: "integer", nullable: false),
                    ModulesUniversityName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketModule", x => new { x.BasketsBasketId, x.ModulesModuleId, x.ModulesUniversityName });
                    table.ForeignKey(
                        name: "FK_BasketModule_Baskets_BasketsBasketId",
                        column: x => x.BasketsBasketId,
                        principalTable: "Baskets",
                        principalColumn: "BasketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketModule_Modules_ModulesModuleId_ModulesUniversityName",
                        columns: x => new { x.ModulesModuleId, x.ModulesUniversityName },
                        principalTable: "Modules",
                        principalColumns: new[] { "ModuleId", "UniversityName" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketModule_ModulesModuleId_ModulesUniversityName",
                table: "BasketModule",
                columns: new[] { "ModulesModuleId", "ModulesUniversityName" });

            migrationBuilder.CreateIndex(
                name: "IX_DegreeUniversity_UniversitiesUniversityName",
                table: "DegreeUniversity",
                column: "UniversitiesUniversityName");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_UniversityName",
                table: "Modules",
                column: "UniversityName");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UniversityName1",
                table: "Reviews",
                column: "UniversityName1");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_CountryId",
                table: "Universities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_RegionId",
                table: "Universities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DegreeId",
                table: "Users",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SecondDegreeId",
                table: "Users",
                column: "SecondDegreeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketModule");

            migrationBuilder.DropTable(
                name: "DegreeUniversity");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}

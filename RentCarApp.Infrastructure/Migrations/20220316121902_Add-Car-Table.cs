using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCarApp.Infrastructure.Migrations
{
    public partial class AddCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                schema: "lookups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelYear = table.Column<int>(type: "int", nullable: true),
                    ValueForDailyRent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrencyForDailyRent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueForWeeklyRent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrencyForWeeklyRent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarTypelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalSchema: "lookups",
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_CarTypes_CarTypelId",
                        column: x => x.CarTypelId,
                        principalSchema: "lookups",
                        principalTable: "CarTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarFeatures",
                schema: "lookups",
                columns: table => new
                {
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarFeatures", x => new { x.CarId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_CarFeatures_Cars_CarId",
                        column: x => x.CarId,
                        principalSchema: "lookups",
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                schema: "lookups",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarTypelId",
                schema: "lookups",
                table: "Cars",
                column: "CarTypelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarFeatures",
                schema: "lookups");

            migrationBuilder.DropTable(
                name: "Cars",
                schema: "lookups");
        }
    }
}

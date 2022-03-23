using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCarApp.Infrastructure.Migrations
{
    public partial class AddFieldCounterInCarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarCounter",
                schema: "lookups",
                table: "CarModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarCounter",
                schema: "lookups",
                table: "CarModels");
        }
    }
}

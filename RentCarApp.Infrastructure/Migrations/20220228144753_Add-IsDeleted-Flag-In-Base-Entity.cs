using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCarApp.Infrastructure.Migrations
{
    public partial class AddIsDeletedFlagInBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "lookups",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "lookups",
                table: "Cities");
        }
    }
}

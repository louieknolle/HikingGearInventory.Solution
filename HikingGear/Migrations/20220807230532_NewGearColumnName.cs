using Microsoft.EntityFrameworkCore.Migrations;

namespace HikingGear.Migrations
{
    public partial class NewGearColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Gears",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Gears",
                newName: "Model");
        }
    }
}

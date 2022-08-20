using Microsoft.EntityFrameworkCore.Migrations;

namespace HikingGear.Migrations
{
    public partial class AuthenticateOnMacDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Gears",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gears_UserId",
                table: "Gears",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gears_AspNetUsers_UserId",
                table: "Gears",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gears_AspNetUsers_UserId",
                table: "Gears");

            migrationBuilder.DropIndex(
                name: "IX_Gears_UserId",
                table: "Gears");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Gears");
        }
    }
}

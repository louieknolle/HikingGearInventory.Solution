using Microsoft.EntityFrameworkCore.Migrations;

namespace HikingGear.Migrations
{
    public partial class UserToJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CategoryGear",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGear_UserId",
                table: "CategoryGear",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGear_AspNetUsers_UserId",
                table: "CategoryGear",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGear_AspNetUsers_UserId",
                table: "CategoryGear");

            migrationBuilder.DropIndex(
                name: "IX_CategoryGear_UserId",
                table: "CategoryGear");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CategoryGear");
        }
    }
}

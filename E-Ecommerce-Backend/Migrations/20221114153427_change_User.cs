using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Ecommerce_Backend.Migrations
{
    public partial class change_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_User_UserId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_UserId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rating");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Rating",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_User_UserId",
                table: "Rating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}

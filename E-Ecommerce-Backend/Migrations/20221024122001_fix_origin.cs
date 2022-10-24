using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Ecommerce_Backend.Migrations
{
    public partial class fix_origin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_OriginId",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OriginId",
                table: "Product",
                column: "OriginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_OriginId",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OriginId",
                table: "Product",
                column: "OriginId",
                unique: true);
        }
    }
}

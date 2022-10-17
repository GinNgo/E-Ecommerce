using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Ecommerce_Backend.Migrations
{
    public partial class addproduct_and_updatecategory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_CategoryId1",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Category_CategoriesCategoryId",
                table: "CategoryProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Product_ProductsProductId",
                table: "CategoryProduct");

            migrationBuilder.DropIndex(
                name: "IX_Category_CategoryId1",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "ProductsProductId",
                table: "CategoryProduct",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "CategoriesCategoryId",
                table: "CategoryProduct",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryProduct_ProductsProductId",
                table: "CategoryProduct",
                newName: "IX_CategoryProduct_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Category_ProductId",
                table: "CategoryProduct",
                column: "ProductId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Product_CategoryId",
                table: "CategoryProduct",
                column: "CategoryId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Category_ProductId",
                table: "CategoryProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Product_CategoryId",
                table: "CategoryProduct");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CategoryProduct",
                newName: "ProductsProductId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoryProduct",
                newName: "CategoriesCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryProduct_ProductId",
                table: "CategoryProduct",
                newName: "IX_CategoryProduct_ProductsProductId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryId1",
                table: "Category",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_CategoryId1",
                table: "Category",
                column: "CategoryId1",
                principalTable: "Category",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Category_CategoriesCategoryId",
                table: "CategoryProduct",
                column: "CategoriesCategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Product_ProductsProductId",
                table: "CategoryProduct",
                column: "ProductsProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

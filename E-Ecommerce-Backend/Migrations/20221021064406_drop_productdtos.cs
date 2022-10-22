using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Ecommerce_Backend.Migrations
{
    public partial class drop_productdtos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("ProductsDto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

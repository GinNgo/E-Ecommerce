using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Ecommerce_Backend.Migrations
{
    public partial class c_Origin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Image",
                newName: "ImageId");

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Brand",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Brand",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Brand",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Brand",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Brand",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Brand",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Origin",
                columns: table => new
                {
                    OriginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origin", x => x.OriginId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_OriginId",
                table: "Product",
                column: "OriginId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Origin_OriginId",
                table: "Product",
                column: "OriginId",
                principalTable: "Origin",
                principalColumn: "OriginId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Origin_OriginId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Origin");

            migrationBuilder.DropIndex(
                name: "IX_Product_OriginId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Brand");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Image",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Product",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}

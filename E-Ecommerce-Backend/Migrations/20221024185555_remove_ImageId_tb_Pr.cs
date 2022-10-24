﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Ecommerce_Backend.Migrations
{
    public partial class remove_ImageId_tb_Pr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Product",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

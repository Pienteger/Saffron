using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Saffron.Migrations
{
    public partial class updatedmenumodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MenuItemId",
                table: "Menus",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuType",
                table: "Menus",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenuItemId",
                table: "Menus",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_MenuItemId",
                table: "Menus",
                column: "MenuItemId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_MenuItemId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_MenuItemId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MenuType",
                table: "Menus");
        }
    }
}

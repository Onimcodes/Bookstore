using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Micheal.Bookstore.Migrations
{
    public partial class added2columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createdOn",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedOn",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdOn",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "updatedOn",
                table: "Books");
        }
    }
}

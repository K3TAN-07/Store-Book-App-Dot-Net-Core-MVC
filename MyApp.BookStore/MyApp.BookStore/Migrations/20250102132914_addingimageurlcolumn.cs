﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApp.BookStore.Migrations
{
    public partial class addingimageurlcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "Books");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuanApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBlogId1Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogRelations_Blogs_BlogId1",
                table: "BlogRelations");

            migrationBuilder.DropIndex(
                name: "IX_BlogRelations_BlogId1",
                table: "BlogRelations");

            migrationBuilder.DropColumn(
                name: "BlogId1",
                table: "BlogRelations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BlogId1",
                table: "BlogRelations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogRelations_BlogId1",
                table: "BlogRelations",
                column: "BlogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogRelations_Blogs_BlogId1",
                table: "BlogRelations",
                column: "BlogId1",
                principalTable: "Blogs",
                principalColumn: "Id");
        }
    }
}

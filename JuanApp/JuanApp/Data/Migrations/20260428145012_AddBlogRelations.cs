using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuanApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelatedBlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogRelations_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogRelations_Blogs_BlogId1",
                        column: x => x.BlogId1,
                        principalTable: "Blogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogRelations_Blogs_RelatedBlogId",
                        column: x => x.RelatedBlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogRelations_BlogId",
                table: "BlogRelations",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogRelations_BlogId1",
                table: "BlogRelations",
                column: "BlogId1");

            migrationBuilder.CreateIndex(
                name: "IX_BlogRelations_RelatedBlogId",
                table: "BlogRelations",
                column: "RelatedBlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogRelations");
        }
    }
}

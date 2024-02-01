using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addOneTManyMigrationUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_Publisher_Id",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Publisher_Id",
                table: "Books",
                column: "Publisher_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_Publisher_Id",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Publisher_Id",
                table: "Books",
                column: "Publisher_Id",
                unique: true);
        }
    }
}

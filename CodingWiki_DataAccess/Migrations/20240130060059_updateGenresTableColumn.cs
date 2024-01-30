using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateGenresTableColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_generes",
                table: "tb_generes");

            migrationBuilder.RenameTable(
                name: "tb_generes",
                newName: "tb_genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_genres",
                table: "tb_genres",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_genres",
                table: "tb_genres");

            migrationBuilder.RenameTable(
                name: "tb_genres",
                newName: "tb_generes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_generes",
                table: "tb_generes",
                column: "GenreId");
        }
    }
}

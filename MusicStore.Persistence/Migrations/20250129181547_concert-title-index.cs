using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class concerttitleindex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concert_Genre_GenreId",
                table: "Concert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concert",
                table: "Concert");

            migrationBuilder.EnsureSchema(
                name: "Musicales");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres",
                newSchema: "Musicales");

            migrationBuilder.RenameTable(
                name: "Concert",
                newName: "Concerts",
                newSchema: "Musicales");

            migrationBuilder.RenameIndex(
                name: "IX_Concert_GenreId",
                schema: "Musicales",
                table: "Concerts",
                newName: "IX_Concerts_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                schema: "Musicales",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concerts",
                schema: "Musicales",
                table: "Concerts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_Title",
                schema: "Musicales",
                table: "Concerts",
                column: "Title");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Genres_GenreId",
                schema: "Musicales",
                table: "Concerts",
                column: "GenreId",
                principalSchema: "Musicales",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Genres_GenreId",
                schema: "Musicales",
                table: "Concerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                schema: "Musicales",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concerts",
                schema: "Musicales",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_Title",
                schema: "Musicales",
                table: "Concerts");

            migrationBuilder.RenameTable(
                name: "Genres",
                schema: "Musicales",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "Concerts",
                schema: "Musicales",
                newName: "Concert");

            migrationBuilder.RenameIndex(
                name: "IX_Concerts_GenreId",
                table: "Concert",
                newName: "IX_Concert_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concert",
                table: "Concert",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Concert_Genre_GenreId",
                table: "Concert",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

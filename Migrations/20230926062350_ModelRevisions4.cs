using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rest_husky.Migrations
{
    /// <inheritdoc />
    public partial class ModelRevisions4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Buzzes",
                newName: "BuzzId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BuzzId",
                table: "Buzzes",
                newName: "Id");
        }
    }
}

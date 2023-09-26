using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rest_husky.Migrations
{
    /// <inheritdoc />
    public partial class ModelRevisions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuzzId",
                table: "Comments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BuzzId",
                table: "Comments",
                column: "BuzzId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Buzzes_BuzzId",
                table: "Comments",
                column: "BuzzId",
                principalTable: "Buzzes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Buzzes_BuzzId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BuzzId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BuzzId",
                table: "Comments");
        }
    }
}

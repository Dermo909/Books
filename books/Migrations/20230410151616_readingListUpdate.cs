using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books.Migrations
{
    /// <inheritdoc />
    public partial class readingListUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_ReadingLists_ReadingListId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ReadingListId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReadingListId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReadingStatus",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "ReadingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ReadingLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ReadingStatus",
                table: "ReadingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReadingLists_BookId",
                table: "ReadingLists",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingLists_Books_BookId",
                table: "ReadingLists",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadingLists_Books_BookId",
                table: "ReadingLists");

            migrationBuilder.DropIndex(
                name: "IX_ReadingLists_BookId",
                table: "ReadingLists");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "ReadingLists");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ReadingLists");

            migrationBuilder.DropColumn(
                name: "ReadingStatus",
                table: "ReadingLists");

            migrationBuilder.AddColumn<int>(
                name: "ReadingListId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReadingStatus",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ReadingListId",
                table: "Books",
                column: "ReadingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ReadingLists_ReadingListId",
                table: "Books",
                column: "ReadingListId",
                principalTable: "ReadingLists",
                principalColumn: "Id");
        }
    }
}

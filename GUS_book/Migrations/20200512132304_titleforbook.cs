using Microsoft.EntityFrameworkCore.Migrations;

namespace GUS_book.Migrations
{
    public partial class titleforbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Books",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Анна Каренина");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Евгений Онегин");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Герои нашего времени");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Братья Карамазовы");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "Собачье сердце");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Books",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Анна Каренина");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Евгений Онегин");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Герои нашего времени");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Братья Карамазовы");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Собачье сердце");
        }
    }
}

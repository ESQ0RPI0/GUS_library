using Microsoft.EntityFrameworkCore.Migrations;

namespace GUS_book.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Author = table.Column<string>(maxLength: 20, nullable: true),
                    Year = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Name", "OwnerId", "Year" },
                values: new object[,]
                {
                    { 1, "Лев Толстой", "Анна Каренина", 0, 1873 },
                    { 2, "Александр Пушкин", "Евгений Онегин", 0, 1831 },
                    { 3, "Михаил Лермонтов", "Герои нашего времени", 0, 1839 },
                    { 4, "Фёдор Достоевский", "Братья Карамазовы", 0, 1880 },
                    { 5, "Михаил Булгаков", "Собачье сердце", 0, 1925 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[,]
                {
                    { 1, 23, "Петя" },
                    { 2, 26, "Иван" },
                    { 3, 28, "Коля" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

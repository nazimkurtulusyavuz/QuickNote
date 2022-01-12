using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickNote.Api.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NoteBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_NoteBooks_NoteBookId",
                        column: x => x.NoteBookId,
                        principalTable: "NoteBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NoteBooks",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "code" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "CreatedTime", "ModifiedTime", "NoteBookId", "Title" },
                values: new object[] { 1, "Console.WriteLine(\"Hello World!\");", new DateTimeOffset(new DateTime(2022, 1, 12, 11, 26, 48, 758, DateTimeKind.Unspecified).AddTicks(5286), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 1, 12, 11, 26, 48, 763, DateTimeKind.Unspecified).AddTicks(9550), new TimeSpan(0, 3, 0, 0, 0)), 1, "C#" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "CreatedTime", "ModifiedTime", "NoteBookId", "Title" },
                values: new object[] { 2, "console.Log('Hello World!');", new DateTimeOffset(new DateTime(2022, 1, 12, 11, 26, 48, 764, DateTimeKind.Unspecified).AddTicks(4978), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 1, 12, 11, 26, 48, 764, DateTimeKind.Unspecified).AddTicks(5094), new TimeSpan(0, 3, 0, 0, 0)), 1, "JavaScript" });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NoteBookId",
                table: "Notes",
                column: "NoteBookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "NoteBooks");
        }
    }
}

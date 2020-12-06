using Microsoft.EntityFrameworkCore.Migrations;

namespace NETD_Lab5.Migrations
{
    public partial class AddAll1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    authorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastName = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    yob = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.authorID);
                });

            migrationBuilder.CreateTable(
                name: "Dvds",
                columns: table => new
                {
                    dvdID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    director = table.Column<string>(nullable: true),
                    actor = table.Column<string>(nullable: true),
                    studio = table.Column<string>(nullable: true),
                    copies = table.Column<int>(nullable: false),
                    ASIN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dvds", x => x.dvdID);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    bookID = table.Column<int>(nullable: false),
                    authorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.bookID, x.authorID });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Authors_authorID",
                        column: x => x.authorID,
                        principalTable: "Authors",
                        principalColumn: "authorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Books_bookID",
                        column: x => x.bookID,
                        principalTable: "Books",
                        principalColumn: "bookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_authorID",
                table: "BookAuthor",
                column: "authorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "Dvds");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}

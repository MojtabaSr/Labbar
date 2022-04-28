using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class firstpush : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Intresse",
                columns: table => new
                {
                    IntresseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intresse", x => x.IntresseId);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinksId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinksId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Telefonnumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "IntresseLinks",
                columns: table => new
                {
                    IntresseLinksId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntresseId = table.Column<int>(nullable: false),
                    LinksId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntresseLinks", x => x.IntresseLinksId);
                    table.ForeignKey(
                        name: "FK_IntresseLinks_Intresse_IntresseId",
                        column: x => x.IntresseId,
                        principalTable: "Intresse",
                        principalColumn: "IntresseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntresseLinks_Links_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "LinksId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonIntresse",
                columns: table => new
                {
                    PersonIntresseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    IntresseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonIntresse", x => x.PersonIntresseId);
                    table.ForeignKey(
                        name: "FK_PersonIntresse_Intresse_IntresseId",
                        column: x => x.IntresseId,
                        principalTable: "Intresse",
                        principalColumn: "IntresseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonIntresse_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntresseLinks_IntresseId",
                table: "IntresseLinks",
                column: "IntresseId");

            migrationBuilder.CreateIndex(
                name: "IX_IntresseLinks_LinksId",
                table: "IntresseLinks",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonIntresse_IntresseId",
                table: "PersonIntresse",
                column: "IntresseId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonIntresse_PersonId",
                table: "PersonIntresse",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntresseLinks");

            migrationBuilder.DropTable(
                name: "PersonIntresse");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Intresse");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework.Migrations
{
    public partial class firstpush : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    PersonalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.PersonalId);
                });

            migrationBuilder.CreateTable(
                name: "Ledighet",
                columns: table => new
                {
                    LedighetsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDatum = table.Column<DateTime>(type: "date", nullable: false),
                    SlutDatum = table.Column<DateTime>(type: "date", nullable: false),
                    AppliedAtTime = table.Column<DateTime>(nullable: false),
                    LedighetsTyp = table.Column<string>(nullable: true),
                    PersonalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledighet", x => x.LedighetsId);
                    table.ForeignKey(
                        name: "FK_Ledighet_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ledighet_PersonalId",
                table: "Ledighet",
                column: "PersonalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ledighet");

            migrationBuilder.DropTable(
                name: "Personal");
        }
    }
}

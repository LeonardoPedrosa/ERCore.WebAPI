using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERCore.WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    DtBegin = table.Column<DateTime>(nullable: false),
                    DatEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HeroBattles",
                columns: table => new
                {
                    heroeId = table.Column<int>(nullable: false),
                    battleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroBattles", x => new { x.heroeId, x.battleId });
                    table.ForeignKey(
                        name: "FK_HeroBattles_Battles_battleId",
                        column: x => x.battleId,
                        principalTable: "Battles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroBattles_Heroes_heroeId",
                        column: x => x.heroeId,
                        principalTable: "Heroes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecretIdentities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    realName = table.Column<string>(nullable: true),
                    heroeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretIdentities", x => x.id);
                    table.ForeignKey(
                        name: "FK_SecretIdentities_Heroes_heroeId",
                        column: x => x.heroeId,
                        principalTable: "Heroes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    heroeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.id);
                    table.ForeignKey(
                        name: "FK_Weapons_Heroes_heroeId",
                        column: x => x.heroeId,
                        principalTable: "Heroes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroBattles_battleId",
                table: "HeroBattles",
                column: "battleId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentities_heroeId",
                table: "SecretIdentities",
                column: "heroeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_heroeId",
                table: "Weapons",
                column: "heroeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroBattles");

            migrationBuilder.DropTable(
                name: "SecretIdentities");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}

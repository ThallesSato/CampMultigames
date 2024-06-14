using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampMultigames.Infra.Migrations
{
    /// <inheritdoc />
    public partial class confrontosFfa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfrontosFfa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    P1TimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    P2TimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    P3TimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    P4TimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    JogoFfaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfrontosFfa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfrontosFfa_Jogos_JogoFfaId",
                        column: x => x.JogoFfaId,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfrontosFfa_JogoFfaId",
                table: "ConfrontosFfa",
                column: "JogoFfaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfrontosFfa");
        }
    }
}

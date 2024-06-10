using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampMultigames.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    pontosPorGame = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Confrontos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeCasaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeForaId = table.Column<int>(type: "INTEGER", nullable: false),
                    JogoTabelaId = table.Column<int>(type: "INTEGER", nullable: false),
                    PontosCasa = table.Column<int>(type: "INTEGER", nullable: false),
                    PontosFora = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confrontos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Confrontos_Jogos_JogoTabelaId",
                        column: x => x.JogoTabelaId,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confrontos_Times_TimeCasaId",
                        column: x => x.TimeCasaId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confrontos_Times_TimeForaId",
                        column: x => x.TimeForaId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TimeId = table.Column<int>(type: "INTEGER", nullable: true),
                    Foto = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TabelasGerais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Pontos = table.Column<int>(type: "INTEGER", nullable: false),
                    Jogos = table.Column<int>(type: "INTEGER", nullable: false),
                    Vitorias = table.Column<int>(type: "INTEGER", nullable: false),
                    Derrotas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelasGerais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelasGerais_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TabelasPorJogoTabela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    JogoTabelaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Pontos = table.Column<int>(type: "INTEGER", nullable: false),
                    Jogos = table.Column<int>(type: "INTEGER", nullable: false),
                    Vitorias = table.Column<int>(type: "INTEGER", nullable: false),
                    Derrotas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelasPorJogoTabela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelasPorJogoTabela_Jogos_JogoTabelaId",
                        column: x => x.JogoTabelaId,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TabelasPorJogoTabela_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mapas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConfrontoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PontosCasa = table.Column<int>(type: "INTEGER", nullable: false),
                    PontosFora = table.Column<int>(type: "INTEGER", nullable: false),
                    NomeMapa = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mapas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mapas_Confrontos_ConfrontoId",
                        column: x => x.ConfrontoId,
                        principalTable: "Confrontos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confrontos_JogoTabelaId",
                table: "Confrontos",
                column: "JogoTabelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Confrontos_TimeCasaId_TimeForaId_JogoTabelaId",
                table: "Confrontos",
                columns: new[] { "TimeCasaId", "TimeForaId", "JogoTabelaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Confrontos_TimeForaId",
                table: "Confrontos",
                column: "TimeForaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mapas_ConfrontoId",
                table: "Mapas",
                column: "ConfrontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TimeId",
                table: "Players",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelasGerais_TimeId",
                table: "TabelasGerais",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelasPorJogoTabela_JogoTabelaId",
                table: "TabelasPorJogoTabela",
                column: "JogoTabelaId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelasPorJogoTabela_TimeId",
                table: "TabelasPorJogoTabela",
                column: "TimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mapas");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "TabelasGerais");

            migrationBuilder.DropTable(
                name: "TabelasPorJogoTabela");

            migrationBuilder.DropTable(
                name: "Confrontos");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Times");
        }
    }
}

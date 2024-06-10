using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampMultigames.Infra.Migrations
{
    /// <inheritdoc />
    public partial class foto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "vitorias",
                table: "TabelasPorJogoTabela",
                newName: "Vitorias");

            migrationBuilder.RenameColumn(
                name: "pontos",
                table: "TabelasPorJogoTabela",
                newName: "Pontos");

            migrationBuilder.RenameColumn(
                name: "jogos",
                table: "TabelasPorJogoTabela",
                newName: "Jogos");

            migrationBuilder.RenameColumn(
                name: "derrotas",
                table: "TabelasPorJogoTabela",
                newName: "Derrotas");

            migrationBuilder.RenameColumn(
                name: "vitorias",
                table: "TabelasGerais",
                newName: "Vitorias");

            migrationBuilder.RenameColumn(
                name: "pontos",
                table: "TabelasGerais",
                newName: "Pontos");

            migrationBuilder.RenameColumn(
                name: "jogos",
                table: "TabelasGerais",
                newName: "Jogos");

            migrationBuilder.RenameColumn(
                name: "derrotas",
                table: "TabelasGerais",
                newName: "Derrotas");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Vitorias",
                table: "TabelasPorJogoTabela",
                newName: "vitorias");

            migrationBuilder.RenameColumn(
                name: "Pontos",
                table: "TabelasPorJogoTabela",
                newName: "pontos");

            migrationBuilder.RenameColumn(
                name: "Jogos",
                table: "TabelasPorJogoTabela",
                newName: "jogos");

            migrationBuilder.RenameColumn(
                name: "Derrotas",
                table: "TabelasPorJogoTabela",
                newName: "derrotas");

            migrationBuilder.RenameColumn(
                name: "Vitorias",
                table: "TabelasGerais",
                newName: "vitorias");

            migrationBuilder.RenameColumn(
                name: "Pontos",
                table: "TabelasGerais",
                newName: "pontos");

            migrationBuilder.RenameColumn(
                name: "Jogos",
                table: "TabelasGerais",
                newName: "jogos");

            migrationBuilder.RenameColumn(
                name: "Derrotas",
                table: "TabelasGerais",
                newName: "derrotas");
        }
    }
}

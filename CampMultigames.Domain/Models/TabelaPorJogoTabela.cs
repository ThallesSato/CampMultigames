namespace CampMultigames.Domain.Models;

public class TabelaPorJogoTabela : BaseEntity
{
    public required Time Time { get; set; }
    public required JogoTabela JogoTabela { get; set; }
    public int pontos { get; set; }
    public int jogos { get; set; }
    public int vitorias { get; set; }
    public int derrotas { get; set; }
}
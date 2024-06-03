namespace CampMultigames.Domain.Models;

public class TabelaGeral : BaseEntity
{
    public required Time Time { get; set; }
    public int pontos { get; set; }
    public int jogos { get; set; }
    public int vitorias { get; set; }
    public int empates { get; set; }
    public int derrotas { get; set; }
}
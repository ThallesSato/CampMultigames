namespace CampMultigames.Domain.Models;

public class TabelaPorJogoFfa : BaseEntity
{
    public required Time Time { get; set; }
    public required JogoFfa JogoFfa { get; set; }
    public int Pontos { get; set; }
    public int P1 { get; set; }
    public int P2 { get; set; }
    public int P3 { get; set; }
    public int P4 { get; set; }
}
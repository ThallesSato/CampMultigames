namespace CampMultigames.Domain.Models;

public class Confronto : BaseEntity
{
    public required Time TimeCasa { get; set; }
    public required Time TimeFora { get; set; }
    public required Jogo Jogo { get; set; }
    public int PontosCasa { get; set; }
    public int PontosFora { get; set; }
    public DateTime Data { get; set; }
}
namespace CampMultigames.Domain.Models;

public class TabelaGeral : BaseEntity
{
    public required Time Time { get; set; }
    public int pontos { get; set; }
}
namespace CampMultigames.Domain.Models;

public class Time : BaseEntity
{
    public required string Name { get; set; }
    public string Foto { get; set; } = "https://upload.wikimedia.org/wikipedia/pt/4/4b/Teamliquid_logo_blue.png";
    public List<Player> Players { get; set; } = new();
}
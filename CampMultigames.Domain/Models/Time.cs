namespace CampMultigames.Domain.Models;

public class Time : BaseEntity
{
    public required string Name { get; set; }
    public List<Player> Players { get; set; } = new();
}
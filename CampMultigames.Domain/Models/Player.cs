namespace CampMultigames.Domain.Models;

public class Player : BaseEntity
{
    public required string Name { get; set; }
    public required Time Time { get; set; }
}
using System.Text.Json.Serialization;

namespace CampMultigames.Domain.Models;

public class Player : BaseEntity
{
    public required string Name { get; set; }
    [JsonIgnore]
    public Time? Time { get; set; }

    public string Foto { get; set; } = "https://i.ibb.co/MSLYJHh/html-content-titled-hyperlink-title-profile-2.jpg";
}
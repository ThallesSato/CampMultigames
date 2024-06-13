using System.Text.Json.Serialization;

namespace CampMultigames.Domain.Models;

public class ConfrontoFfa : BaseEntity
{
    public int P1TimeId { get; set; }
    public int P2TimeId { get; set; }
    public int P3TimeId { get; set; }
    public int P4TimeId { get; set; }
    [JsonIgnore]
    public int JogoFfaId { get; set; }
    public virtual JogoFfa JogoFfa { get; set; }
    public DateTime? Data { get; set; }
}
using System.Text.Json.Serialization;

namespace CampMultigames.Domain.Models;

public class Mapa : BaseEntity
{
    public int ConfrontoId { get; set; }
    [JsonIgnore]
    public virtual Confronto? Confronto { get; set; }
    public int PontosCasa { get; set; }
    public int PontosFora { get; set; }
    public required string NomeMapa { get; set; }
}
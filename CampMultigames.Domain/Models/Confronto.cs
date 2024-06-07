using System.Text.Json.Serialization;

namespace CampMultigames.Domain.Models;

public class Confronto : BaseEntity
{
    [JsonIgnore]
    public int TimeCasaId { get; set; }
    [JsonIgnore]
    public int TimeForaId { get; set; }
    [JsonIgnore]
    public int JogoBaseId { get; set; }
    
    public virtual Time TimeCasa { get; set; }
    public virtual Time TimeFora { get; set; }
    public virtual JogoBase JogoBase { get; set; }
    
    public int PontosCasa { get; set; }
    public int PontosFora { get; set; }
    public DateTime? Data { get; set; }

}
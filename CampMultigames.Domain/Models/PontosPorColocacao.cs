using System.Text.Json.Serialization;

namespace CampMultigames.Domain.Models;

public class PontosPorColocacao : BaseEntity
{
    [JsonIgnore]
    public int JogoFfaId { get; set; }
    [JsonIgnore]
    public virtual JogoFfa JogoFfa { get; set; }
    
    public int Colocacao { get; set; }
    public int Ponto { get; set; }
}
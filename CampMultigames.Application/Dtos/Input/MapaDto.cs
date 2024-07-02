using System.ComponentModel.DataAnnotations;

namespace CampMultigames.Application.Dtos.Input;

public class MapaDto
{
    public int PontosCasa { get; set; }
    public int PontosFora { get; set; }
    [Required (ErrorMessage = "NomeMapa is required")]
    public required string NomeMapa { get; set; }
    public int? TimePickId { get; set; }
}
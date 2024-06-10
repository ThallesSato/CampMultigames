using System.ComponentModel.DataAnnotations;

namespace CampMultigames.Application.Dtos.Input;

public class ConfrontoDto
{
    public int PontosCasa { get; set; }
    public int PontosFora { get; set; }
    public DateTime Data { get; set; }
    [Required (ErrorMessage = "Mapa1 is required")]
    public required MapaDto Mapa1 { get; set; }
    [Required (ErrorMessage = "Mapa2 is required")]
    public required MapaDto? Mapa2 { get; set; }
    public MapaDto? Mapa3 { get; set; }
}
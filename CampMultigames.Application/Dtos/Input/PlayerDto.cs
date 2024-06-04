using System.ComponentModel.DataAnnotations;

namespace CampMultigames.Application.Dtos.Input;

public class PlayerDto
{
    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }
    
    [Required(ErrorMessage = "TimeId is required")]
    public required int TimeId { get; set; }
}
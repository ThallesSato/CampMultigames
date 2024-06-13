using System.ComponentModel.DataAnnotations;

namespace CampMultigames.Application.Dtos.Input;

public class TimeDto
{
    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }
    public string? Foto { get; set; }
}
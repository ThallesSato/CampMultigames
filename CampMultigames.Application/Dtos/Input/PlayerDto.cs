using System.ComponentModel.DataAnnotations;

namespace CampMultigames.Application.Dtos.Input;

public class PlayerDto
{
    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }
    [Required(ErrorMessage = "TimeId is required")]
    public required int TimeId { get; set; }
    public string Foto { get; set; } = "https://i.ibb.co/MSLYJHh/html-content-titled-hyperlink-title-profile-2.jpg";
}
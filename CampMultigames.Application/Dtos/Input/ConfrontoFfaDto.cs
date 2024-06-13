namespace CampMultigames.Application.Dtos.Input;

public class ConfrontoFfaDto
{
    public int JogoFfaId { get; set; }
    public DateTime? Data { get; set; }
    public int P1TimeId { get; set; }
    public int P2TimeId { get; set; }
    public int P3TimeId { get; set; }
    public int P4TimeId { get; set; }
}
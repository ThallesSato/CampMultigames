namespace CampMultigames.Application.Dtos.Input;

public class JogoFfaDto
{
    public required string Name { get; set; }
    public string Foto { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Valorant_logo_-_pink_color_version.svg/2560px-Valorant_logo_-_pink_color_version.svg.png";
    public string BgImage { get; set; } = "https://wallpapers.com/images/featured/valorant-305kescxw5dpup7y.jpg";
    public List<PontosPorColocacaoDto> PontosPorColocacao { get; set; } 
}
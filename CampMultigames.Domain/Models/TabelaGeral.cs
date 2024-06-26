﻿namespace CampMultigames.Domain.Models;

public class TabelaGeral : BaseEntity
{
    public required Time Time { get; set; }
    public int Pontos { get; set; }
    public int Jogos { get; set; }
    public int Vitorias { get; set; }
    public int Derrotas { get; set; }
}
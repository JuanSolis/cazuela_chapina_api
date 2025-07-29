using System;

namespace cazuela_chapina_core.Models.Results;

public class BebidasPorHorarioResult
{
    public string Horario { get; set; } = string.Empty;
    public string Bebida { get; set; } = string.Empty;
    public int TotalVendidos { get; set; }

}

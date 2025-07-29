using System;

namespace cazuela_chapina_core.Models.Dtos;

public class VentaComboDto
{
    public int VentaComboID { get; set; }

    public double Precio { get; set; }

    public int ComboID { get; set; }

    public int VentaID { get; set; }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace cazuela_chapina_core.Models.Dtos;

public class CrearSucursalDto
{
    [Required(ErrorMessage = "El nombre de la sucursal es obligatorio.")]
    public string Nombre { get; set; } = string.Empty;
    [Required(ErrorMessage = "La Direccion de la sucursal es obligatoria.")]
    public string Ubicacion { get; set; } = string.Empty;
}

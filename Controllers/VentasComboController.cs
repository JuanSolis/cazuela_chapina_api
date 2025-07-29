using cazuela_chapina_core.Models;
using cazuela_chapina_core.Models.Dtos;
using cazuela_chapina_core.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cazuela_chapina_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasComboController : ControllerBase
    {
        private readonly IVentaComboRepository _ventaComboRepository;
        public VentasComboController(IVentaComboRepository ventaComboRepository)
        {
            _ventaComboRepository = ventaComboRepository;
        }


        [HttpPost(Name = "CrearVentaCombo")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CrearUsuario([FromBody] CrearVentaComboDto crearVentaComboDto)
        {
            if (crearVentaComboDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nuevaVentaCombo = await _ventaComboRepository.CrearVentaCombo(crearVentaComboDto);
            if (nuevaVentaCombo == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la venta combo");
            }
            return Ok(nuevaVentaCombo);
        }
    }
}

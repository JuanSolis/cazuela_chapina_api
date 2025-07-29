using cazuela_chapina_core.Models;
using cazuela_chapina_core.Models.Dtos;
using cazuela_chapina_core.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cazuela_chapina_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentaRepository _ventaRepository;
        public VentasController(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        [HttpPost(Name = "CrearVenta")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CrearUsuario([FromBody] CrearVentaDto crearVentaDto)
        {
            if (crearVentaDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nuevaVenta = await _ventaRepository.CrearVenta(crearVentaDto);
            if (nuevaVenta == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la venta");
            }
            return Ok(nuevaVenta);
        }
    }
}

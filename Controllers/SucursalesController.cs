using AutoMapper;
using cazuela_chapina_core.Models.Dtos;
using cazuela_chapina_core.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cazuela_chapina_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SucursalesController : ControllerBase
    {
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IMapper _mapper;
        public SucursalesController(ISucursalRepository sucursalRepository, IMapper mapper)
        {
            _sucursalRepository = sucursalRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ObtenerSucursales()
        {
            var sucursales = _sucursalRepository.ObtenerSucursales();

            return Ok(sucursales);
        }

        [HttpGet("{id:int}", Name = "ObtenerSucursal")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ObtenerSucursal(int id)
        {
            var sucursal = _sucursalRepository.ObtenerSucursal(id);
            if (sucursal == null)
            {
                return NotFound("La sucursal no existe.");
            }
            return Ok(sucursal);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CrearCategoria([FromBody] CrearSucursalDto crearSucursalDto)
        {
            if (crearSucursalDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_sucursalRepository.ExisteSucursal(crearSucursalDto.Nombre))
            {
                ModelState.AddModelError("CustomError", "La sucursal ya existe.");
                return BadRequest(ModelState);
            }
            var sucursal = _mapper.Map<Sucursal>(crearSucursalDto);
            if (!_sucursalRepository.CrearSucursal(sucursal))
            {
                ModelState.AddModelError("CustomError", $"Error al crear la sucursal. {sucursal.Nombre}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return CreatedAtRoute("ObtenerSucursal", new { id = sucursal.SucursalID }, sucursal);
        }

    }
}

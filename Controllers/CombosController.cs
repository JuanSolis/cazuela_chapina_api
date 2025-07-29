using cazuela_chapina_core.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cazuela_chapina_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombosController : ControllerBase
    {

        private readonly IComboRepository _comboRepository;
        public CombosController(IComboRepository comboRepository)
        {
            _comboRepository = comboRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ObtenerCombos()
        {
            var sucursales = _comboRepository.ObtenerCombos();

            return Ok(sucursales);
        }

        [HttpGet("{id:int}", Name = "ObtenerCombo")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ObtenerCombo(int id)
        {
            var combo = _comboRepository.InformacionCombo(id);
            if (combo == null)
            {
                return NotFound("El combo no existe.");
            }
            return Ok(combo);
        }
    }
}

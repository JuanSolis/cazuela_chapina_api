using cazuela_chapina_core.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cazuela_chapina_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]


    public class DashboardController : ControllerBase
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        [HttpGet("VentasDiarias", Name = "VentasDiarias")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult VentasDiarias()
        {
            var ventasDiarias = _dashboardRepository.VentasDiarias();

            return Ok(ventasDiarias);
        }

        [HttpGet("VentasMensuales", Name = "VentasMensuales")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult VentasMensuales()
        {
            var ventasMensuales = _dashboardRepository.VentasMensuales();

            return Ok(ventasMensuales);
        }

        [HttpGet("ReportePorSucursal", Name = "ReportePorSucursal")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ReportePorSucursal()
        {
            var reportePorSucursal = _dashboardRepository.ReportePorSucural();

            return Ok(reportePorSucursal);
        }

        [HttpGet("TamalesMasVendidos", Name = "TamalesMasVendidos")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult TamalesMasVendidos()
        {
            var tamalesMasVendidos = _dashboardRepository.TamalesMasVendidos();

            return Ok(tamalesMasVendidos);
        }

        [HttpGet("BebidaPreferidaPorHorario", Name = "BebidaPreferidaPorHorario")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult BebidaPreferidaPorHorario()
        {
            var bebidasPorHorarioResults = _dashboardRepository.BebidaPreferidaPorHorario();

            return Ok(bebidasPorHorarioResults);
        }

        [HttpGet("ProporcionPicantes", Name = "ProporcionPicantes")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ProporcionPicantes()
        {
            var proporcionPicanteResults = _dashboardRepository.ProporcionPicantes();

            return Ok(proporcionPicanteResults);
        }

        [HttpGet("VentasPorCombo", Name = "VentasPorCombo")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult VentasPorCombo()
        {
            var ventasPorCombo = _dashboardRepository.VentasDeCombos();

            return Ok(ventasPorCombo);
        }

    }
}

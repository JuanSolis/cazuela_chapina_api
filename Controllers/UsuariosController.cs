using AutoMapper;
using cazuela_chapina_core.Models;
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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ObtenerUsuarios()
        {
            var usuarios = _usuarioRepository.ObtenerUsuarios();
            var usuariosDto = _mapper.Map<List<UsuarioDto>>(usuarios);

            return Ok(usuariosDto);
        }

        [HttpGet("{id:int}", Name = "ObtenerUsuario")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ObtenerUsuario(int id)
        {
            var usuario = _usuarioRepository.ObtenerUsuario(id);
            if (usuario == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            return Ok(usuarioDto);
        }
        [AllowAnonymous]
        [HttpPost(Name = "CrearUsuario")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CrearUsuario([FromBody] CrearUsuarioDto crearUsuarioDto)
        {
            if (crearUsuarioDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrWhiteSpace(crearUsuarioDto.NombreUsuario) || string.IsNullOrWhiteSpace(crearUsuarioDto.Password))
            {
                return BadRequest("El nombre de usuario y la contraseña son obligatorios.");
            }

            if (!_usuarioRepository.EsUsuarioUnico(crearUsuarioDto.NombreUsuario))
            {
                return BadRequest("El nombre de usuario ya existe.");
            }

            var nuevoUsuario = await _usuarioRepository.Crear(crearUsuarioDto);
            if (nuevoUsuario == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el usuario.");
            }

            return CreatedAtRoute("ObtenerUsuario", new { id = nuevoUsuario.UsuarioId }, nuevoUsuario);
        }

        [AllowAnonymous]
        [HttpPost("Login", Name = "LoginUsuario")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CrearUsuario([FromBody] LoginUsuarioDto loginUsuarioDto)
        {
            if (loginUsuarioDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var result = await _usuarioRepository.Login(loginUsuarioDto);
            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);


        }

    }
}

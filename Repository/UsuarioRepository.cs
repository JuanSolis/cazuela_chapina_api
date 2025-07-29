using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using cazuela_chapina_core.Models;
using cazuela_chapina_core.Models.Dtos;
using cazuela_chapina_core.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;

namespace cazuela_chapina_core.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _db;
    private readonly string? _secretKey;


    public UsuarioRepository(ApplicationDbContext db, IConfiguration configuration)
    {
        _db = db;
        _secretKey = configuration.GetValue<string>("ApiSettings:SecretKey");
    }

    public async Task<Usuario?> Crear(CrearUsuarioDto usuario)
    {
        var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
        var nuevoUsuario = new Usuario
        {
            NombreUsuario = usuario.NombreUsuario ?? "No especificado",
            Nombre = usuario.Nombre,
            Password = encryptedPassword,
            Role = usuario.Role,
        };

        _db.Usuarios.Add(nuevoUsuario);
        await _db.SaveChangesAsync();
        return nuevoUsuario;
    }

    public bool EsUsuarioUnico(string userName)
    {
        return !_db.Usuarios.Any(u => u.NombreUsuario.Trim().ToLower() == userName.Trim().ToLower());
    }

    public async Task<LoginUsuarioResponseDto?> Login(LoginUsuarioDto usuario)
    {
        if (string.IsNullOrEmpty(usuario.NombreUsuario) || string.IsNullOrEmpty(usuario.Password))
        {
            return new LoginUsuarioResponseDto()
            {
                Token = "",
                Usuario = null,
                Mensajes = "El nombre de usuario o la contraseña no pueden estar vacíos."
            };

        }
        var usuarioEntity = _db.Usuarios.FirstOrDefault(u => u.NombreUsuario.Trim().ToLower() == usuario.NombreUsuario.Trim().ToLower());

        if (usuarioEntity == null || !BCrypt.Net.BCrypt.Verify(usuario.Password, usuarioEntity.Password))
        {
            return new LoginUsuarioResponseDto()
            {
                Token = "",
                Usuario = null,
                Mensajes = "Nombre de usuario o contraseña incorrectos."
            };
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        if (string.IsNullOrWhiteSpace(_secretKey))
        {
            throw new InvalidOperationException("La clave secreta no está configurada");

        }
        var key = Encoding.UTF8.GetBytes(_secretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("UsuarioId", usuarioEntity.UsuarioId.ToString()),
                new Claim("NombreUsuario", usuarioEntity.NombreUsuario.ToString()),
                new Claim("Role", usuarioEntity.Role ?? String.Empty)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);


        return new LoginUsuarioResponseDto()
        {
            Token = tokenHandler.WriteToken(token),
            Usuario = new RegistroUsuarioDto
            {
                NombreUsuario = usuarioEntity.NombreUsuario,
                Nombre = usuarioEntity.Nombre,
                Role = usuarioEntity.Role,
                Password = usuarioEntity.Password ?? ""
            },
            Mensajes = "Inicio de sesión exitoso."
        };
    }

    public Usuario? ObtenerUsuario(int id)
    {
        return _db.Usuarios.FirstOrDefault(usuario => usuario.UsuarioId == id);
    }

    public ICollection<Usuario> ObtenerUsuarios()
    {
        return _db.Usuarios.OrderBy(u => u.NombreUsuario).ToList();

    }
}

using System;
using cazuela_chapina_core.Models;
using cazuela_chapina_core.Models.Dtos;

namespace cazuela_chapina_core.Repository.IRepository;

public interface IUsuarioRepository
{
    ICollection<Usuario> ObtenerUsuarios();
    Usuario? ObtenerUsuario(int id);
    bool EsUsuarioUnico(string userName);

    Task<LoginUsuarioResponseDto?> Login(LoginUsuarioDto usuario);
    Task<Usuario?> Crear(CrearUsuarioDto usuario);

}

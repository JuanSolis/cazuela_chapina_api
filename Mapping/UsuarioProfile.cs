using System;
using AutoMapper;
using cazuela_chapina_core.Models;
using cazuela_chapina_core.Models.Dtos;

namespace cazuela_chapina_core.Mapping;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<Usuario, UsuarioDto>().ReverseMap();
        CreateMap<Usuario, CrearUsuarioDto>().ReverseMap();
        CreateMap<Usuario, LoginUsuarioDto>().ReverseMap();
        CreateMap<Usuario, LoginUsuarioResponseDto>().ReverseMap();


    }
}

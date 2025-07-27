using System;
using AutoMapper;
using cazuela_chapina_core.Models.Dtos;

namespace cazuela_chapina_core.Mapping;

public class SucursalProfile : Profile
{
    public SucursalProfile()
    {
        CreateMap<Sucursal, SucursalDto>().ReverseMap();
        CreateMap<Sucursal, CrearSucursalDto>().ReverseMap();

    }
}

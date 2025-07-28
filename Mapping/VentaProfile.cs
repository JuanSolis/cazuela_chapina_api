using System;
using AutoMapper;
using cazuela_chapina_core.Models;
using cazuela_chapina_core.Models.Dtos;

namespace cazuela_chapina_core.Mapping;

public class VentaProfile : Profile
{
    public VentaProfile()
    {
        CreateMap<Venta, VentaDto>().ReverseMap();
        CreateMap<Venta, CrearVentaDto>().ReverseMap();
    }

}

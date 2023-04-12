using AutoMapper;
using BackEndApiSimple.DTOs;
using BackEndApiSimple.Models;

namespace BackEndApiSimple.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}

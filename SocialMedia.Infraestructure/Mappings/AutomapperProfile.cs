using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Publicacion, PublicacionDTO>().ReverseMap();
            CreateMap<Security, SecurityDTO>().ReverseMap();
        }
    }
}

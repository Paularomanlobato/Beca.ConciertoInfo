using AutoMapper;

namespace Beca.ConciertoInfo.API.Profiles
{
    public class CancionProfile : Profile
    {
        public CancionProfile()
        {
            CreateMap<Entities.Cancion, Models.CancionDto>();
            CreateMap<Models.CancionForCreationDto, Entities.Cancion>();
            CreateMap<Models.CancionForUpdateDto, Entities.Cancion>();
            CreateMap<Entities.Cancion, Models.CancionForUpdateDto>();
        }
    }
}

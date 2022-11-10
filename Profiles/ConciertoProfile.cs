using AutoMapper;

namespace Beca.ConciertoInfo.API.Profiles
{
    public class ConciertoProfile : Profile
    {
        public ConciertoProfile()
        {
            CreateMap<Entities.Concierto, Models.ConciertoWithoutCancionesDto>();
            CreateMap<Entities.Concierto, Models.ConciertoDto>();
            CreateMap<Models.ConciertoForCreationDto, Entities.Concierto>();
            CreateMap<Models.ConciertoForUpdateDto, Entities.Concierto>();
            CreateMap<Entities.Concierto, Models.ConciertoForUpdateDto>();
        }
    }
}

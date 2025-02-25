using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Entities.Info;

namespace MusicStore.Services.Profile
{
    public class ConcertProfile : AutoMapper.Profile
    {
        public ConcertProfile() 
        {
            CreateMap<ConcertInfo, ConcertResponseDto>();
            CreateMap<Concert, ConcertResponseDto>();
        }

    }
}

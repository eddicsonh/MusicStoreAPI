using MusicStore.Dto;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;

namespace MusicStore.Services.Interface
{
    public interface IConcertService
    {
        Task<BaseResponseGenerics<ICollection<ConcertResponseDto>>> GetAsync(string? title);
        Task<BaseResponseGenerics<ConcertResponseDto>> GetAsync(int id);
        Task<BaseResponseGenerics<int>> AddAsync(ConcertRequestDto request);
        Task<BaseResponse> UpdateAsync(int id, ConcertRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> FinalizeAsync(int id);
    }
}

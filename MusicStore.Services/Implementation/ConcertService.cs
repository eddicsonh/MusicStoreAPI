using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicStore.Dto;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Entities.Info;
using MusicStore.Repositories;
using MusicStore.Services.Interface;
using System.Reflection.Metadata.Ecma335;

namespace MusicStore.Services.Implementation
{
    public class ConcertService : IConcertService
    {
        private readonly IConcertRepository repository;
        private readonly ILogger<ConcertService> logger;
        private readonly IMapper mapper;

        public ConcertService(IConcertRepository repository, ILogger<ConcertService> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<BaseResponseGenerics<ICollection<ConcertResponseDto>>> GetAsync(string? title)
        {
            var response = new BaseResponseGenerics<ICollection<ConcertResponseDto>>();
            try
            {
                var data = await repository.GetAsync(title);
                response.Data = mapper.Map<ICollection<ConcertResponseDto>>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al obtener los datos.";
                response.Success = false;
                logger.LogError(ex, "{ErrorMessage} {Message} ", response.ErrorMessage, ex.Message);
            }
            return response; 
        }
        public async Task<BaseResponseGenerics<ConcertResponseDto>> GetAsync(int id)
        {
            var response = new BaseResponseGenerics<ConcertResponseDto>();
            try
            {
                var data = await repository.GetAsync(id);
                response.Data = mapper.Map<ConcertResponseDto>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al obtener los datos.";
                response.Success = false;
                logger.LogError(ex, "{ErrorMessage} {Message} ", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponseGenerics<int>> AddAsync(ConcertRequestDto request)
        {
            var response = new BaseResponseGenerics<int>();
            try
            {
                response.Data = await repository.AddAsync(mapper.Map<Concert>(request));
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al insertar la información.";
                response.Success = false;
                logger.LogError(ex, "{ErrorMessage} {Message} ", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponse> UpdateAsync(int id, ConcertRequestDto request)
        {
            var response = new BaseResponse();
            try
            {
                var data = await repository.GetAsync(id);
                if (data is null)
                {
                    response.ErrorMessage = "El registro no fue encontrado";
                    return response;
                }
                mapper.Map(request, data);
                await repository.UpdateAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al actualizar la información.";
                response.Success = false;
                logger.LogError(ex, "{ErrorMessage} {Message} ", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();
            try
            {
                await repository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex )
            {
                response.ErrorMessage = "Ocurrio un error al eliminar.";
                response.Success = false;
                logger.LogError(ex, "{ErrorMessage} {Message} ", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponse> FinalizeAsync(int id)
        {
            var response = new BaseResponse();
            try
            {
                await repository.FinalizeAsync(id);
                response.Success= true;
            }
            catch (Exception ex )
            {
                response.ErrorMessage = "Ocurrio un error al finalizar el evento.";
                response.Success = false;
                logger.LogError(ex, "{ErrorMessage} {Message} ", response.ErrorMessage, ex.Message);
            }
            return response;
        }






    }
}

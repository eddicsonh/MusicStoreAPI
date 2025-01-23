using Microsoft.AspNetCore.Mvc;
using MusicStore.Dto;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Repositories;
using System.Net;

namespace MusicStore.Api.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository repository;
        private readonly ILogger<GenreController> logger;

        public GenreController(IGenreRepository genreRepository, ILogger<GenreController> logger)
        {
            this.repository = genreRepository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = new BaseResponseGenerics<ICollection<GenreResponseDto>>();
            try
            {
                response.Data = await repository.GetAsync();
                response.Success = true;
                logger.LogInformation($"Se obtuvieron todos los generos musicales.");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al obtener la información.";
                logger.LogError(ex, response.ErrorMessage, $"{ex.Message}");
                return BadRequest(response);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = new BaseResponseGenerics<GenreResponseDto>();
            try
            {
                response.Data = await repository.GetAsync(id);
                response.Success = true;
                if (response.Data is null)
                {
                    logger.LogWarning($"Genero musical con id {id} no se encontro.");
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Ocurrio un error al obtener la información.";
                logger.LogError(ex, response.ErrorMessage, $"{ex.Message}");
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(GenreRequestDto genreRequestDto)
        {
            var response = new BaseResponseGenerics<int>();
            try
            {
                var genreId = await repository.AddAsync(genreRequestDto);
                response.Data = genreId;
                response.Success = true;
                logger.LogInformation($"Genero musical con id {genreId} insertado.");
                return StatusCode((int)HttpStatusCode.Created, response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Ocurrio un error al guardar la información.";
                logger.LogError(ex, $"{response.ErrorMessage}", $"{ex.Message}");
                return BadRequest(response);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, GenreRequestDto genreRequestDto)
        {
            var response = new BaseResponse();
            try
            {
                await repository.UpdateAsync(id, genreRequestDto);
                response.Success = true;
                logger.LogInformation($"Genero musical con id {id} actualizado.");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Ocurrio un error al guardar la información.";
                logger.LogError(ex, $"{response.ErrorMessage}", $"{ex.Message}");
                return BadRequest(response);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new BaseResponse();
            try
            {
                await repository.DeleteAsync(id);
                response.Success = true;
                logger.LogInformation($"Genero musical con id {id} eliminado.");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Ocurrio un error al borrar la información.";
                logger.LogError(ex, $"{response.ErrorMessage}", $"{ex.Message}");
                return BadRequest(response);
            }
        }
    }
}

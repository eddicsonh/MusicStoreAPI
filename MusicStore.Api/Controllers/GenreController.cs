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
                var genresDb = await repository.GetAsync();
                var genresResponseDto = genresDb.Select(x => new GenreResponseDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
                response.Data = genresResponseDto;
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
                var genresDb = await repository.GetAsync(id);

                if (genresDb is null)
                {
                    logger.LogWarning($"Genero musical con id {id} no se encontro.");
                    return NotFound(response);
                }
                else
                {
                    var genresResponseDto = new GenreResponseDto
                    {
                        Id = genresDb.Id,
                        Name = genresDb.Name,
                        Status = genresDb.Status,
                    };
                    response.Data = genresResponseDto;
                    response.Success = true;
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
                var genresDb = new Genre()
                {
                    Name = genreRequestDto.Name,
                    Status = genreRequestDto.Status
                };
                var genreId = await repository.AddAsync(genresDb);
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
                var genresDb = await repository.GetAsync(id);
                if (genresDb is null)
                {
                    response.ErrorMessage = $"Genero musical con id {id} no se encontro.";
                    return NotFound(response);
                }

                genresDb.Name = genreRequestDto.Name;
                genresDb.Status = genreRequestDto.Status;

                await repository.UpdateAsync();
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
                var genresDb = await repository.GetAsync(id);
                if (genresDb is null)
                {
                    response.ErrorMessage = $"Genero musical con id {id} no se encontro.";
                    return NotFound(response);
                }

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

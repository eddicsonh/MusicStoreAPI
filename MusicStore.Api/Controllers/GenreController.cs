using Microsoft.AspNetCore.Mvc;
using MusicStore.Dto;
using MusicStore.Entities;
using MusicStore.Repositories;
using System.Net;
using System.Reflection.Metadata.Ecma335;

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
            var response = new BaseResponseGenerics<ICollection<Genre>>();
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
            var response = new BaseResponseGenerics<Genre>();
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
        public async Task<IActionResult> Post(Genre genre)
        {
            var response = new BaseResponseGenerics<int>();
            try
            {
                await repository.AddAsync(genre);
                response.Data = genre.Id;
                response.Success = true;
                logger.LogInformation($"Genero musical con id {genre.Id} insertado.");
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
        public async Task<IActionResult> Put(int id, Genre genre)
        {
            var response = new BaseResponse();
            try
            {
                var item = await repository.GetAsync(id);
                if (item is null)
                {
                    logger.LogWarning($"Genero musical con id {id} no se encontro.");
                    return NotFound(response);
                }

                await repository.UpdateAsync(id, genre);
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
                var item = await repository.GetAsync(id);
                if (item is null)
                {
                    logger.LogWarning($"Genero musical con id {id} no se encontro.");
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

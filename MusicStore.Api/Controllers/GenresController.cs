using Microsoft.AspNetCore.Mvc;
using MusicStore.Entities;
using MusicStore.Repository;
using MusicStore.Dto;
using System.Net;
using Azure;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;

namespace MusicStore.Api.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository repository;
        private readonly ILogger<GenresController> logger;

        public GenresController(IGenreRepository genreRepository, ILogger<GenresController> logger)
        {
            this.repository = genreRepository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Por que se instancia y no se injecta?
            //R: Por investigar
            var response = new BaseResponseGeneric<ICollection<GenreResponseDto>>();
            try
            {
                response.Data = await this.repository.GetAsync();
                response.Success = true;
                logger.LogInformation($"Obteniendo todos los generos musicales.");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"Ocurrio un error al obtener la información.";
                logger.LogError($"{response.ErrorMessage}: {ex.Message}");
                return BadRequest(response);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = new BaseResponseGeneric<GenreResponseDto>();
            try
            {
                response.Data = await this.repository.GetAsync(id);
                response.Success = true;
                if (response.Data is null)
                {
                    logger.LogWarning($"No se encontro genero musical con el id: {id}");
                    return NotFound(response);
                }
                    
                logger.LogInformation($"Obteniendo el genero musicale por id: {id}.");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"Ocurrio un error al obtener la información.";
                logger.LogError($"{response.ErrorMessage}: {ex.Message}");
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(GenreRequestDto genreRequestDto)
        {
            var response = new BaseResponseGeneric<int>();
            try
            {
                var genreId = await this.repository.AddAsync(genreRequestDto);
                response.Data = genreId;
                response.Success = true;
                logger.LogInformation($"genero musical con id: {genreId} insertado");
                return StatusCode((int)HttpStatusCode.Created, response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"Ocurrio un error al obtener la información.";
                logger.LogError($"{response.ErrorMessage}: {ex.Message}");
                return BadRequest(response);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, GenreRequestDto genreRequestDto)
        {
            var response = new BaseResponse();
            try
            {
                var item = await this.repository.GetAsync(id);
                if (item is null)
                {
                    logger.LogWarning($"No se encontro registro con el id: {id}");
                    return NotFound(response);
                }

                await this.repository.UpdateAsync(id, genreRequestDto);
                response.Success = true;
                logger.LogInformation($"Genero musical con id {id} actualizado");
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"Ocurrio un error al obtener la información.";
                logger.LogError($"{response.ErrorMessage}: {ex.Message}");
                return BadRequest(response);
            }   
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new BaseResponse();
            try
            {
                var item = await this.repository.GetAsync(id);
                if (item is null)
                {
                    logger.LogWarning($"No se encontro registro con el id: {id}");
                    return NotFound(response);
                }

                await this.repository.DeleteAsync(id);
                response.Success = true;
                logger.LogInformation($"Genero musical con id: {id} eliminado");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"Ocurrio un error al obtener la información.";
                logger.LogError($"{response.ErrorMessage}: {ex.Message}");
                return BadRequest(response);
            }
        }
    }
}

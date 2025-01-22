using Microsoft.AspNetCore.Mvc;
using MusicStore.Entities;
using MusicStore.Repositories;
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
            try
            {
                var data = await repository.GetAsync();
                logger.LogInformation($"Se obtuvieron todos los generos musicales.");
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message}");
                return BadRequest("Ocurrio un error al obtener la información.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var item = await repository.GetAsync(id);
                if (item is null)
                {
                    logger.LogWarning($"Genero musical con id {id} no se encontro.");
                    return NotFound("No se encontro registro");
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message}");
                return BadRequest("Ocurrio un error al obtener la información.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Genre genre)
        {
            try
            {
                await repository.AddAsync(genre);
                logger.LogInformation($"Genero musical con id {genre.Id} insertado.");
                return CreatedAtAction(nameof(Get), new { Id = genre.Id }, genre);
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message}");
                return BadRequest("Ocurrio un error al guardar la información.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Genre genre)
        {
            try
            {
                var item = await repository.GetAsync(id);
                if (item is null)
                {
                    logger.LogWarning($"Genero musical con id {id} no se encontro.");
                    return NotFound("No se encontro registro");
                }

                await repository.UpdateAsync(id, genre);
                logger.LogInformation($"Genero musical con id {id} actualizado.");
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message}");
                return BadRequest("Ocurrio un error al guardar la información.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                try
                {
                   var item = await repository.GetAsync(id);
                    if (item is null)
                    {
                        logger.LogWarning($"Genero musical con id {id} no se encontro.");
                        return NotFound("No se encontro registro");
                    }

                    await repository.DeleteAsync(id);
                    logger.LogInformation($"Genero musical con id {id} eliminado.");
                    return NoContent();
                }
                catch (Exception ex)
                {
                    logger.LogError($"{ex.Message}");
                    return BadRequest("Ocurrio un error al guardar la información.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message}");
                return BadRequest("Ocurrio un error al guardar la información.");
            }
        }
    }
}

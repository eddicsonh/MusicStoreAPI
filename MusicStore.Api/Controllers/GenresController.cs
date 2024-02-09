using Microsoft.AspNetCore.Mvc;
using MusicStore.Entities;
using MusicStore.Repository;

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
            try
            {
                var data = await this.repository.GetAsync();
                logger.LogInformation($"Obteniendo todos los generos musicales.");
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
                var item = await this.repository.GetAsync(id);
                if (item is null)
                    return NotFound($"No se encontro genero musical con el id: {id}");

                logger.LogInformation($"Obteniendo el genero musicale por id: {id}.");
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
                await this.repository.AddAsync(genre);
                logger.LogInformation($"genero musical con id: {genre.Id} insertado");
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message}");
                return BadRequest("Ocurrio un error al insertar la información");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Genre genre)
        {
            try
            {
                var item = await this.repository.GetAsync(id);
                if (item is null)
                    return NotFound($"No se encontro registro con el id: {id}");

                await this.repository.UpdateAsync(id, genre);
                logger.LogInformation($"Genero musical con id {id} actualizado");
                return NoContent();

            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message}");
                return BadRequest("Ocurrio un error al actualizar la información");
            }   
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await this.repository.GetAsync(id);
                if (item is null)
                    return NotFound($"No se encontro registro con el id: {id}");

                await this.repository.DeleteAsync(id);
                logger.LogInformation($"Genero musical con id: {id} eliminado");
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message}");
                return BadRequest($"Ocurrio un error al eliminar la información");
            }
        }
    }
}

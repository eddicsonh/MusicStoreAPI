using Microsoft.AspNetCore.Mvc;
using MusicStore.Dto;
using MusicStore.Dto.Request;
using MusicStore.Entities;
using MusicStore.Repositories;

namespace MusicStore.Api.Controllers
{
    [ApiController]
    [Route("api/concerts")]
    public class ConcertsController : ControllerBase
    {
        private readonly IConcertRepository repository;
        private readonly IGenreRepository genreRepository;
        private readonly ILogger<ConcertsController> logger;
        public ConcertsController(IConcertRepository repository, IGenreRepository genreRepository,ILogger<ConcertsController> logger)
        {
            this.repository = repository;
            this.genreRepository = genreRepository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var response = BaseResponseGenerics<ICollection<ConcertResponseDto>>
            var concerts = await repository.GetAsync();
            return Ok(concerts);
        }

        [HttpGet("title")]
        public async Task<IActionResult> Get(string? title)
        {
            var concerts = await repository.GetAsync(title); //GetAsync(x => x.Title.Contains(title ?? string.Empty), x => x.DateEvent);
            return Ok(concerts);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ConcertRequestDto concertRequestDto)
        {
            var response = new BaseResponseGenerics<int>();
            try
            {
                var genre = await genreRepository.GetAsync(concertRequestDto.GenreId);
                if(genre is null)
                {
                    response.ErrorMessage = $"El id del Genero {concertRequestDto.GenreId} es incorrecto.";
                    response.Success = false;
                    logger.LogWarning(response.ErrorMessage);
                    return BadRequest(response);
                }
                var concertDb = new Concert
                {
                    Title = concertRequestDto.Title,
                    Description = concertRequestDto.Description,
                    Place = concertRequestDto.Place,
                    UnitePrice = concertRequestDto.UnitePrice,
                    DateEvent = concertRequestDto.DateEvent,
                    TicketQuantity = concertRequestDto.TicketQuantity,
                    GenreId = concertRequestDto.GenreId,
                    ImageUrl = concertRequestDto.ImageUrl,
                };
                response.Data = await repository.AddAsync(concertDb);
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al guardar la información.";
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}

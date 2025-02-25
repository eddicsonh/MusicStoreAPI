using Azure;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Services.Interface;

namespace MusicStore.Api.Controllers
{
    [ApiController]
    [Route("api/concerts")]
    public class ConcertsController : ControllerBase
    {
        private readonly IConcertService service;

        public ConcertsController(IConcertService service)
        {
            this.service = service;
        }

        [HttpGet("title")]
        public async Task<IActionResult> Get(string? title)
        {
            var response = await service.GetAsync(title);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await service.GetAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(ConcertRequestDto concertRequestDto)
        //{
        //    var response = new BaseResponseGenerics<int>();
        //    try
        //    {
        //        var genre = await genreRepository.GetAsync(concertRequestDto.GenreId);
        //        if(genre is null)
        //        {
        //            response.ErrorMessage = $"El id del Genero {concertRequestDto.GenreId} es incorrecto.";
        //            response.Success = false;
        //            logger.LogWarning(response.ErrorMessage);
        //            return BadRequest(response);
        //        }
        //        var concertDb = new Concert
        //        {
        //            Title = concertRequestDto.Title,
        //            Description = concertRequestDto.Description,
        //            Place = concertRequestDto.Place,
        //            UnitePrice = concertRequestDto.UnitePrice,
        //            DateEvent = concertRequestDto.DateEvent,
        //            TicketQuantity = concertRequestDto.TicketQuantity,
        //            GenreId = concertRequestDto.GenreId,
        //            ImageUrl = concertRequestDto.ImageUrl,
        //        };
        //        response.Data = await repository.AddAsync(concertDb);
        //        response.Success = true;
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ErrorMessage = "Ocurrio un error al guardar la información.";
        //        logger.LogError(ex, ex.Message);
        //        throw;
        //    }
        //}
    }
}

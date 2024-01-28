using Microsoft.AspNetCore.Mvc;
using MusicStore.Entities;
using MusicStore.Repository;

namespace MusicStore.Api.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly GenreRepository repository;
        public GenresController(GenreRepository genreRepository)
        {
            this.repository = genreRepository;
        }

        [HttpGet]
        public ActionResult<List<Genre>> Get()
        {
            return this.repository.Get();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Genre> Get(int id)
        {
            var genreResult = this.repository.Get(id);
            return genreResult is not null ? genreResult : NotFound();
        }

        [HttpPost]
        public ActionResult Post(Genre genre)
        {

            this.repository.Add(genre);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Genre genre)
        {
            this.repository.Update(id, genre);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            this.repository.Delete(id);
            return Ok();
        }
    }
}

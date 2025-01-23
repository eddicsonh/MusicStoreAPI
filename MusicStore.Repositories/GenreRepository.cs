using Microsoft.EntityFrameworkCore;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Persistence;

namespace MusicStore.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext context;
        public GenreRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<GenreResponseDto>> GetAsync()
        {
            var item = await context.Genres
                .AsNoTracking()
                .ToListAsync();

            var genresResponseDto = item.Select(x => new GenreResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status
            }).ToList();
            return genresResponseDto;

        }

        public async Task<GenreResponseDto?> GetAsync(int id)
        {
            var item = await context.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            var genreRsesponseDto = new GenreResponseDto();

            if (item is not null)
            {
                genreRsesponseDto.Id = item.Id;
                genreRsesponseDto.Name = item.Name;
                genreRsesponseDto.Status = item.Status;
            }
            else
            {
                throw new InvalidOperationException($"No se encontro el registro con id {id}");
            }
            return genreRsesponseDto;
        }

        public async Task<int> AddAsync(GenreRequestDto genresRequestDto)
        {
            var genre = new Genre
            {
                Name = genresRequestDto.Name,
                Status = genresRequestDto.Status
            };

            context.Genres.Add(genre);
            await context.SaveChangesAsync();
            return genre.Id;
        }

        public async Task UpdateAsync(int id, GenreRequestDto genresRequestDto)
        {
            var item = await context.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item is not null)
            {
                item.Name = genresRequestDto.Name;
                item.Status = genresRequestDto.Status;
                context.Genres.Update(item);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"No se encontro el registro con id {id}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var item = await context.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item is not null)
            {
                context.Genres.Remove(item);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"No se encontro el registro con id {id}");
            }

        }
    }
}

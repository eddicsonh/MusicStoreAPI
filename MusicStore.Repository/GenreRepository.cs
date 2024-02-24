using Microsoft.EntityFrameworkCore;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Persistence;

namespace MusicStore.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext context;

        #region Constructor
        public GenreRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public async Task<List<GenreResponseDto>> GetAsync()
        {
            var items =  await context.Genres
                .AsNoTracking()
                .ToListAsync();

            //Mapping
            var genreResponseDto = items.Select(x => new GenreResponseDto { 
                 Id = x.Id
                ,Name = x.Name
                ,Status = x.Status
            }).ToList();

            return genreResponseDto;
        }

        public async Task<GenreResponseDto?> GetAsync(int id)
        {
            var item = await context.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            GenreResponseDto genreResponseDto = new GenreResponseDto();
            if (item is not null)
            {
                //Mapping
                genreResponseDto.Id = item.Id;
                genreResponseDto.Name = item.Name;
                genreResponseDto.Status = item.Status;
            }
            else
                throw new InvalidOperationException($"No se encontro el registro con el id: {id}");

            return genreResponseDto;
        }

        public async Task<int> AddAsync(GenreRequestDto genreRequestDto)
        {
            //Mapping
            var genre = new Genre 
            {
                Name = genreRequestDto.Name,
                Status = genreRequestDto.Status,
            };

            context.Genres.Add(genre);
            await context.SaveChangesAsync();
            return genre.Id;
        }

        public async Task UpdateAsync(int id, GenreRequestDto genreRequestDto)
        {
            var item = await context.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item is not null)
            {
                //Mapping
                item.Name = genreRequestDto.Name;
                item.Status = genreRequestDto.Status;

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

        #endregion
    }
}

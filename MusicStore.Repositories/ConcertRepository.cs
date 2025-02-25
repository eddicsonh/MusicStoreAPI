using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;
using MusicStore.Entities.Info;
using MusicStore.Persistence;

namespace MusicStore.Repositories
{
    public class ConcertRepository : RepositoryBase<Concert>, IConcertRepository
    {
        public ConcertRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Concert?> GetAsync(int id)
        {
            //eager loading approach
            return await context.Set<Concert>()
                .Include(x => x.Genre)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<ConcertInfo>> GetAsync(string? title)
        {
            //eager loading approach
            return await context.Set<Concert>()
                .Include(x => x.Genre)
                .Where(x => x.Title.Contains(title ?? string.Empty))
                .AsNoTracking()
                .Select(x => new ConcertInfo()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Place = x.Place,
                    UnitePrice = x.UnitePrice,
                    Genre = x.Genre.Name,
                    GenreId = x.GenreId,
                    DateEvent = x.DateEvent.ToShortDateString(),
                    TimeEvent = x.DateEvent.ToShortTimeString(),
                    ImageUrl = x.ImageUrl,
                    Finalized = x.Finalized,
                    Status = x.Status ? "Activo" : "Inactivo"
                })
                .ToListAsync();

            //Lazy Loading
            //    return await context.Set<Concert>()
            //    .Where(x => x.Title.Contains(title ?? string.Empty))
            //    .AsNoTracking()
            //    .Select(x => new ConcertInfo()
            //    {
            //        Id = x.Id,
            //        Title = x.Title,
            //        Description = x.Description,
            //        Place = x.Place,
            //        UnitePrice = x.UnitePrice,
            //        Genre = x.Genre.Name,
            //        GenreId = x.GenreId,
            //        DateEvent = x.DateEvent.ToShortDateString(),
            //        TimeEvent = x.DateEvent.ToShortTimeString(),
            //        ImageUrl = x.ImageUrl,
            //        Finalized = x.Finalized,
            //        Status = x.Status ? "Activo" : "Inactivo"
            //    })
            //    .ToListAsync();

            //Raw Query

            //var query = context.Set<ConcertInfo>().FromSqlRaw("usp_ListConcert {0}", title ?? String.Empty);
            //return await query.ToListAsync();
        }

    }
}

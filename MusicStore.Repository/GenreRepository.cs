using MusicStore.Entities;

namespace MusicStore.Repository
{
    public class GenreRepository
    {
        private readonly List<Genre> genreList = new List<Genre>();

        #region Constructor
        public GenreRepository()
        {
           genreList.Add(new Genre() {Id = 1, Name = "Electronica", Status = true});
           genreList.Add(new Genre() {Id = 2, Name = "Rock", Status = true});
           genreList.Add(new Genre() {Id = 3, Name = "Pop", Status = true});
        }

        #endregion

        #region Methods

        public List<Genre> Get()
        {
            return genreList;
        }

        public Genre? Get(int id)
        {
            return genreList.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Genre genre)
        {
            genre.Id = genreList.MaxBy(x => x.Id).Id + 1;
            genreList.Add(genre);
        }

        public void Update(int id, Genre genre)
        {
            var item = Get(id);
            if(item is not null)
            {
                item.Name = genre.Name;
                item.Status = genre.Status;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null)
            {
               genreList.Remove(item);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        #endregion
    }
}

using GameStore.BLL.Services.Abstraction;
using GameStoreDAL.Entities;
using GameStoreDAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly IGenericRepository<Genre> genres;
        public GenreService(IGenericRepository<Genre> _genres)
        {
            genres = _genres;
        }
        public void AddGenre(Genre genre)
        {
            genres.Create(genre);
        }

        public void DeleteGenre(Genre genre)
        {
            genres.Delete(genre);
        }

        public ICollection<Genre> GetAllGenres()
        {
            return genres.GetAll().ToList();
        }

        public Genre GetGenre(int id)
        {
            return genres.Find(id);
        }
    }
}

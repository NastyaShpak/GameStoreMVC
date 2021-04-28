using Binbin.Linq;
using GameStore.BLL.Filters;
using GameStore.BLL.Services.Abstraction;
using GameStoreDAL.Entities;
using GameStoreDAL.Repository.Abstraction;
using GameStoreDAL.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class GameService : IGameService
    {
        private readonly IGenericRepository<Game> repo;
        private readonly IGenericRepository<Developer> repoDev;
        private readonly IGenericRepository<Genre> repoGenre;
        public GameService(IGenericRepository<Game> _repo, IGenericRepository<Developer> _repoDev, IGenericRepository<Genre> _repoGenre)
        {
            repo = _repo;
            repoDev = _repoDev;
            repoGenre = _repoGenre;
        }
        public void AddGame(Game game)
        {
            var dev = repoDev.GetAll().FirstOrDefault(x => x.Name == game.Developer.Name);
            if (dev != null)
                game.Developer = dev;

            var genre = repoGenre.GetAll().FirstOrDefault(x => x.Name == game.Genre.Name);
            if (genre != null)
                game.Genre = genre;

            repo.Create(game);
        }

        public void UpdateGame(Game game)
        {
            var dev = repoDev.GetAll().FirstOrDefault(x => x.Name == game.Developer.Name).Id;
            if (dev != 0)
                game.DeveloperId = dev;

            var genre = repoGenre.GetAll().FirstOrDefault(x => x.Name == game.Genre.Name).Id;
            if (genre != 0)
                game.GenreId = genre;

            repo.Update(game);
        }

        public void DeleteGame(Game game)
        {
            repo.Delete(game);
        }

        public ICollection<Game> GetAllGames()
        {
            return repo.GetAll().ToList();
        }

        public ICollection<string> GetDevelopers()
        {
            return repoDev.GetAll().Select(x => x.Name).ToList();
        }

        public ICollection<string> GetGenres()
        {
            return repoGenre.GetAll().Select(x => x.Name).ToList();
        }

        public Game GetGame(int id)
        {
            return repo.Find(id);
        }

        public ICollection<Game> GetAllGames(List<GamesFilter> filters)
        {
            var games = repo.GetAll();
            if(filters != null && filters.Count() != 0)
            {
                /*return  games.Where(filters[0].Predicate.Compile()).ToList();*/

                var predicatesGroups = new List<Expression<Func<Game, bool>>>();

                foreach (var type in filters.GroupBy(x => x.Type))
                {
                var builder = PredicateBuilder.Create(type.First().Predicate);
                    for (int i =1; i < type.Count(); i++)
                    {
                        builder = builder.Or(type.ToArray()[i].Predicate);


                    }
                    predicatesGroups.Add(builder);
                }
                var predicate = PredicateBuilder.Create(predicatesGroups[0]);


                for (int i =  1; i < predicatesGroups.Count(); i++)
                {
                    predicate = predicate.And(predicatesGroups[i]);
                }
                return games.Where(predicate.Compile()).ToList();

            }

            return games.ToList();
        }
    }
}

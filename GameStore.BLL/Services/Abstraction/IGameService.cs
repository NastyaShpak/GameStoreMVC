using GameStore.BLL.Filters;
using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstraction
{
    public interface IGameService
    {
        ICollection<Game> GetAllGames();
        ICollection<Game> GetAllGames(List<GamesFilter> filters);
        void AddGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(Game game);
        Game GetGame(int id);
        ICollection<string> GetDevelopers();
        ICollection<string> GetGenres();
    }
}

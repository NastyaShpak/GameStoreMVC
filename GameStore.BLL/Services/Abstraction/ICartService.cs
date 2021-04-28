using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstraction
{
    public interface ICartService
    {
        ICollection<Cart> GetAllGames();
        void AddItem(Cart cart);
        void DeleteItem(Cart cart);
    }
}

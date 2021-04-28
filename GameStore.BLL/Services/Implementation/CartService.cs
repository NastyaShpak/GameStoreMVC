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
    public class CartService : ICartService
    {
        private readonly IGenericRepository<Cart> repoCart;
        public CartService(IGenericRepository<Cart> _repoCart)
        {
            repoCart = _repoCart;
        }
        public void AddItem(Cart cart)
        {
            repoCart.Create(cart);
        }

        public void DeleteItem(Cart cart)
        {
            repoCart.Delete(cart);
        }

        public ICollection<Cart> GetAllGames()
        {
            return repoCart.GetAll().ToList();
        }
    }
}

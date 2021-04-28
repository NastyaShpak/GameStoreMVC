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
    public class DeveloperService : IDeveloperService
    {
        private readonly IGenericRepository<Developer> developers;
        public DeveloperService(IGenericRepository<Developer> _developers)
        {
            developers = _developers;
        }
        public void AddDeveloper(Developer developer)
        {
            developers.Create(developer);
        }

        public void DeleteDeveloper(Developer developer)
        {
            developers.Delete(developer);
        }

        public ICollection<Developer> GetAllDevelopers()
        {
            return developers.GetAll().ToList();
        }

        public Developer GetDeveloper(int id)
        {
            return developers.Find(id);
        }
    }
}

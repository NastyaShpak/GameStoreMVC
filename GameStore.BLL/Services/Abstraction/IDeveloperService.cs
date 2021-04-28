using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstraction
{
    public interface IDeveloperService
    {
        ICollection<Developer> GetAllDevelopers();
        void AddDeveloper(Developer developer);
        void DeleteDeveloper(Developer developer);
        Developer GetDeveloper(int id);
    }
}

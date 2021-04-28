using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreDAL.Initializer
{
    public class GamesInitializer: DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var genres = new List<Genre>
            {
                new Genre{Name = "Action"},
                new Genre{Name = "Shooter"},
                new Genre{Name = "RPG"},
                new Genre{Name = "Strategy"},
                new Genre{Name = "Racing"},
                new Genre{Name = "Sport Simulator"}
            };

            var developers = new List<Developer>
            {
                new Developer{Name = "RockStar"},
                new Developer{Name = "EA"},
                new Developer{Name = "Epic"},
                new Developer{Name = "Bethesda"},
                new Developer{Name = "Activision"},
                new Developer{Name = "Valve"},
                new Developer{Name = "Ghost Games"},
                new Developer{Name = "Playrix"},
                new Developer{Name = "Ubisoft"}
            };

            var games = new List<Game>
            {
                new Game
                {
                    Name = "FarCry",
                    Description = "Far cry info",
                    Image = "https://games.logrusit.com/media/1403/farcry5.jpg",
                    Price = 34,
                    Year = 2018,
                    Genre = genres.FirstOrDefault(x=>x.Name == "Shooter"),
                    Developer = developers.FirstOrDefault(x=>x.Name == "Ubisoft"),
                    Quantity = 20
                },
                new Game
                {
                    Name = "Assassins Creed",
                    Description = "AC info",
                    Image = "https://images-na.ssl-images-amazon.com/images/I/81x9ND8PFML._AC_UL600_SR600,600_.jpg",
                    Price = 54,
                    Year = 2018,
                    Genre = genres.FirstOrDefault(x=>x.Name == "Action"),
                    Developer = developers.FirstOrDefault(x=>x.Name == "Ubisoft"),
                    Quantity = 10
                },
                new Game
                {
                    Name = "GTA 5",
                    Description = "Gta info",
                    Image = "https://thebrag.com/wp-content/uploads/2019/04/276031-grand-theft-auto-v-playstation-3-front-cover-600x600.jpg",
                    Price = 20,
                    Year = 2019,
                    Genre = genres.FirstOrDefault(x=>x.Name == "RPG"),
                    Developer = developers.FirstOrDefault(x=>x.Name == "RockStar"),
                    Quantity = 5
                },
                new Game
                {
                    Name = "FIFA",
                    Description = "Fifa info",
                    Image = "https://www.digiseller.ru/preview/777992/p1_2553905_04088e3e.jpg",
                    Price = 64,
                    Year = 2018,
                    Genre = genres.FirstOrDefault(x=>x.Name == "Sport Simulator"),
                    Developer = developers.FirstOrDefault(x=>x.Name == "EA"),
                    Quantity = 15
                },
                new Game
                {
                    Name = "NFS",
                    Description = "Nfs info",
                    Image = "https://www.thegamingreview.com/wp-content/uploads/2019/11/NFS-Heat.jpg",
                    Price = 40,
                    Year = 2018,
                    Genre = genres.FirstOrDefault(x=>x.Name == "Racing"),
                    Developer = developers.FirstOrDefault(x=>x.Name == "Ghost Games"),
                    Quantity = 30
                }
            };
            context.Genres.AddRange(genres);
            context.Developers.AddRange(developers);
            context.Games.AddRange(games);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}

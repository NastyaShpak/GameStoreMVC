namespace GameStoreDAL
{
    using GameStoreDAL.Entities;
    using GameStoreDAL.Initializer;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
            Database.SetInitializer(new GamesInitializer());
        }
    }
}
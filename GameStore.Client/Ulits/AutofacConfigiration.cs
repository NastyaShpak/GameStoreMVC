using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using GameStore.BLL.Services.Abstraction;
using GameStore.BLL.Services.Implementation;
using GameStoreDAL;
using GameStoreDAL.Repository.Abstraction;
using GameStoreDAL.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.Client.Ulits
{
    public static class AutofacConfigiration
    {
        public static void ConfigurationAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ApplicationContext>().As<DbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<GameService>().As<IGameService>();
            builder.RegisterType<GenreService>().As<IGenreService>();
            builder.RegisterType<DeveloperService>().As<IDeveloperService>();

            var mapperConfig = new MapperConfiguration(config => config.AddProfile(new AutomapperProfile()));
            builder.RegisterInstance<IMapper>(mapperConfig.CreateMapper());

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));            
        }
    }
}
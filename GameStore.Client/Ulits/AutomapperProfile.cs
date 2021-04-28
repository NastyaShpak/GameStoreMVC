using AutoMapper;
using GameStore.Client.Models;
using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.Client.Ulits
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Game, GameViewModel>()
                .ForMember(x=>x.Developer, opt=>opt.MapFrom(x=>x.Developer.Name))
                .ForMember(x => x.Genre, opt => opt.MapFrom(x => x.Genre.Name));

            CreateMap<GameViewModel, Game>()
                .ForMember(x => x.Developer, opt => opt.MapFrom(x => new Developer { Name = x.Developer }))
                .ForMember(x => x.Genre, opt => opt.MapFrom(x => new Genre { Name = x.Genre }));

            CreateMap<Genre, GenreViewModel>();
            CreateMap<GenreViewModel, Genre>();

            CreateMap<Developer, DeveloperViewModel>();
            CreateMap<DeveloperViewModel, Developer>();
        }
    }
}
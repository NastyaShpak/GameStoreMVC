using AutoMapper;
using GameStore.BLL.Services.Abstraction;
using GameStore.Client.Models;
using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.Client.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        private readonly IGenreService genreService;
        private readonly IMapper mapper;

        public GenreController(IGenreService _genreService, IMapper _mapper)
        {
            genreService = _genreService;
            mapper = _mapper;
        }
        public ActionResult Index()
        {
            ICollection<Genre> genres = genreService.GetAllGenres();

            var model = mapper.Map<ICollection<GenreViewModel>>(genres);

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(GenreViewModel item)
        {
            if (ModelState.IsValid)
            {
                var genre = mapper.Map<Genre>(item);

                genreService.AddGenre(genre);
                return RedirectToAction("Index");
            }
            return Add();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = genreService.GetGenre(id);

            genreService.DeleteGenre(model);

            return RedirectToAction("Index");

        }
    }
}
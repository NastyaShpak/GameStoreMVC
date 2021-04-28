using AutoMapper;
using GameStore.BLL.Filters;
using GameStore.BLL.Services.Abstraction;
using GameStore.Client.Models;
using GameStore.Client.Ulits.Helpers;
using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GameStore.Client.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService gameService;
        private readonly IMapper mapper;
        public GamesController(IGameService _service, IMapper _mapper)
        {
            gameService = _service;
            mapper = _mapper;
        }
        // GET: Games
        public ActionResult Index()
        {
            ViewBag.Genres = gameService.GetGenres();
            ViewBag.Developers = gameService.GetDevelopers();
            ICollection<Game> games = gameService.GetAllGames();

            var model = mapper.Map<ICollection<GameViewModel>>(games);

            return View(model);
        }

        public ActionResult Filter(string filter, string name)
        {
            ICollection<Game> games = null;

            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(filter))
            {
                AddFilter(filter, name);
                games = gameService.GetAllGames(Session["GamesFilter"] as List<GamesFilter>);
            }

            var model = mapper.Map<ICollection<GameViewModel>>(games);
            return PartialView("GamesPartial", model);
        }

        public ActionResult Sort(string type)
        {
            ICollection<Game> games = null;
            games = gameService.GetAllGames();

            if (type == "asc")
            {
                games = games.OrderBy(g => g.Price).ToList();
            }
            else if (type == "desc")
            {
                games = games.OrderByDescending(g => g.Price).ToList();
            }

            var model = mapper.Map<ICollection<GameViewModel>>(games);

            return PartialView("GamesPartial", model);
        }

        public ActionResult Search(string name)
        {
            ICollection<Game> games = null;
            games = gameService.GetAllGames();
            if (!String.IsNullOrEmpty(name))
            {
                games = games.Where(g => g.Name.Contains(name)).ToList();

            }
            var model = mapper.Map<ICollection<GameViewModel>>(games);

            return PartialView("GamesPartial", model);
        }

        private void AddFilter(string type, string name)
        {
            var filters = (Session["GamesFilter"] as List<GamesFilter>);

            if (filters == null)
            {
                filters = new List<GamesFilter>();
            }

            var f = filters.FirstOrDefault(x => x.Type == type && x.Name == name);

            if (f != null)
            {
                filters.Remove(f);
                Session["GamesFilter"] = filters;
                return;
            }

            var filter = new GamesFilter
            {
                Name = name,
                Type = type
            };

            if (type == "Genre")
            {
                filter.Predicate = (x => x.Genre.Name == name);
            } 
            else if (type == "Developer")
            {
                filter.Predicate = (x => x.Developer.Name == name);
            }

            filters.Add(filter);

            Session["GamesFilter"] = filters;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Developers = gameService.GetDevelopers();
            ViewBag.Genres = gameService.GetGenres();
            return View();
        }

        [Authorize]
        [HttpPost]
         public async Task<ActionResult> Create(GameViewModel item, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                string fileName = Guid.NewGuid().ToString() + ".jpg";
                string fullPath = Server.MapPath("~/Images/Games/") + fileName;
                Bitmap bitmap = null;

                if (image == null)
                {
                    string imagePath = item.Image;
                    using (HttpClient webClient = new HttpClient())
                    {
                        bitmap =  new Bitmap(await webClient.GetStreamAsync(imagePath));
                        var convertedPicture = CustomImageConverter.ConvertImage(bitmap, 600, 600);
                        if (convertedPicture != null)
                        {
                            convertedPicture.Save(fullPath, ImageFormat.Jpeg);
                            item.Image = "/Images/Games/" + fileName;
                        }
                    }
                }
                else
                {
                    var convertedPicture = CustomImageConverter.ConvertImage(new Bitmap(image.InputStream), 600, 600);
                    if (convertedPicture != null)
                    {
                        convertedPicture.Save(fullPath, ImageFormat.Jpeg);
                        item.Image = "/Images/Games/" + fileName;
                    }
                }

                var game = mapper.Map<Game>(item);

                gameService.AddGame(game);
                return RedirectToAction("Index");
            }
            return Create();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = gameService.GetGame(id);
            var game = mapper.Map<GameViewModel>(model);

            ViewBag.Developers = gameService.GetDevelopers();
            ViewBag.Genres = gameService.GetGenres();
            return View(game);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(GameViewModel model)
        {
            if (ModelState.IsValid)
            {
                var game = mapper.Map<Game>(model);

                gameService.UpdateGame(game);
                return RedirectToAction("Index");
            }
            return View(model.Id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = gameService.GetGame(id);

            gameService.DeleteGame(model);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = gameService.GetGame(id);
            var game = mapper.Map<GameViewModel>(model);
            return View(game);
        }
    }
}

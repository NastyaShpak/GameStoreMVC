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
    public class DeveloperController : Controller
    {
        // GET: Developer
        private readonly IDeveloperService developerService;
        private readonly IMapper mapper;

        public DeveloperController(IDeveloperService _developerService, IMapper _mapper)
        {
            developerService = _developerService;
            mapper = _mapper;
        }
        public ActionResult Index()
        {
            ICollection<Developer> develppers = developerService.GetAllDevelopers();

            var model = mapper.Map<ICollection<DeveloperViewModel>>(develppers);

            return View(model);
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(DeveloperViewModel item)
        {
            if (ModelState.IsValid)
            {
                var developer = mapper.Map<Developer>(item);

                developerService.AddDeveloper(developer);
                return RedirectToAction("Index");
            }
            return Add();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = developerService.GetDeveloper(id);

            developerService.DeleteDeveloper(model);

            return RedirectToAction("Index");
        }
    }
}
using GameStore.Client.Models;
using GameStore.Client.Ulits;
using GameStoreDAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GameStore.Client.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var signInManager = HttpContext.GetOwinContext().Get<AppSigninManager>();

            var status = signInManager.PasswordSignIn(model.Username, model.Password, false, false);
            if (status == SignInStatus.Success)
                return RedirectToAction("Index", "Games");
            else return Content("Something was wrong!");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var manager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

                var user = new User
                {
                    UserName = model.Username,
                    Email = model.Email,
                    Age = 18,
                    Gender = "Male"
                };

                var result = await manager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    return RedirectToAction("Login", "Auth");
            }

            return RedirectToAction("Register");
        }

        public ActionResult Account(string name)
        {
            ViewBag.Name = name;
            return View();
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Index", "Games");
        }
    }
}
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using GameStore.Client.Ulits;
using GameStoreDAL;
using GameStoreDAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GameStore.Client.Startup))]

namespace GameStore.Client
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<DbContext>(() => new ApplicationContext());

            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            app.CreatePerOwinContext<AppSigninManager>(AppSigninManager.Create);

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath =  new PathString("/Auth/Login")
            });
        
        InitUser();
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }

        private void InitUser()
        {
            var userStore = new UserStore<User>(new ApplicationContext());
            var userManager = new AppUserManager(userStore);

            var role = new IdentityRole
            {
                Name = "Admin"
            };

            var roleStore = new RoleStore<IdentityRole>(new ApplicationContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);


            roleManager.Create(role);

            var user = new User
            {
                UserName = "alex",
                Email = "alex@gmail.com"
            };

            var admin = new User
            {
                UserName = "sa",
                Email = "sa@gmail.com"
            };

            userManager.Create(user, "Qwerty1");
            userManager.Create(admin, "Qwerty1");

            userManager.AddToRole(userManager.FindByName("sa").Id, "Admin");
        }
    }
}

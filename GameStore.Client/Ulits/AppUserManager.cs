using GameStoreDAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameStore.Client.Ulits
{
    public class AppUserManager: UserManager<User>
    {
        public AppUserManager(IUserStore<User> store): base(store) { }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext owin)
        {
            var dbContext = owin.Get<DbContext>();
            var manager = new AppUserManager(new UserStore<User>(dbContext));

            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequireDigit = true,
                RequiredLength = 6,
                RequireLowercase = true,
                RequireNonLetterOrDigit = false,
                RequireUppercase = true
            };

            var dataProvider = options.DataProtectionProvider;
            if (dataProvider != null)
                manager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProvider.Create("token"));

            return manager;
        }
    }
}
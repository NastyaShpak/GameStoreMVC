using GameStoreDAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.Client.Ulits
{
    public class AppSigninManager: SignInManager<User, string>
    {
        public AppSigninManager(AppUserManager userManager, IAuthenticationManager authenticationManager): base(userManager, authenticationManager)
        {     
        }

        public static AppSigninManager Create(IdentityFactoryOptions<AppSigninManager> options, IOwinContext owinContext)
        {
            var userManager = owinContext.GetUserManager<AppUserManager>();
            var signinManager = new AppSigninManager(userManager, owinContext.Authentication);

            return signinManager;
        }
    }
}
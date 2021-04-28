using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreDAL.Entities
{
    public class User: IdentityUser
    {
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}

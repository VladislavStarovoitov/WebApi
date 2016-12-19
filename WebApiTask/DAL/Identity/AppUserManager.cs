using Microsoft.AspNet.Identity;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Identity
{
    public class AppUserManager : UserManager<User>
    {
        public AppUserManager(IUserStore<User> store) : base(store)
        {
            PasswordValidator = new PasswordValidator
            {
                RequireDigit = true,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false
            };
        }

        public ClaimsIdentity Authenticate(string email, string password)
        {
            ClaimsIdentity claim = null;

            User user = FindByEmailAsync(email).Result;
            if (!ReferenceEquals(user, null))
            {
                claim = CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie).Result;
            }

            return claim;
        }
    }
}

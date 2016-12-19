using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ORM.Contexts
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ToDoContext>
    {
        protected override void Seed(ToDoContext context)
        {
            var userManager = new AppUserManager(new UserStore<User>(context));

            var user = new User { Email = "vlad.nim2013@gmail.com", UserName = "vlad.nim2013@gmail.com" };
            string password = "123456";

            userManager.CreateAsync(user, password);            

            base.Seed(context);
        }
    }
}

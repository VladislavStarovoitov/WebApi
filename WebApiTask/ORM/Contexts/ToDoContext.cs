using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ToDoContext: IdentityDbContext<User>
    {
        public ToDoContext()
            :base("ToDoContext")
        { }

        public DbSet<ToDo> ToDos { get; set; }
    }
}

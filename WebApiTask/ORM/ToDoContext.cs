using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ToDoContext: DbContext
    {
        public ToDoContext()
            :base("ToDoContext")
        { }

        public DbSet<ToDo> ToDos { get; set; }

        public DbSet<User> Users { get; set; }
    }
}

using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class ToDoManager : IDisposable
    {
        private ToDoContext _dataBase;

        public ToDoManager(ToDoContext context)
        {
            _dataBase = context;
        }

        public bool Create(ToDo entity)
        {
            _dataBase.Set<ToDo>().Add(entity);
            return _dataBase.SaveChanges() > 0 ? true : false;
        }

        public ToDo Get(int id)
        {
            return _dataBase.Set<ToDo>().Find(id);
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _dataBase.Set<ToDo>().Select(x => x);
        }

        public bool Remove(int id)
        {
            var todo = _dataBase.Set<ToDo>().Find(id);
            if (ReferenceEquals(todo, null))
            {
                return false;
            }
            _dataBase.Set<ToDo>().Remove(todo);
            return _dataBase.SaveChanges() > 0 ? true : false;
        }

        public bool Update(ToDo entity)
        {
            _dataBase.Set<ToDo>().Attach(entity);
            var entry = _dataBase.Entry(entity);
            entry.State = EntityState.Modified;
            return _dataBase.SaveChanges() > 0 ? true : false;
        }

        public void Dispose()
        {
            _dataBase.Dispose();
        }
    }
}

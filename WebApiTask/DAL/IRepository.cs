using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<TEntity>
    {
        bool Create(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
    }
}

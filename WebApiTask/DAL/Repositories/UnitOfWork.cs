using DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private ToDoContext _dataBase;

        private ToDoManager _toDoManager;
        private AppUserManager _userManager;

        public UnitOfWork()
        {
            _dataBase = new ToDoContext();
            _toDoManager = new ToDoManager(_dataBase);
            _userManager = new AppUserManager(new UserStore<User>(_dataBase));
        }

        public ToDoManager ToDoManager
        {
            get
            {
                return _toDoManager;
            }
        }

        public AppUserManager UserManager
        {
            get
            {
                return _userManager;
            }
        }

        public static UnitOfWork Create()
        {
            return new UnitOfWork();
        }

        public void Dispose()
        {
            _toDoManager.Dispose();
            _userManager.Dispose();
        }
    }
}

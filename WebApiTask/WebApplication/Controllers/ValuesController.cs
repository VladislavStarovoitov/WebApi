using DAL;
using DAL.Repositories;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private UnitOfWork UnitOfWork
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<UnitOfWork>();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]ToDoModel todo)
        {
            todo.CreationDate = DateTime.Now;
            bool addResult = false;
            if (ModelState.IsValid)
            {
                addResult = UnitOfWork.ToDoManager.Create(todo.ToOrmToDo());
                if (!addResult)
                {
                    return InternalServerError();
                }
            }
            
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(UnitOfWork.ToDoManager.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(UnitOfWork.ToDoManager.Get(id));
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            bool removeResult = UnitOfWork.ToDoManager.Remove(id);
            if (!removeResult)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody]ToDoModel todo)
        {
            if (ModelState.IsValid)
            {
                bool updateResult = UnitOfWork.ToDoManager.Update(todo.ToOrmToDo());
                if (!updateResult)
                {
                    return BadRequest();
                }                
            }
            return Ok();
        }
    }
}

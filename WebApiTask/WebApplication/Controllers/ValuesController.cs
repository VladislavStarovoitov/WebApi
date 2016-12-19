using DAL;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ValuesController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        [HttpPost]
        public IHttpActionResult Post([FromBody]ToDoModel todo)
        {
            todo.CreationDate = DateTime.Now;
            bool addResult = false;
            if (ModelState.IsValid)
            {
                addResult = _unitOfWork.ToDoManager.Create(todo.ToOrmToDo());
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
            return Ok(_unitOfWork.ToDoManager.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_unitOfWork.ToDoManager.Get(id));
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            bool removeResult = _unitOfWork.ToDoManager.Remove(id);
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
                bool updateResult = _unitOfWork.ToDoManager.Update(todo.ToOrmToDo());
                if (!updateResult)
                {
                    return BadRequest();
                }                
            }
            return Ok();
        }
    }
}

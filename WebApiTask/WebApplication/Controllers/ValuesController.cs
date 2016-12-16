using DAL;
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
        private ToDoRepository _todoRepository = new ToDoRepository();

        [HttpPost]
        public IHttpActionResult Post([FromBody]ToDoModel todo)
        {
            todo.CreationDate = DateTime.Now;
            bool addResult = false;
            if (ModelState.IsValid)
            {
                addResult = _todoRepository.Create(todo.ToOrmToDo());
                if (!addResult)
                {
                    return Ok(HttpStatusCode.InternalServerError);
                }
            }
            
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAll() => Ok(_todoRepository.GetAll());

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_todoRepository.Get(id));
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            bool removeResult = _todoRepository.Remove(id);
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
                bool updateResult = _todoRepository.Update(todo.ToOrmToDo());
                if (!updateResult)
                {
                    return Ok(HttpStatusCode.BadRequest);
                }                
            }
            return Ok();
        }
    }
}

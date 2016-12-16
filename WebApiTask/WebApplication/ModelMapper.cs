using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication
{
    public static class ModelMapper
    {
        public static ToDoModel ToToDoModel(this ToDo todo)
        {
            return new ToDoModel
            {
                Id = todo.Id,
                Author = todo.Author,
                Title = todo.Title,
                Description = todo.Description,
                CreationDate = todo.CreationDate
            };
        }

        public static ToDo ToOrmToDo(this ToDoModel model)
        {
            return new ToDo
            {
                Id = model.Id,
                Author = model.Author,
                Title = model.Title,
                Description = model.Description,
                CreationDate = model.CreationDate
            };
        }
    }
}
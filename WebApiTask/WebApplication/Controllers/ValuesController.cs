﻿using System;
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
        [HttpPost]
        public void Post([FromBody]ToDo todo)
        {

        }
    }
}

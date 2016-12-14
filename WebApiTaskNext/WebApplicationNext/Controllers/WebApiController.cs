using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationNext.Models;

namespace WebApplicationNext.Controllers
{
    public class WebApiController : ApiController
    {
        [HttpPost]
        public void Post([FromBody]ToDo todo)
        {

        }
    }
}

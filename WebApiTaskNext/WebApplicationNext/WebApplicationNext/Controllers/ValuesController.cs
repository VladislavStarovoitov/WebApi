using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApplicationNext.Models;

namespace WebApplicationNext.Controllers
{
    public class ValuesController : ApiController
    {
        private const string uri = "http://localhost:55987/";

        [HttpPost]
        public IHttpActionResult Post([FromBody]object todo)
        {
            using (HttpClient client = new HttpClient()) 
            {
                client.BaseAddress = new Uri(uri);
                var content = new StringContent(todo.ToString(), Encoding.UTF8, "application/json");
                var response = client.PostAsync("api/Values/", content).Result;

                return Ok(response.StatusCode);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                var response = client.GetAsync("api/Values/").Result;

                return Ok((object)response.Content.ReadAsStringAsync().Result);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                var response = client.GetAsync($"api/Values/{id}").Result;

                return Ok((object)response.Content.ReadAsStringAsync().Result);
            }
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                var response = client.DeleteAsync($"api/Values/{id}").Result;

                return Ok(response.StatusCode);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody]object todo)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                var content = new StringContent(todo.ToString(), Encoding.UTF8, "application/json");
                var response = client.PutAsync("api/Values/", content).Result;

                return Ok(response.StatusCode);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestOne.Models;

namespace TestOne.Controllers
{
    public class PersonsController : ApiController
    {
        IList<Person> people = new List<Person>
            {
                new Person {Id= 0, First = "Peter", Last = "Petrov" },
                new Person {Id= 1, First = "Peter", Last = "Polonov " },
                new Person {Id= 2, First = "Peter", Last = "Peshev" },
                new Person {Id= 3, First = "Peter", Last = "Toshev" },
                new Person {Id= 4, First = "Peter", Last = "Gunter" },
            };

        // GET api/persons
        public IEnumerable<Person> Get()
        {
            return people;
        }

        // GET api/persons/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return this.Request.CreateResponse<Person>(HttpStatusCode.OK, people.FirstOrDefault(x => x.Id == id));
            }
            catch
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // POST api/persons
        public void Post([FromBody]Person value)
        {
        }

        // PUT api/persons/5
        public void Put(int id, [FromBody]Person value)
        {
        }

        // DELETE api/persons/5
        public void Delete(int id)
        {
        }
    }
}

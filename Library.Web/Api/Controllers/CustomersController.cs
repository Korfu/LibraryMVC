using Library.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Api.Controllers
{
    [Route("api/[controller]")] //[bazwoyAdresAplikaci}/api/customers
    public class CustomersController : Controller
    {
        [HttpGet]
        [Route("")] //[bazwoyAdresAplikaci}/api/customers GET
        public IEnumerable<Customer> Get()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Konrad", Surname = "Korf", DateOfBirth = DateTime.Now },
                new Customer { Id = 2, Name = "Tom", Surname = "Cruise", DateOfBirth = DateTime.Now.AddYears(-1) }
            };
        }

        [HttpGet]
        [Route("{id}")] //[bazwoyAdresAplikaci}/api/customers/1 GET
        public IActionResult Get([FromRoute]int id)
        {
            if (id == 1)
                return Ok(new Customer { Id = 3, Name = "Konrad", Surname = "Korf", DateOfBirth = DateTime.Now });
            else
                return NotFound();
        }

        [HttpPost]
        [Route("")] //[bazwoyAdresAplikaci}/api/customers 
        public IActionResult Create([FromBody]Customer customer)
        {
         return Created("",new Random().Next());
        }

        [HttpPut]
        [Route("")] //[bazwoyAdresAplikaci}/api/customers
        public int Update([FromBody]Customer customer)
        {
            return new Random().Next();
        }

        [HttpDelete]
        [Route("{id}")] //[bazwoyAdresAplikaci}/api/customers
        public int Delete([FromRoute]int id)
        {
            return new Random().Next();
        }


    }
}

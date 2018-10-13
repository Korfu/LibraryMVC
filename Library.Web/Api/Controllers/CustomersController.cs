using Library.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Repositories;


namespace Library.Web.Api.Controllers
{
    [Route("api/[controller]")] //[bazwoyAdresAplikaci}/api/customers
    public class CustomersController : Controller
    {
        private readonly ICustomersRepository _customerRepository;

        public CustomersController(ICustomersRepository customerRepostiory)
        {
            _customerRepository = customerRepostiory;
        }


        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")] //[bazwoyAdresAplikaci}/api/customers GET
        public IActionResult Get()
        {
            var customers = _customerRepository.GetAll();
            if (customers != null)
            {
                return Ok(customers);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")] //[bazwoyAdresAplikaci}/api/customers/1 GET
        public IActionResult GetAll([FromRoute]int id)
        {
            var customer = _customerRepository.Get(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("")] //[bazwoyAdresAplikaci}/api/customers 
        public IActionResult Create([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                var bookIdToBeSabed = _customerRepository.Add(customer);
                return Ok(customer);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("")] //[bazwoyAdresAplikaci}/api/customers
        public IActionResult Update([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.Edit(customer);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")] //[bazwoyAdresAplikaci}/api/customers
        public IActionResult Delete([FromRoute]int id)
        {
            var customer = _customerRepository.Get(id);
            _customerRepository.Delete(customer);
            return Ok();
        }


    }
}

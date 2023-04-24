using Microsoft.AspNetCore.Mvc;
using ProjMongoDB20230424.Models;
using ProjMongoDB20230424.Services;
namespace ProjMongoDB20230424.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // Injeção de dependencia
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get() => _customerService.Get();


        [HttpGet("{id:length(24)}", Name = "GetCustomer")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = _customerService.Get(id);
            if (customer == null) return NotFound();
            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            //_customerService.Create(customer);
            //return CreatedAtRoute("GetCustomer", new { id = customer.Id}, customer);
            return _customerService.Create(customer);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Customer customer)
        {
            var c = _customerService.Get(id);
            if (c == null) return NotFound();
            _customerService.Update(id, customer);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id) 
        {
            if (id == null) return NotFound();
            _customerService.Delete(id);

            var customer = _customerService.Get(id);
            if (customer == null) return NotFound();

            return Ok();
        }
    }
}

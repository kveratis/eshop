using Application.Customers.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ISender _sender;

        public CustomersController(ISender sender)
        {
            _sender = sender;
        }

        // GET: api/customers/
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/customers/5
        [HttpGet("{id:guid}", Name = "GetCustomerById")]
        public string GetCustomerById(Guid id)
        {
            return "value";
        }

        // POST api/customers
        [HttpPost(Name = "CreateNewCustomer")]
        [ProducesResponseType(typeof(CreateCustomerResponse), 201)]
        public async Task<IActionResult> CreateNewCustomer([FromBody] CreateCustomerCommand command)
        {
            var response = await _sender.Send(command);

            return CreatedAtRoute("GetCustomerById", new { id = response.CustomerId }, response);
        }

        //// PUT api/<CustomerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CustomerController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

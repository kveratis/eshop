using Application.Orders.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private const string GetByIdRoute = nameof(GetOrderById);

        private readonly ISender _sender;

        public OrdersController(ISender sender)
        {
            _sender = sender;
        }

        // GET api/orders/5
        [HttpGet("{id:guid}", Name = GetByIdRoute)]
        public string GetOrderById(Guid id)
        {
            return "value";
        }

        // POST api/orders
        [HttpPost(Name = "CreateNewOrderForCustomer")]
        [ProducesResponseType(typeof(CreateOrderResponse), 201)]
        public async Task<IActionResult> CreateNewOrderForCustomer([FromBody] Guid customerId)
        {
            var response = await _sender.Send(new CreateOrderCommand(customerId));

            if (response.Success)
            {
                return CreatedAtRoute(GetByIdRoute, new { id = response.OrderId }, response);
            }

            return new BadRequestObjectResult(response);
        }
    }
}

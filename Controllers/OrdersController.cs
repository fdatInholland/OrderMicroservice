using Application.Sevices;
using Domain.Entities;
using Domain.Entities.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            //var Email = EmailAddress.From("blaat@com");
            
            var orderId = await _orderService.CreateOrderAsync();
            return Ok(new { OrderId = orderId });
        }
    }
}

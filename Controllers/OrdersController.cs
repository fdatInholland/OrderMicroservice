using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Application.Services;


//https://dev.to/andytechdev/step-by-step-guide-testing-http-endpoints-in-visual-studio-2022-using-endpoints-explorer-fpb


namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> TakeOrderPlease()
        {
            //var Email = EmailAddress.From("blaat@com");
            
            var orderId = await _orderService.CreateOrderAsync();
            return Ok(new { OrderId = orderId });
        }
    }
}

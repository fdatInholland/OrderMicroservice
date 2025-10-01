using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Application.Services;
using OrderMicroservice.Domain.Entities;


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
        [Route("create")]
        public async Task<IActionResult> TakeOrderPlease()
        {
            var orderId = await _orderService.CreateOrderAsync();

            //better to write a product service to get product ids
            await _orderService.AddItemToOrderAsync(orderId, Guid.NewGuid(), 2, 11.99m);

            Order ord = await _orderService.getOrderById(orderId);

            return Ok(new { OrderId = orderId });
        }
    }
}

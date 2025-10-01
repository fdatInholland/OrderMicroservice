using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Application.EventDispatcher;
using OrderMicroservice.Application.Services;
using OrderMicroservice.Domain.Events;
using OrderMicroservice.Domain.Interfaces;
using OrderMicroservice.Infrastructure.Persistance;

namespace OrderMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //In-memory DB for demo
            builder.Services.AddDbContext<AppDbContext>(opt =>
                opt.UseInMemoryDatabase("OrdersDb"));

            builder.Services.AddScoped<IOrderRepsitory, OrderRepository>();
            builder.Services.AddScoped<DomainEventDispatcher>();
            builder.Services.AddScoped<IOrderService, OrderService>();
           
            builder.Services.AddScoped<IEventHandler<OrderCreatedEvent>, OrderCreatedEventHandler>();
            builder.Services.AddScoped<IEventHandler<OrderCreatedEvent>, SendEmailOnOrderCreated>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}

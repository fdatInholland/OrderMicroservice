using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Domain.Interfaces;
using OrderMicroservice.Domain.Orders;

namespace OrderMicroservice.Infrastructure.Persistance
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext _context;

        public OrderRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _context.Orders
          .Include(o => o.Items)
          .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

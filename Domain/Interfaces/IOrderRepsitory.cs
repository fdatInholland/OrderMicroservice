using OrderMicroservice.Domain.Entities;

namespace OrderMicroservice.Domain.Interfaces
{
    public interface IOrderRepsitory
    {
        Task<Order?> GetByIdAsync(Guid id);
        Task AddAsync(Order order);
        Task SaveChangesAsync();
    }
}

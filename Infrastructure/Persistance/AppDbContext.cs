using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Domain.Entities;

namespace OrderMicroservice.Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(order =>
            {
                order.HasKey(o => o.OrderId);
                order.OwnsMany(o => o.Items, oi =>
                {
                    oi.WithOwner().HasForeignKey("OrderId");
                    oi.Property<Guid>("Id");
                    oi.HasKey("Id");
                });
            });
        }
    }
}

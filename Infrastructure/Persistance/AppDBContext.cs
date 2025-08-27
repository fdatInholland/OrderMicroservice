using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OrderMicroservice.Infrastructure.Persistance
{
    public class AppDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(order =>
            {
                order.HasKey(o => o.OrderId);
                order.OwnsMany(o => o.Items, oi =>
                {
                    oi.WithOwner().HasForeignKey("OrderId");
                    oi.Property<Guid>("Id"); // Shadow primary key
                    oi.HasKey("Id");
                });
            });
        }
    }
}

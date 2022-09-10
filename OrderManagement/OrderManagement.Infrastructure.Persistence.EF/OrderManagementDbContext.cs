using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Model;
using OrderManagement.Infrastructure.Persistence.EF.Mappings;
using System;

namespace OrderManagement.Infrastructure.Persistence.EF
{
    public class OrderManagementDbContext: DbContext
    {
        
        public OrderManagementDbContext(DbContextOptions options):base(options)
        {  
        }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderItemMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Model;
using System;

namespace OrderManagement.Infrastructure.Persistence.EF
{
    public class OrderManagementDbContext: DbContext
    {
        
        public OrderManagementDbContext(DbContextOptions options):base(options)
        {  
        }
        public DbSet<Order> Orders { get; set; }
    }
}

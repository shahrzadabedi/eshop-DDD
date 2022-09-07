using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace OrderManagement.Infrastructure.Persistence.EF
{
public     class DbContextFactory
    {
        public static OrderManagementDbContext Create(string connectionString)
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlServer(connectionString).Options;
            return new OrderManagementDbContext(options);

        }
    }
}

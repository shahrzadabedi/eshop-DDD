using OrderManagement.Domain;
using OrderManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Persistence.EF.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private OrderManagementDbContext _dbContext;
        public OrderRepository(OrderManagementDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public  void Add(Order aggregate)
        {
             _dbContext.Orders.Add(aggregate);
             _dbContext.SaveChanges(); //TODO: replace with unit of work
        }

        public Order Find(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

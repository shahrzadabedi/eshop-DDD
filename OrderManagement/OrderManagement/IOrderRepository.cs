using OrderManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain
{
   public interface IOrderRepository
    {
        void Add(Order aggregate);
        Order Find(Guid id);
    }
}

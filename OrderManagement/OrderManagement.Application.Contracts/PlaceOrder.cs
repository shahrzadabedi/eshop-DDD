using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Contracts
{
    public class PlaceOrder: ICommand
    {
        public int CustomerId { get; set; }
      
        public DateTime OrderDateTime { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Contracts
{
   public  class OrderItem
    {
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string ShippingInstructions { get; set; }
    }
}

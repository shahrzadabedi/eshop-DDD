using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Model
{
    public class OrderItem : Entity<int>
    {
        public decimal Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public string Comment { get; private set; }
        public ProductId ProductId { get; private set; }
        public string ShippingInstructions { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public string ItemDescription { get; private set; }
        //TODO: inheritance
        //public PurchaseOrderItemId PurchaseOrderItemId { get; private set; } 
        //public SalesOrderItemId SalesOrderItemId { get; private set; }
        public OrderItem(decimal quantity, decimal unitPrice,string comment,
                         string  shippingInstructions,DateTime estimatedDeliveryDate, string itemDescription)
        {
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.Comment = comment;
            this.ShippingInstructions = shippingInstructions;
            this.ItemDescription = itemDescription;
            this.EstimatedDeliveryDate = estimatedDeliveryDate;
        }
    }
}

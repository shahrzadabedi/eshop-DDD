using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Model.Events
{
    public class OrderPlaced:DomainEvent
    {
        public Guid Id { get; private set; }
        public DateTime OrderDateTime { get; private set; }
        public DateTime EntryDateTime { get; private set; }
        private List<OrderItem> _orderItems = new();
        public IReadOnlyCollection<OrderItem> OrderItems { get; }
        public OrderPlaced(Guid id,DateTime orderDateTime, DateTime entryDateTime, List<OrderItem> orderItems)
        {
            this.Id = id;
            this.OrderDateTime = orderDateTime;
            this.EntryDateTime = entryDateTime;
            _orderItems.AddRange(orderItems);
        }
    }
}

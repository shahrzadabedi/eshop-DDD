using Framework.Domain;
using OrderManagement.Domain.Model;
using OrderManagement.Domain.Model.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Domain.Model

{
    public class Order : AggregateRoot<Guid>
    {
        public DateTime OrderDateTime { get; private set; }
        public DateTime EntryDateTime { get; private set; }
        private List<OrderItem> _orderItems = new();
        public IReadOnlyCollection<OrderItem> OrderItems { get { return _orderItems.AsReadOnly(); } }
        public Order(DateTime orderDateTime, DateTime entryDateTime)
        {
            Id = Guid.NewGuid();
            OrderDateTime = orderDateTime;
            EntryDateTime = entryDateTime;

        }
        public void PlaceOrderItems(List<OrderItem> orderItems)
        {
            if (orderItems == null || !orderItems.Any())
                throw new Exception();
            orderItems.ForEach(p => { if (p.Quantity == 0) throw new Exception("Quantity cannot be zero"); });
            orderItems.ForEach(p => { if (p.UnitPrice == 0) throw new Exception("Unit price cannot be zero"); });
            if (_orderItems.Count + orderItems.Count > 50)
                throw new Exception("Number of order items cannot exceed 50");
            _orderItems.AddRange(orderItems);
            Causes(new OrderPlaced(Id, OrderDateTime, EntryDateTime, OrderItems.ToList()));
        }

    }
}

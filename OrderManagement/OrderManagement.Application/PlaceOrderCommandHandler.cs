using Framework.Application;
using OrderManagement.Application.Contracts;
using OrderManagement.Domain;
using OrderManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application
{
    public class PlaceOrderHandler : ICommandHandler<PlaceOrder>
    {
        private readonly IOrderRepository _orderRepository;
        public PlaceOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public Task HandleAsync(PlaceOrder command)
        {
            throw new NotImplementedException();
        }

        void ICommandHandler<PlaceOrder>.Handle(PlaceOrder command)
        {
            var order = new Order(command.OrderDateTime, DateTime.Now);
            // TODO calculate estimated delivery date
            DateTime estimatedDeliveryDate = DateTime.Now;
            List<Domain.Model.OrderItem> orderItems = new List<Domain.Model.OrderItem>();
            command.OrderItems.ForEach(p => orderItems.Add(new Domain.Model.OrderItem(p.Quantity, p.UnitPrice, 10, p.Comment, p.ShippingInstructions, DateTime.Now, p.Description)));
            order.PlaceOrderItems(orderItems);
            _orderRepository.Add(order);

        }
    }
}

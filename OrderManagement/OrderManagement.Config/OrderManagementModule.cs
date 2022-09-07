using Autofac;
using Framework.Application;
using OrderManagement.Application;
using OrderManagement.Application.Contracts;
using OrderManagement.Domain;
using OrderManagement.Infrastructure.Persistence.EF;
using OrderManagement.Infrastructure.Persistence.EF.Repositories;
using System;

namespace OrderManagement.Config
{
    public class OrderManagementModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = "server=.; Initial Catalog=OrderManagement;User ID=sa;Password=1qaz@WSX";
            builder.RegisterType<AutofacCommandBus>()
                .As<ICommandBus>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PlaceOrderHandler>()
                .As<ICommandHandler<PlaceOrder>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .InstancePerLifetimeScope();
            builder.Register(a => DbContextFactory.Create(connectionString)).InstancePerLifetimeScope();
            //.............

            base.Load(builder);
        }
    }
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class AutofacCommandBus : ICommandBus
    {
        private readonly ILifetimeScope _scope;
        public AutofacCommandBus(ILifetimeScope scope)
        {
            _scope = scope;
        }
        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            var handler = _scope.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);

        }
        public void Dispatch<T>(T command) where T : ICommand
        {
            var handler = _scope.Resolve<ICommandHandler<T>>();
             handler.Handle(command);

        }
    }

       
    }

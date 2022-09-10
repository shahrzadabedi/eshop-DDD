using System.Threading.Tasks;

namespace Framework.Application
{
    public interface ICommandBus
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
        void Dispatch<T>(T command) where T : ICommand;
    }
}
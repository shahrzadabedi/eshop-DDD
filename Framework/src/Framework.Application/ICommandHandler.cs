using System.Threading.Tasks;

namespace Framework.Application
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
        void Handle(T command);
    }
}
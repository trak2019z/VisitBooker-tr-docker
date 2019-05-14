using MediatR;
using System.Threading.Tasks;

namespace Domain.Core.Command
{
    public interface ICommandBus
    {
        Task<TResponse> Send<TCommand, TResponse>(TCommand command) where TCommand : ICommand<TResponse>;
        Task<Unit> Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}

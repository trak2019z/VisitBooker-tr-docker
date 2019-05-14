using MediatR;
using System.Threading.Tasks;

namespace Domain.Core.Command
{
    public class CommandBus : ICommandBus
    {
        private readonly IMediator _mediator;

        public CommandBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> Send<TCommand, TResponse>(TCommand command) where TCommand : ICommand<TResponse>
        {
            return await _mediator.Send(command);
        }

        public async Task<Unit> Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            return await _mediator.Send(command);
        }
    }
}

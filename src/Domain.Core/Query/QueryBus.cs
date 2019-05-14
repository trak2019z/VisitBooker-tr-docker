using MediatR;
using System.Threading.Tasks;

namespace Domain.Core.Query
{
    public class QueryBus : IQueryBus
    {
        private readonly IMediator _mediator;

        public QueryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> Send<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>
        {
            return await _mediator.Send(query);
        }
    }
}

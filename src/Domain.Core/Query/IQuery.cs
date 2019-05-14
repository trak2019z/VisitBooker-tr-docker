using MediatR;

namespace Domain.Core.Query
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}

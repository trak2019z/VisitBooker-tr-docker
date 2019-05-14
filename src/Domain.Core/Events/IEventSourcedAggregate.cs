using Domain.Core.Aggregate;
using System.Collections.Generic;

namespace Domain.Core.Events
{
    public interface IEventSourcedAggregate : IAggregate
    {
        Queue<IEvent> PendingEvents { get; }
    }
}

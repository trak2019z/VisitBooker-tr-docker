using System;
using System.Collections.Generic;

namespace Domain.Core.Events
{
    public abstract class EventSourcedAggregate : IEventSourcedAggregate
    {
        public int Id { get; protected set; }

        public Queue<IEvent> PendingEvents { get; private set; }

        protected EventSourcedAggregate()
        {
            PendingEvents = new Queue<IEvent>();
        }

        protected void Append(IEvent @event)
        {
            PendingEvents.Enqueue(@event);
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Events
{
    public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
        where TEvent : IEvent
    {
    }
}

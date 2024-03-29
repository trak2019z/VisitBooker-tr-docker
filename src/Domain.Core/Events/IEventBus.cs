﻿using System.Threading.Tasks;

namespace Domain.Core.Events
{
    public interface IEventBus
    {
        Task Publish<TEvent>(params TEvent[] events) where TEvent : IEvent;
    }
}

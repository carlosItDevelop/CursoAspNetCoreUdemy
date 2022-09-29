using System;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.Mediators
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}

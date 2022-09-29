using MediatR;
using System;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.Mediators
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}

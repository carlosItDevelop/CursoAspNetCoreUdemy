using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Mensageria.Mediators;
using System;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.EventPublish
{
    public class PacienteSemAvaliacaoEvent : DomainEvent
    {
        public string Motivo { get; private set; }
        public Paciente Paciente { get; private set; }
        public PacienteSemAvaliacaoEvent(Guid aggregateId, Paciente paciente, string motivo) : base(aggregateId)
        {
            Motivo = motivo;
            Paciente = paciente;
        }
    }

}

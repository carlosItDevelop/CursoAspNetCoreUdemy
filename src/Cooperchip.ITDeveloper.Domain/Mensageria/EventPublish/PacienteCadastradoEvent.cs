using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Mensageria.Mediators;
using System;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.EventPublish
{
    public class PacienteCadastradoEvent : DomainEvent
    {
        public Paciente Paciente { get; private set; }
        public string Motivo { get; private set; }
        public PacienteCadastradoEvent(Guid aggregateId, Paciente paciente, string motivo) : base(aggregateId)
        {
            Paciente = paciente;
            Motivo = motivo;
        }
    }
}

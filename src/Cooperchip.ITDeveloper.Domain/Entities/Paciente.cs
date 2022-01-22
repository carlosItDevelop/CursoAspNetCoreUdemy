using Cooperchip.ITDeveloper.Domain.Entities.Audit;
using Cooperchip.ITDeveloper.Domain.Enums;
using System;

namespace Cooperchip.ITDeveloper.Domain.Entities
{
    public class Paciente : EntityAudit
    {
        public Paciente() { Ativo = true; }

        public Guid EstadoPacienteId { get; set; }
        public virtual EstadoPaciente EstadoPaciente { get; set; }

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInternacao { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string Cpf { get; set; }
        public TipoPaciente TipoPaciente { get; set; }
        public Sexo Sexo { get; set; }
        public string Rg { get; set; }
        public string RgOrgao { get; set; }
        public DateTime RgDataEmissao { get; set; }
        public string Motivo { get; set; }

        public override string ToString()
        {
            return Id.ToString() + "  -  " + Nome;
        }
    }
}

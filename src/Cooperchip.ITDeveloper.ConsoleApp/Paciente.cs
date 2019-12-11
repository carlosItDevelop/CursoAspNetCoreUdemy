using Cooperchip.ITDeveloper.Domain.Enums;

namespace Cooperchip.ITDeveloper.ConsoleApp
{
    internal class Paciente
    {
        public Paciente(string nome, int idadae)
        {
            this.Nome = nome;
            this.Idade = idadae;
        }

        public string Nome { get; private set; }
        public int Idade { get; private set; }

        public TipoMovimentoPaciente TipoMovimentoPaciente { get; set; }
        public TipoEntradaPaciente TipoEntradaPaciente { get; set; }
        public TipoSaidaPaciente TipoSaidaPaciente { get; set; }
    }
}
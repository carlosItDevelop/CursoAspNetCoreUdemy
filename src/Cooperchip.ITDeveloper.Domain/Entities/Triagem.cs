using System;

namespace Cooperchip.ITDeveloper.Domain.Entities
{
    public class Triagem : EntityBase
    {
        // Ef
        public Triagem() { }
        public Triagem(Guid codigoPaciente, string nomePaciente, DateTime dataNotificacao, string mensagem)
        {
            CodigoPaciente = codigoPaciente;
            NomePaciente = nomePaciente;
            DataNotificacao = dataNotificacao;
            Mensagem = mensagem;
        }

        public Guid CodigoPaciente { get; private set; }
        public string NomePaciente { get; private set; }
        public DateTime DataNotificacao { get; private set; }
        public string Mensagem { get; private set; }
    }
}

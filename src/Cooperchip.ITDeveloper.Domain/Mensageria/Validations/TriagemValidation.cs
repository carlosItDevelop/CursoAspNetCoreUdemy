using Cooperchip.ITDeveloper.Domain.Entities;
using FluentValidation;
using System;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.Validations
{
    public class TriagemValidation : AbstractValidator<Triagem>
    {
        public TriagemValidation()
        {
            RuleFor(x => x.Id).NotNull()
                   .WithMessage("O campo '{PropertyName}' é obrigatório.");

            RuleFor(x=>x.CodigoPaciente)
                .NotNull().WithMessage("O campo '{PropertyName}' é obrigatório.");
            
            RuleFor(x => x.Mensagem).NotNull()
                .WithMessage("O campo '{PropertyName}' é obrigatório.")
                .MaximumLength(90).WithMessage("O campo '{PropertyName}' deve ter, no máximo, '{MaxLength}' caracteres");
            
            RuleFor(x => x.DataNotificacao).NotNull().WithMessage("O campo '{PropertyName}' é obrigatório.")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("O campo {PropertyName} não pode ser registrada no futuro.");

        }
    }
}

/*
         public Guid CodigoPaciente { get; private set; }
        public string NomePaciente { get; private set; }
        public DateTime DataNotificacao { get; private set; }
        public string Mensagem { get; private set; }
 */
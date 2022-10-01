using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Mensageria.Validations.Helpers;
using FluentValidation;
using System;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.Validations
{
    public class PacienteValidation : AbstractValidator<Paciente>
    {
        public PacienteValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                    .WithMessage("O campo '{PropertyName}' precisa ser informado.")
                .NotNull()
                    .WithMessage("O campo '{PropertyName}' não pode ser Nulo.")
                .Length(2, 80)
                    .WithMessage("O campo '{PropertyName}' precisa ter entre '{MinLength}' e '{MaxLength}' caracteres.");

            RuleFor(m => m.Motivo)
                .MaximumLength(90).WithMessage("O campo '{PropertyName}' não pode ter mais que {MaxLength} caracteres.");

            RuleFor(tp => tp.TipoPaciente)
                .NotNull()
                .WithMessage("O Campo '{PropertyName}' não pode ser Nulo e nem Vazio.");

            #region: Valida Cpf
            RuleFor(c => c.Cpf.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo CPF precisa ter '{ComparisonValue}' caracteres e foi fornecido '{PropertyValue}'.");

            RuleFor(v => CpfValidacao.Validar(v.Cpf)).Equal(true)
                .WithMessage("O CPF fornecido é inválido.");
            #endregion

            #region: RG
            RuleFor(rg => rg.Rg)
                .MaximumLength(15).WithMessage("O campo '{PropertyName}' não pode ter mais que {MaxLength} caracteres.");
            RuleFor(rg => rg.RgOrgao)
                .MaximumLength(10).WithMessage("O campo '{PropertyName}' não pode ter mais que {MaxLength} caracteres.");
            RuleFor(rg => rg.Rg)
                .MaximumLength(15).WithMessage("O campo '{PropertyName}' não pode ter mais que {MaxLength} caracteres.");

            RuleFor(dt => dt.RgDataEmissao)
                .GreaterThanOrEqualTo(d => d.DataNascimento).WithMessage("Um paciente não pode ser registrado antes de ter nascido.");

            RuleFor(dt => dt.RgDataEmissao).Must(BeDateTime)
                .WithMessage("A data informada é inválida");
            #endregion

            #region: Data de Nascimento
            RuleFor(dt => dt.DataNascimento)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("O campo {PropertyName} não pode ser registrada no futuro.");

            RuleFor(dt => dt.DataNascimento)
                .LessThan(DateTime.Now.AddYears(150))
                .WithMessage("O campo {PropertyName} não deve ser maior que 150 anos.");

            RuleFor(dt => dt.DataNascimento).Must(BeDateTime)
                .WithMessage("A data informada é inválida");
            #endregion

            #region: Data de Internação
            RuleFor(dt => dt.DataInternacao)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("O campo {PropertyName} não pode ser registrada no futuro.");

            RuleFor(dt => dt.DataInternacao)
                .GreaterThanOrEqualTo(d => d.DataNascimento).WithMessage("Um paciente não pode ser cadastrado antes de ter nascido.");

            RuleFor(dt => dt.DataInternacao).Must(BeDateTime)
                .WithMessage("A data informada é inválida");
            #endregion

            #region: Estado do Paciente
            RuleFor(n => n.EstadoPacienteId)
                .NotNull().WithMessage("O campo {PropertyName} não pode ser nulo.");
            #endregion
        }

        // Escrever esta função de data ou achar na web;
        private bool BeDateTime(DateTime arg)
        {
            return true;
            //return arg.Equals(default(DateTime));
        }
    }
}

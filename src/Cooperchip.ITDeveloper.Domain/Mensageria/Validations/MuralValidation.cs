using Cooperchip.ITDeveloper.Domain.Entities;
using FluentValidation;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.Validations
{
    public class MuralValidation : AbstractValidator<Mural>
    {
        /// <summary>
        /// Todo: RegularExpression to Email Field and more Validation to Data
        /// </summary>
        public MuralValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("O campo '{PropertyName}' é obrigatório!");

            RuleFor(x => x.Data).NotNull().WithMessage("O campo '{PropertyName}' é obrigatório!");

            RuleFor(n => n.Titulo)
                .NotEmpty().WithMessage("O campo '{PropertyName}' precisa ser informado.")
                .Length(5, 30).WithMessage("O campo '{PropertyName}' precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(n => n.Aviso)
                .NotEmpty().WithMessage("O campo '{PropertyName}' precisa ser informado.")
                .Length(3, 135).WithMessage("O campo '{PropertyName}' precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(n => n.Autor)
                .NotEmpty().WithMessage("O campo '{PropertyName}' precisa ser informado.")
                .Length(2, 28).WithMessage("O campo '{PropertyName}' precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(n => n.Email)
                .NotEmpty().WithMessage("O campo '{PropertyName}' precisa ser informado.")
                .Length(5, 255).WithMessage("O campo '{PropertyName}' precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}

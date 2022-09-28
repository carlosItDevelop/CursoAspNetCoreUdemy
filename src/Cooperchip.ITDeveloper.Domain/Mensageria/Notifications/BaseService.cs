using Cooperchip.ITDeveloper.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.Notifications
{
    public abstract class BaseService
    {
        private readonly INotificador _notification;
        protected BaseService(INotificador notification) => _notification = notification;
      
        protected void Notificar(ValidationResult validationResult) 
        {
            foreach (var erro in validationResult.Errors) Notificar(erro.ErrorMessage);            
        }
        protected void Notificar(string mensagem) => _notification.Handle(new Notificacao(mensagem));
      
        protected bool ExecutarValidacao<TVal, T>(TVal validacao, T entidade) where TVal : AbstractValidator<T> where T : EntityBase
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid) return true;

            Notificar(validator);
            return false;
        }

    }
}

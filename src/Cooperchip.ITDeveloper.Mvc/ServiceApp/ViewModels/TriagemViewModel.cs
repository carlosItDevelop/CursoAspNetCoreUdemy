using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Cooperchip.ITDeveloper.Mvc.ServiceApp.ViewModels
{
    public class TriagemViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Código do Paciene")]
        public Guid CodigoPaciente { get; set; }

        [StringLength(90, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome")]
        public string NomePaciente { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Data Inválida.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Data")]
        public DateTime DataNotificacao { get; set; }

        [StringLength(90, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Mensagem")]
        public string Mensagem { get; set; }
    }
}

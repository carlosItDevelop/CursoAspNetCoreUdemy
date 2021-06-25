using Cooperchip.ITDeveloper.Domain.Enums;
using Cooperchip.ITDeveloper.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.ITDeveloper.Application.ViewModels
{
    public class PacienteViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [ForeignKey("EstadoPaciente")]
        [Display(Name = "Estado do Paciente")]
        public Guid EstadoPacienteId { get; set; }
        public virtual EstadoPaciente EstadoPaciente { get; set; }


        [DisplayName(displayName: "Nome do Paciente")]
        [StringLength(maximumLength: 80, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }


        [DisplayName(displayName: "Data Nascimento")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data Inválida.")]
        public DateTime DataNascimento { get; set; }


        [DisplayName(displayName: "Data Internação")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data Inválida.")]
        public DateTime DataInternacao { get; set; }


        [DisplayName(displayName: "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Inválido.")]
        public string Email { get; set; }

        public bool Ativo { get; set; }


        [DisplayName(displayName: "CPF")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        [StringLength(11, ErrorMessage = "Campo {0} tem de ter {1} caracteres", MinimumLength = 11)]
        public string Cpf { get; set; }

        [DisplayName(displayName: "Tipo de Paciente")]
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        public TipoPaciente TipoPaciente { get; set; }

        [DisplayName(displayName: "Sexo")]
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        public Sexo Sexo { get; set; }

        [DisplayName(displayName: "Sexo")]
        [MaxLength(15, ErrorMessage = "O campo {0} não pode ter mais que (1) caracteres.")]
        public string Rg { get; set; }

        [DisplayName(displayName: "Org.Expedidor")]
        [MaxLength(10, ErrorMessage = "O campo {0} não pode ter mais que (1) caracteres.")]
        public string RgOrgao { get; set; }

        [DisplayName(displayName: "Data Emissão")]
        [Required(ErrorMessage = "Campo {0} é requerido.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data Inválida.")]
        public DateTime RgDataEmissao { get; set; }


        [MaxLength(90, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Motivo { get; set; }


        public override string ToString()
        {
            return this.Id.ToString() + "  -  " + this.Nome;
        }
    }
}

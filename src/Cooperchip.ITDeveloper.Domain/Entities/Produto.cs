
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cooperchip.ITDeveloper.Domain.Entities
{
    public class Produto
    {
        public Produto()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        [Display(Name = "Id do Produto")]
        public Guid Id { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(80,ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Range(0, 4000, ErrorMessage = "O campo {0} deve estar entre {1} e {2} reais.")]
        public decimal Valor { get; set; } = 0;

        public int Estoque { get; set; }

        [Display(Name = "Data de Validade", Description = "Selecione uma data atual ou passada para o cadastro!")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime Validade { get; set; }
        public bool TemEmEstoque { get; set; } = true;

    }
}

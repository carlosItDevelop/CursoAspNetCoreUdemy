using Cooperchip.ITDeveloper.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cooperchip.ITDeveloper.Mvc.ViewModels
{
    public class CarrinhoViewModel
    {
        public IList<Produto> Produtos { get; set; }

        [Required]
        [Range(50, 4000, ErrorMessage = "O campo {0} deve estar entre {1} e {2}")]
        public decimal TotalCarrinho { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 4)]
        public string Mensagem { get; set; }
    }
}

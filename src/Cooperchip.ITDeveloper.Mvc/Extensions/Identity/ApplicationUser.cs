using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cooperchip.ITDeveloper.Mvc.Extensions.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(maximumLength:35, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres!", MinimumLength = 2)]
        public string Apelido { get; set; }
        
        [PersonalData]
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(maximumLength: 80, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres!", MinimumLength = 2)]
        public string NomeCompleto { get; set; }
        
        [PersonalData]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [ProtectedPersonalData]
        [DataType(DataType.Text)]
        [StringLength(maximumLength:255, ErrorMessage = "O campo {0} deve ter entre {2} e{1} caracteres", MinimumLength = 21)]
        public string ImgProfilePath { get; set; }

    }
}
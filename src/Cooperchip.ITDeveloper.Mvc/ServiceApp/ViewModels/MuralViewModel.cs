using System;
using System.ComponentModel.DataAnnotations;

namespace Cooperchip.ITDeveloper.Mvc.ServiceApp.ViewModels
{
    public class MuralViewModel
    {
        /*
            <small>12:03:28 12-04-2014</small>
            <h4>Long established fact</h4>
            <p>The years, sometimes by accident, sometimes on purpose (injected humour and the like).</p>
            <h6>Por: Carlos Alberto dos Santos</h6>
            <a href="#"><i class="fa fa-trash-o "></i></a>
        */

        [Key]
        public Guid Id { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data Inválida!")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Display(Name = "Título do PostIt")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(30, ErrorMessage = "Máximo de caractere permitido: 30")]
        [MinLength(5, ErrorMessage = "Mínimo de caractere permitido: 5")]
        public string Titulo { get; set; }

        [Display(Name = "Aviso")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(135, ErrorMessage = "Máximo de caractere permitido: 135")]
        [MinLength(3, ErrorMessage = "Mínimo de caractere permitido: 3")]
        public string Aviso { get; set; }

        [Required(ErrorMessage = "Autor é campo Obrigatório")]
        [MaxLength(28, ErrorMessage = "Máximo de caractere permitido: 28")]
        [MinLength(2, ErrorMessage = "Mínimo de caractere permitido: 2")]
        public string Autor { get; set; }

        [MaxLength(300, ErrorMessage = "Máximo de caracter permitido: 300")]
        public string Email { get; set; }

        public override string ToString()
        {
            return this.Aviso + " - " + this.Autor;
        }

    }
}


using System;

namespace Cooperchip.ITDeveloper.Domain.Entities
{
    public class Mural : EntityBase
    {
        // Ef 
        public Mural() { }
        public Mural(DateTime data, string titulo, string autor, string email)
        {
            Data = data;
            Titulo = titulo;
            Autor = autor;
            Email = email;
            Aviso = "";
        }

        public DateTime Data { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string Email { get; private set; }

        public string Aviso { get; set; }

        public override string ToString()
        {
            return this.Aviso + " - " + this.Autor;
        }
    }
}


using Cooperchip.ITDeveloper.Domain.Entities;

namespace Cooperchip.ITDeveloper.Domain.Models
{
    public class Generico : EntityBase
    {
        public Generico()
        {

        }

        public int Codigo { get; set; }
        public string Nome { get; set; }

    }
}

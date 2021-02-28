using System;

namespace Cooperchip.ITDeveloper.Domain.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        // DataCadastro
        // DataModificacao
        // UserChange


        // var m = new Maca
        // maçã => id = 1
        // Outra maçã => id <> 1 <> Limão


    }
}

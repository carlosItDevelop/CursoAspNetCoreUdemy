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

        // Criar Comparações entre entidades


        // -------------------------------------- Para refletir
        // Maca = OutraMaca ????

        // maca = new Maca()  => Instancia de uma Maca

        // Pessoa xpto = new {id=1, nome=Carlos, cpf=38487432943};
        // Pessoa xpto2 = new {id=2, nome=Marcos, cpf=77487432943};


    }
}

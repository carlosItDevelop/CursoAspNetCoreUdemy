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

    }
}

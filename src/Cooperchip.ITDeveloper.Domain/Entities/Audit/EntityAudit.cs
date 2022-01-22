using System;

namespace Cooperchip.ITDeveloper.Domain.Entities.Audit
{
    public abstract class EntityAudit : EntityBase, IAuditable
    {
        public EntityAudit(){}

        public DateTime? DataInclusao { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime? DataUltimaModificacao { get; set; }
        public string UsuarioUltimaModificacao { get; set; }
    }
}

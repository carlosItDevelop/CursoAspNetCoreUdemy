using System;

namespace Cooperchip.ITDeveloper.Domain.Entities.Audit
{
    public interface IAuditableUpd
    {
        DateTime? DataUltimaModificacao { get; set; }
        string UsuarioUltimaModificacao { get; set; }
    }
}

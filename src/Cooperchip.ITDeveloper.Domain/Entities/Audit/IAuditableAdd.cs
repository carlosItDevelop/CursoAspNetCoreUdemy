using System;

namespace Cooperchip.ITDeveloper.Domain.Entities.Audit
{
    public interface IAuditableAdd
    {
        DateTime? DataInclusao { get; set; }
        string UsuarioInclusao { get; set; }
    }
}

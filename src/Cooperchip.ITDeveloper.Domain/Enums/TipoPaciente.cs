using System.ComponentModel;

namespace Cooperchip.ITDeveloper.Domain.Enums
{
    public enum TipoPaciente
    {
        [Description("Conveniado")] Conveniado = 1,
        [Description("Particular")] Particular,
        [Description("Outros")] Outros
    }
}

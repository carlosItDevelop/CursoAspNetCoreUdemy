using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.Mediators
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }

}

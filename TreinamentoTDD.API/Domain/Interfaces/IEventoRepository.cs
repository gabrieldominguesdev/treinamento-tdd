using System.Linq.Expressions;
using TreinamentoTDD.API.Domain.Entities;

namespace TreinamentoTDD.API.Domain.Interfaces
{
    public interface IEventoRepository
    {
        void CriarEventos(IEnumerable<Evento> eventos);
        void AtualizarEventos(IEnumerable<Evento> eventos);
        void ExcluirEventos(IEnumerable<Evento> eventos);
        Evento RecuperarEventoPorId(Guid id);
        IEnumerable<Evento> RecuperarTodosOsEventos();
        IEnumerable<Evento> RecuperarEventos(Expression<Func<Evento, bool>> condicoes);
    }
}

using System.Linq.Expressions;
using TreinamentoTDD.API.Domain.Entities;
using TreinamentoTDD.API.Domain.Interfaces;

namespace TreinamentoTDD.API.Infra.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly TreinamentoTDDContext _context;
        public EventoRepository(TreinamentoTDDContext context)
        {
            _context = context;
        }

        public void CriarEventos(IEnumerable<Evento> eventos)
        {
            _context.Eventos.AddRange(eventos);
            _context.SaveChanges();
        }

        public void AtualizarEventos(IEnumerable<Evento> eventos)
        {
            _context.Eventos.UpdateRange(eventos);
            _context.SaveChanges();
        }

        public void ExcluirEventos(IEnumerable<Evento> eventos)
        {
            _context.Eventos.RemoveRange(eventos);
            _context.SaveChanges();
        }

        public Evento RecuperarEventoPorId(Guid id)
        {
            return _context.Eventos.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Evento> RecuperarTodosOsEventos()
        {
            return _context.Eventos.ToList();
        }

        public IEnumerable<Evento> RecuperarEventos(Expression<Func<Evento, bool>> condicoes)
        {
            return _context.Eventos.Where(condicoes);
        }
    }
}

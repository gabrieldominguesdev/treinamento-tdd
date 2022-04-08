using TreinamentoTDD.API.Domain.Commands;
using TreinamentoTDD.API.Domain.Entities;
using TreinamentoTDD.API.Domain.Interfaces;

namespace TreinamentoTDD.API.Domain.Handlers
{
    public class CadastraEventoHandler
    {
        private readonly IEventoRepository _repository;
        public CadastraEventoHandler(IEventoRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Execute(CadastraEvento command)
        {
            try
            {
                var evento = new Evento
                (
                    id: Guid.NewGuid(),
                    nome: command.Nome,
                    data: command.Data
                );
                _repository.CriarEventos(new[] { evento });
                return new OperationResult(success: true);
            }
            catch (Exception e)
            {
                return new OperationResult(success: false);
            }
        }
    }
}

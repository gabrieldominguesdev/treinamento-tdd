using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreinamentoTDD.API.Domain.Commands;
using TreinamentoTDD.API.Domain.Handlers;
using TreinamentoTDD.API.Domain.Interfaces;
using TreinamentoTDD.API.Model;

namespace TreinamentoTDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _repository;
        public EventoController(IEventoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult CadastrarEvento(CadastraEventoModel model)
        {
            var eventoEntity = _repository.RecuperarEventos(x => x.Nome == model.Nome).FirstOrDefault();
            if (eventoEntity != null)
                return StatusCode(500, "Evento já existente no banco de dados");

            var command = new CadastraEvento(model.Nome, model.Data);
            var handler = new CadastraEventoHandler(_repository);
            var result = handler.Execute(command);
            if (result.IsSuccessful) return Ok();
            return StatusCode(500);
        }
    }
}

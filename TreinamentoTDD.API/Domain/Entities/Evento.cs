namespace TreinamentoTDD.API.Domain.Entities
{
    public class Evento
    {
        public Evento(Guid id, string nome, DateTime data)
        {
            Id = id;
            Nome = nome;
            Data = data;
            Status = data >= DateTime.Now ? EventoStatus.Pendente : EventoStatus.Concluido;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public EventoStatus Status { get; set; }
    }

    public enum EventoStatus
    {
        Pendente,
        Concluido,
    }
}

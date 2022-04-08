namespace TreinamentoTDD.API.Domain.Commands
{
    public class CadastraEvento
    {
        public CadastraEvento(string nome, DateTime data)
        {
            Nome = nome;
            Data = data;
        }

        public string Nome { get; set; }
        public DateTime Data { get; set; }
    }
}

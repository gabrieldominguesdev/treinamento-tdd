using Microsoft.EntityFrameworkCore;
using TreinamentoTDD.API.Domain.Entities;

namespace TreinamentoTDD.API.Infra
{
    public class TreinamentoTDDContext : DbContext
    {
        public TreinamentoTDDContext(DbContextOptions options) : base(options)
        {
        }

        public TreinamentoTDDContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            //Use SQLServer
        }

        public DbSet<Evento> Eventos { get; set; }
    }
}

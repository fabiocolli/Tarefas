using Dados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Dados.Config
{
    public class ContextoBase : DbContext
    {
        public ContextoBase(DbContextOptions<ContextoBase> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(PegarStringConexao());

                base.OnConfiguring(optionsBuilder);
            }
        }

        public string PegarStringConexao()
        {
            return "Data Source=fc-p\\local;Initial Catalog=Tarefas;Persist Security Info=True;User ID=sa;Password=qM1t$up|iC74;TrustServerCertificate=True";
        }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<ItemTarefa> ItensTarefas { get; set; }
    }
}

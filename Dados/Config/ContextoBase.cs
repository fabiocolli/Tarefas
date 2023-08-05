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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        //    modelBuilder.Properties<string>()
        //        .Configure(p => p.HasColumnType("varchar"));

        //    modelBuilder.Properties<string>()
        //        .Configure(p => p.HasMaxLength(100));

        //    modelBuilder.Configurations.Add(new ConfiguracaoPessoa());
        //    modelBuilder.Configurations.Add(new ConfiguracaoLivro());
        //    modelBuilder.Configurations.Add(new ConfiguracaoItenEmprestado());
        //}

        public string PegarStringConexao()
        {
            return "Data Source=fc-p\\local;Initial Catalog=Tarefas;Persist Security Info=True;User ID=sa;Password=qM1t$up|iC74;TrustServerCertificate=True";
        }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<ItemTarefa> ItensTarefas { get; set; }
    }
}

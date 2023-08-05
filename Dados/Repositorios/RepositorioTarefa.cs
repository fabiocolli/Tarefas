using Dados.Config;
using Dados.Entidades;
using Dados.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dados.Repositorios
{
    public class RepositorioTarefa : RepositorioBase<Tarefa>, ITarefa
    {
        private readonly DbContextOptions<ContextoBase> _dbContextOptions;

        public RepositorioTarefa()
        {
            _dbContextOptions = new DbContextOptions<ContextoBase>();
        }

        public async Task<Tarefa> BuscarTarefaComSeusItensPeloId(int idTarefa)
        {
            using (var data = new ContextoBase(_dbContextOptions))
            {
                var tarefaCompleta = await data.Tarefas.FindAsync(idTarefa);

                if (tarefaCompleta != null)
                {
                    tarefaCompleta.ItensTarefas = await data.ItensTarefas
                                                        .Where(it => it.Tarefa.Id == idTarefa)
                                                        .ToListAsync();
                    return tarefaCompleta;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<IEnumerable<Tarefa>> BuscarTarefaNomeAproximado(string nome)
        {
            using (var data = new ContextoBase(_dbContextOptions))
            {
                return await data.Tarefas
                    .Where(t => t.Nome.Contains(nome))
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<Tarefa>> BuscarTodasTarefasComOsItens()
        {
            using (var data = new ContextoBase(_dbContextOptions))
            {
                var tarefas = await data.Tarefas.ToListAsync();
                var itensDaTarefa = await data.ItensTarefas.ToListAsync();
                var tarefasComDistinct = tarefas.Select(t => new { t.Id, NomeTarefa = t.Nome }).Distinct().ToList();

                return tarefasComDistinct.Select(t => new Tarefa
                {
                    Id = t.Id,
                    Nome = t.NomeTarefa,
                    ItensTarefas = itensDaTarefa.Where(it => it.Tarefa.Id == t.Id)
                    .Select(it => new ItemTarefa
                    {
                        Id = it.Id,
                        Nome = it.Nome,
                        DataPrevistaFim = it.DataPrevistaFim,
                        Observacao = it.Observacao,
                    }).ToList()
                });
            }
        }
    }
}

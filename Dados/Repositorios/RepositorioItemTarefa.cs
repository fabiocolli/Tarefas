using Dados.Config;
using Dados.Entidades;
using Dados.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dados.Repositorios
{
    public class RepositorioItemTarefa : RepositorioBase<ItemTarefa>, IItemTarefa
    {
        private readonly DbContextOptions<ContextoBase> _dbContextOptions;

        public RepositorioItemTarefa()
        {
            _dbContextOptions = new DbContextOptions<ContextoBase>();
        }
        public async Task<IEnumerable<ItemTarefa>> BuscarItemTarefaNomeAproximado(string busca)
        {
            using (var data = new ContextoBase(_dbContextOptions))
            {
                return await data.ItensTarefas.Where(it => it.Nome.Contains(busca)).ToListAsync();
            }
        }

        public async Task<IEnumerable<ItemTarefa>> BuscarItemTarefaPeloIdTarefa(int idTarefa)
        {
            using (var data = new ContextoBase(_dbContextOptions))
            {
                return await data.ItensTarefas.Where(it => it.Tarefa.Id == idTarefa).ToListAsync();
            }
        }
    }
}

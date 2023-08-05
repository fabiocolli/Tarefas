using Dados.Entidades;
using Dados.Interfaces;

namespace Dados.Repositorios
{
    public class RepositorioItemTarefa : RepositorioBase<ItemTarefa>, IItemTarefa
    {
        public Task<IEnumerable<ItemTarefa>> BuscarItemTarefaNomeAproximado()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemTarefa>> OrdenarPorDataFimParaInicio()
        {
            throw new NotImplementedException();
        }
    }
}

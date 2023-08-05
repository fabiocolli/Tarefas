using Dados.Entidades;

namespace Dados.Interfaces
{
    public interface IItemTarefa : IRepositorio<ItemTarefa>
    {
        Task<IEnumerable<ItemTarefa>> OrdenarPorDataFimParaInicio();
        Task<IEnumerable<ItemTarefa>> BuscarItemTarefaNomeAproximado();
    }
}

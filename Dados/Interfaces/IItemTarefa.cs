using Dados.Entidades;

namespace Dados.Interfaces
{
    public interface IItemTarefa : IRepositorio<ItemTarefa>
    {
        Task<IEnumerable<ItemTarefa>> BuscarItemTarefaNomeAproximado(string busca);
        Task<IEnumerable<ItemTarefa>> BuscarItemTarefaPeloIdTarefa(int idTarefa);
    }
}

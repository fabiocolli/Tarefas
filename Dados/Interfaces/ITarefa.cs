using Dados.Entidades;

namespace Dados.Interfaces
{
    public interface ITarefa : IRepositorio<Tarefa>
    {
        Task<IEnumerable<Tarefa>> BuscarTarefaNomeAproximado(string nome);
        Task<Tarefa> BuscarTarefaComSeusItensPeloId(int id);
        Task<IEnumerable<Tarefa>> BuscarTodasTarefasComOsItens();
    }
}

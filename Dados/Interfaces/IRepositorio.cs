namespace Dados.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task Adicionar(T objeto);
        Task Atualizar(T objeto);
        Task Excluir(T objeto);
        Task<T> BuscarPeloId(int id);
        Task<List<T>> ListarTudo();
    }
}

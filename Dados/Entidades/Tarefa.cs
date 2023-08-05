namespace Dados.Entidades
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public virtual IEnumerable<ItemTarefa> ItensTarefas { get; set; } = new List<ItemTarefa>();
    }
}

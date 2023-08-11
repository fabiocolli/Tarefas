namespace Dados.Entidades
{
    public class ItemTarefa
    {
        public int Id { get; set; }
        public virtual Tarefa Tarefa { get; set; }
        public string Nome { get; set; }
        public DateTime DataPrevistaFim { get; set; }
        public string? Observacao { get; set; }
    }
}

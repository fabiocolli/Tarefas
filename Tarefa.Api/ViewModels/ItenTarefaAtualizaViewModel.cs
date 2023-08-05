namespace Web.Api.ViewModels
{
    public class ItenTarefaAtualizaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataPrevistaFim { get; set; }
        public string? Observacao { get; set; }
    }
}

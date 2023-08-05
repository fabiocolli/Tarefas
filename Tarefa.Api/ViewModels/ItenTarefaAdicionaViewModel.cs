using Dados.Entidades;

namespace Web.Api.ViewModels
{
    public class ItenTarefaAdicionaViewModel
    {
        public int TarefaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataPrevistaFim { get; set; }
        public string? Observacao { get; set; }
    }
}

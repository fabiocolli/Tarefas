using Dados.Entidades;

namespace Web.Api.ViewModels
{
    public class TarefaViewModel
    {
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public virtual IEnumerable<ItemTarefaViewModel> ItensTarefas { get; set; }
    }
}

using AutoMapper;
using Dados.Entidades;
using Dados.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Api.ViewModels;

namespace Web.Api.Controllers
{
    [Route("api/ItemTarefa")]
    [ApiController]
    public class ItenTarefaController : ControllerBase
    {
        public readonly IItemTarefa _itemTarefa;
        public readonly IMapper _mapeador;

        public ItenTarefaController(IItemTarefa itemTarefa, IMapper mapper)
        {
            _itemTarefa = itemTarefa;
            _mapeador = mapper;
        }

        [HttpPost("/AdicionarItemTarefa")]
        public async Task AdicionarItemTarefa(ItemTarefaViewModel itemTarefa)
        {
            await _itemTarefa.Adicionar(_mapeador.Map<ItemTarefa>(itemTarefa));
        }

        [HttpPost("/AtualizarItemTarefa")]
        public async Task AtualizarItemTarefa(ItenTarefaAtualizaViewModel itemTarefa)
        {
            await _itemTarefa.Atualizar(_mapeador.Map<ItemTarefa>(itemTarefa));
        }

        [HttpPost("/ExcluirItemTarefa")]
        public async Task ExcluirItemTarefa(ItemTarefaViewModel itemTarefa)
        {
            await _itemTarefa.Excluir(_mapeador.Map<ItemTarefa>(itemTarefa));
        }

        [HttpGet("/BuscarPeloId")]
        public async Task<ItemTarefaViewModel> BuscarPeloId(int id)
        {
            return _mapeador.Map<ItemTarefaViewModel>(await _itemTarefa.BuscarPeloId(id));
        }

        [HttpGet("/BuscarTodosOsItensDaTarefa")]
        public async Task<List<ItemTarefaViewModel>> BuscarTodosOsItensDaTarefa()
        {
            return _mapeador.Map<List<ItemTarefaViewModel>>(await _itemTarefa.ListarTudo());
        }
    }
}

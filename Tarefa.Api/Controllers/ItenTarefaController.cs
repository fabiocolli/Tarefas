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
        public async Task AdicionarItemTarefa(ItenTarefaAdicionaViewModel itemTarefa)
        {
            await _itemTarefa.Adicionar(_mapeador.Map<ItemTarefa>(itemTarefa));
        }



        [HttpPost("/AtualizarItemTarefa")]
        public async Task AtualizarItemTarefa(ItenTarefaAtualizaViewModel itemTarefa)
        {
            await _itemTarefa.Atualizar(_mapeador.Map<ItemTarefa>(itemTarefa));
        }

        [HttpPost("/ExcluirItemTarefa")]
        public async Task ExcluirItemTarefa(ItenTarefaExcluirViewModel itemTarefa)
        {
            await _itemTarefa.Excluir(_mapeador.Map<ItemTarefa>(itemTarefa));
        }

        [HttpGet("/BuscarPeloId")]
        public async Task<ItemTarefaViewModel> BuscarPeloId(int id)
        {
            return _mapeador.Map<ItemTarefaViewModel>(await _itemTarefa.BuscarPeloId(id));
        }

        [HttpGet("/ListarTodosOsItensDeTarefa")]
        public async Task<IEnumerable<ItenTarefaTodasViewModel>> ListarTodosOsItensDeTarefa()
        {
            return _mapeador.Map<IEnumerable<ItenTarefaTodasViewModel>>(await _itemTarefa.ListarTudo());
        }

        [HttpGet("/ListarItenDeUmaTarefaPeloIdTarefa")]
        public async Task<IEnumerable<ItenTarefaTodasViewModel>> ListarItenDeUmaTarefaPeloIdTarefa(int idTarefa)
        {
            return _mapeador.Map<IEnumerable<ItenTarefaTodasViewModel>>
                (await _itemTarefa.BuscarItemTarefaPeloIdTarefa(idTarefa));
        }
    }
}

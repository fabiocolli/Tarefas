using AutoMapper;
using Dados.Entidades;
using Dados.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Api.ViewModels;

namespace Web.Api.Controllers
{
    [Route("api/Tarefa")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        public readonly ITarefa _tarefa;
        public readonly IMapper _mapeador;

        public TarefaController(ITarefa tarefa, IMapper mapeador)
        {
            _tarefa = tarefa;
            _mapeador = mapeador;
        }

        [HttpPost("/Adicionar")]
        public async Task AdicionarTarefa(TarefaViewModel tarefa)
        {
            await _tarefa.Adicionar(_mapeador.Map<Tarefa>(tarefa));
        }

        [HttpPut("/AtualizarTarefa")]
        public async Task AtualizarTarefa(TarefaAtualizarViewModel tarefa)
        {
            await _tarefa.Atualizar(_mapeador.Map<Tarefa>(tarefa));
        }

        [HttpDelete("/Excluir")]
        public async Task Excluir(int id)
        {
            await _tarefa.Excluir(new Tarefa { Id = id });
        }

        [HttpGet("/BuscarTarefaPeloId")]
        public async Task<TarefaPeloIdViewModel> BuscarTarefa(int id)
        {
            return _mapeador.Map<TarefaPeloIdViewModel>(await _tarefa.BuscarPeloId(id));

        }

        [HttpGet("/ListarTarefas")]
        public async Task<IEnumerable<TarefaViewModel>> ListarTarefas()
        {
            return _mapeador.Map<IEnumerable<TarefaViewModel>>(await _tarefa.BuscarTodasTarefasComOsItens());
        }
    }
}

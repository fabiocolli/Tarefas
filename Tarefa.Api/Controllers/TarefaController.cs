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

        public TarefaController(ITarefa tarefa, IMapper mapper)
        {
            _tarefa = tarefa;
            _mapeador = mapper;
        }

        [HttpPost("/AdicionarTarefa")]
        public async Task AdicionarTarefa(TarefaViewModel tarefa)
        {
            var tarefaMapeada = _mapeador.Map<Tarefa>(tarefa);

            await _tarefa.Adicionar(tarefaMapeada);
        }

        [HttpPost("/Excluir")]
        public async Task Excluir(int id)
        {
            await _tarefa.Excluir(new Tarefa { Id = id });
        }

        [HttpGet("/BuscarTarefa")]
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

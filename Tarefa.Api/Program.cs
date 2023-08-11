using AutoMapper;
using Dados.Config;
using Dados.Entidades;
using Dados.Interfaces;
using Dados.Repositorios;
using Microsoft.EntityFrameworkCore;
using Web.Api.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextoBase>
    (options => options.UseSqlServer("Data Source=fc-p\\local;Initial Catalog=Tarefas;Persist Security Info=True;User ID=sa;Password=qM1t$up|iC74;TrustServerCertificate=True"));

builder.Services.AddSingleton(typeof(IRepositorio<>), typeof(RepositorioBase<>));
builder.Services.AddSingleton<ITarefa, RepositorioTarefa>();
builder.Services.AddSingleton<IItemTarefa, RepositorioItemTarefa>();

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Tarefa, TarefaViewModel>();
    cfg.CreateMap<TarefaViewModel, Tarefa>();

    cfg.CreateMap<ItemTarefa, ItemTarefaViewModel>();
    cfg.CreateMap<ItemTarefaViewModel, ItemTarefa>();

    cfg.CreateMap<TarefaPeloIdViewModel, Tarefa>();
    cfg.CreateMap<Tarefa, TarefaPeloIdViewModel>();

    cfg.CreateMap<ItenTarefaAtualizaViewModel, ItemTarefa>();
    cfg.CreateMap<ItemTarefa, ItenTarefaAtualizaViewModel>();

    cfg.CreateMap<ItenTarefaAdicionaViewModel, ItemTarefa>();
    cfg.CreateMap<ItemTarefa, ItenTarefaAdicionaViewModel>();

    cfg.CreateMap<ItenTarefaExcluirViewModel, ItemTarefa>();
    cfg.CreateMap<ItemTarefa, ItenTarefaExcluirViewModel>();

    cfg.CreateMap<ItenTarefaTodasViewModel, ItemTarefa>();
    cfg.CreateMap<ItemTarefa, ItenTarefaTodasViewModel>();

    cfg.CreateMap<TarefaAtualizarViewModel, Tarefa>();
    cfg.CreateMap<Tarefa, TarefaAtualizarViewModel>();
});

IMapper mapeador = config.CreateMapper();
builder.Services.AddSingleton(mapeador);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

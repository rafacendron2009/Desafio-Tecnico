using Microsoft.EntityFrameworkCore;
using Tarefas.Business.Imp.Service;
using Tarefas.Business.IService;
using Tarefas.Repository.Imp.Context;
using Tarefas.Repository.Imp.Repositories;
using Tarefas.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ITarefaServices, TarefaServices>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

builder.Services.AddDbContext<TarefasContext>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Entities.Entities;

namespace Tarefas.Business.IService
{
    public interface ITarefaServices
    {
        Task<IEnumerable<Tarefa>> GetTarefaAsync();
        Task<Tarefa> GetTarefaAsync(int id);
        Task CreateTarefaAsync(Tarefa task);
        Task UpdateTarefaAsync(Tarefa task);
        Task DeleteTarefaAsync(int id);
    }
}

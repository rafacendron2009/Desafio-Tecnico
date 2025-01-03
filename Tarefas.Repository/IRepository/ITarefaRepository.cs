using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Entities.Entities;

namespace Tarefas.Repository.IRepository
{

    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetAllAsync();
        Task<Tarefa> GetByIdAsync(int id);
        Task AddAsync(Tarefa task);
        Task UpdateAsync(Tarefa task);
        Task DeleteAsync(int id);
    }
}

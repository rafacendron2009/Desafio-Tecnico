using Microsoft.EntityFrameworkCore;
using Tarefas.Entities.Entities;
using Tarefas.Repository.Imp.Context;
using Tarefas.Repository.IRepository;

namespace Tarefas.Repository.Imp.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TarefasContext _context;

        public TarefaRepository(TarefasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync() =>
            await _context.Tarefas.ToListAsync();

        public async Task<Tarefa> GetByIdAsync(int id) =>
            await _context.Tarefas.FindAsync(id);

        public async Task AddAsync(Tarefa task)
        {
            _context.Tarefas.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tarefa task)
        {
            _context.Tarefas.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await GetByIdAsync(id);
            if (task != null)
            {
                _context.Tarefas.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
using Tarefas.Business.IService;
using Tarefas.Entities.Entities;
using Tarefas.Repository.IRepository;

namespace Tarefas.Business.Imp.Service
{
    public class TarefaServices : ITarefaServices
    {
        private readonly ITarefaRepository _repository;

        public TarefaServices(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tarefa>> GetTarefaAsync() =>
            await _repository.GetAllAsync();

        public async Task<Tarefa> GetTarefaAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task CreateTarefaAsync(Tarefa task) =>
            await _repository.AddAsync(task);

        public async Task UpdateTarefaAsync(Tarefa task) =>
            await _repository.UpdateAsync(task);

        public async Task DeleteTarefaAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
using Microsoft.AspNetCore.Mvc;
using Tarefas.Business.IService;
using Tarefas.Entities.Entities;

namespace Tarefas.Controllers
{
    [Route("api/tarefa")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaServices _service;

        public TarefasController(ITarefaServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _service.GetTarefaAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _service.GetTarefaAsync(id);
            return task != null ? Ok(task) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Tarefa task)
        {
            await _service.CreateTarefaAsync(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Tarefa task)
        {
            if (id != task.Id) return BadRequest();
            await _service.UpdateTarefaAsync(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _service.DeleteTarefaAsync(id);
            return NoContent();
        }
    }
}

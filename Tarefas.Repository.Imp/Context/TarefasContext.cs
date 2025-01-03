using Microsoft.EntityFrameworkCore;
using Tarefas.Entities.Entities;

namespace Tarefas.Repository.Imp.Context
{
    public class TarefasContext : DbContext
    {
        public TarefasContext(DbContextOptions<TarefasContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=localhost.db",
                options => options.MigrationsAssembly("Tarefas.Api"));  // Aponta para o assembly correto
        }
        public DbSet<Tarefa> Tarefas { get; set; }

    }
}

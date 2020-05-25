using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Shared.Repository.Contexts
{
    public abstract class Context<TContext> : DbContext where TContext : Context<TContext>
    {
        public Context(DbContextOptions<TContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InsertEntityMapping(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        public void ExecuteMigrations() => Database.Migrate();

        protected abstract void InsertEntityMapping(ModelBuilder modelBuilder);
    }
}

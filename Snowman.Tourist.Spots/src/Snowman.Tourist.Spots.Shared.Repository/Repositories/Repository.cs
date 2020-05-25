using Microsoft.EntityFrameworkCore;
using Snowman.Tourist.Spots.Shared.Domain.Models;
using Snowman.Tourist.Spots.Shared.Repository.Contexts;

namespace Snowman.Tourist.Spots.Shared.Repository.Repositories
{
    public abstract class Repository<TEntity, TContext> where TEntity : Entity where TContext : Context<TContext>
    {
        protected readonly DbSet<TEntity> dbSet;

        public Repository(TContext context)
        {
            dbSet = context.Set<TEntity>();
        }
    }
}

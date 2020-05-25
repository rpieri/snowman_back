using Snowman.Tourist.Spots.Shared.Domain.Interfaces;
using Snowman.Tourist.Spots.Shared.Repository.Contexts;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Shared.Repository.UoW
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : Context<TContext>
    {
        private readonly TContext context;

        public UnitOfWork(TContext context)
        {
            this.context = context;
        }
        public async Task<bool> CommitAsync() => await context.SaveChangesAsync() > 0;

        public void Dispose() => context.Dispose();
    }
}

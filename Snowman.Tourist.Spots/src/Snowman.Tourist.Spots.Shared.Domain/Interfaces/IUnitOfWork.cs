using System;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Shared.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}

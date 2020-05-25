using Snowman.Tourist.Spots.Domain.Users.Models;
using System;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Domain.Users.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetAsync(Guid id);
        Task<User> GetByExternalIdAsync(string externalId);
        Task UpdateAsync(User user);
    }
}

using Microsoft.EntityFrameworkCore;
using Snowman.Tourist.Spots.Domain.Users.Models;
using Snowman.Tourist.Spots.Domain.Users.Repositories;
using Snowman.Tourist.Spots.Repository.Contexts;
using Snowman.Tourist.Spots.Shared.Repository.Repositories;
using System;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Repository.Repositories
{
    public class UserRepository : Repository<User, EntityContext>, IUserRepository
    {
        private readonly EntityContext context;

        public UserRepository(EntityContext context) : base(context)
        {
            this.context = context;
        }

        public async Task AddAsync(User user) => await dbSet.AddAsync(user);

        public async Task<User> GetAsync(Guid id) => await dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetByExternalIdAsync(string externalId) => await dbSet.FirstOrDefaultAsync(x => x.ExternalId.Equals(externalId));

        public async Task UpdateAsync(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            await Task.Run(() => dbSet.Update(user));
        }
    }
}

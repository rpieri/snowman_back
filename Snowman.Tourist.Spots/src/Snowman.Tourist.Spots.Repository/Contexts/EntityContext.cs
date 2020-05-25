using Microsoft.EntityFrameworkCore;
using Snowman.Tourist.Spots.Domain.Users.Models;
using Snowman.Tourist.Spots.Repository.Mappings.Users;
using Snowman.Tourist.Spots.Shared.Repository.Contexts;

namespace Snowman.Tourist.Spots.Repository.Contexts
{
    public class EntityContext : Context<EntityContext>
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; private set; }
        protected override void InsertEntityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping("users"));
        }
    }
}

using Snowman.Tourist.Spots.Shared.Domain.Models;

namespace Snowman.Tourist.Spots.Shared.Domain.Commands
{
    public abstract class CommandToAddEntity<TEntity> : Command where TEntity: Entity
    {
        public abstract TEntity Mapping(params object[] values);
    }
}

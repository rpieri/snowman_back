using System.Data;

namespace Snowman.Tourist.Spots.Shared.ReadOnlyRepository.Contexts
{
    public abstract class Context
    {
        public abstract IDbConnection CreateConnection();
    }
}

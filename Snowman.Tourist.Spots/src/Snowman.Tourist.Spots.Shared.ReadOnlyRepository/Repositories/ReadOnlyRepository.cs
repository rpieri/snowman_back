using Dapper;
using Slapper;
using Snowman.Tourist.Spots.Shared.ReadOnlyRepository.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Shared.ReadOnlyRepository.Repositories
{
    public abstract class ReadOnlyRepository<TContext> where TContext : Context
    {
        private readonly TContext context;

        public ReadOnlyRepository(TContext context)
        {
            this.context = context;
        }

        protected async Task<IEnumerable<TQuery>> ExecuteQuery<TQuery>(string query, object filtros = null)
        {
            using var connection = context.CreateConnection();
            return await connection.QueryAsync<TQuery>(query, filtros);
        }


        protected async Task<TQuery> ExecuteFirstOrDefaultQuery<TQuery>(string query, object filtros = null)
        {
            using var connection = context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<TQuery>(query, filtros);
        }

        protected void AddIdentifier<TQuery>(string identifier) => AutoMapper.Configuration.AddIdentifier(typeof(TQuery), identifier);
        protected TQuery MapFirstOrDefault<TQuery>(IEnumerable<dynamic> queryResult, bool cache = false) => AutoMapper.MapDynamic<TQuery>(queryResult, cache).FirstOrDefault();
        protected IEnumerable<TQuery> Map<TQuery>(IEnumerable<dynamic> queryResult, bool cache = false) => AutoMapper.MapDynamic<TQuery>(queryResult, cache);
    }
}

using System;
using System.Linq;
using System.Linq.Expressions;
using MyStore.Domain.Framework;
using MyStore.Domain.Models;

namespace MyStore.Domain.Repositories
{
    public interface IStateRepository : IRepository<State>
    {
    }

    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        protected override IQueryable<State> GetQuery(int userId, Expression<Func<State, bool>> predicate = null)
        {
            var query = GetBaseQuery(userId, predicate);

            return query;
        }
    }
}

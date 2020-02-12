using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Framework;
using MyStore.Domain.Models;

namespace MyStore.Domain.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
    }

    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        protected override IQueryable<OrderItem> GetQuery(int userId,
            Expression<Func<OrderItem, bool>> predicate = null)
        {
            var query = GetBaseQuery(userId, predicate)
                .Include(x => x.Order);

            return query;
        }
    }
}

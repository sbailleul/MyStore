using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Framework;
using MyStore.Domain.Models;

namespace MyStore.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
    }

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        protected override IQueryable<Product> GetQuery(int userId,
            Expression<Func<Product, bool>> predicate = null)
        {
            var query = GetBaseQuery(userId, predicate)
                .Include(x => x.Category)
                .Include(x => x.ProductStatus);

            return query;
        }
    }
}

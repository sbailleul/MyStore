﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Framework;
using MyStore.Domain.Models;

namespace MyStore.Domain.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
    }

    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        protected override IQueryable<Address> GetQuery(int userId, Expression<Func<Address, bool>> predicate = null)
        {
            var query = GetBaseQuery(userId, predicate)
                .Include(x => x.State);

            return query;
        }
    }
}

using System;
using System.Linq.Expressions;
using digitalwedding.Application.Data.Interfaces;
using digitalwedding.Application.Data.Models.Repositories;
using digitalwedding.Contracts;
using Microsoft.EntityFrameworkCore;

namespace digitalwedding.Infrastructure.Data.Repositories
{
	public class WeddingRepository: AppRepository<Wedding>, IWeddingRepository
	{
        private readonly bool _disposed;
        public WeddingRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<PaginatedList<Wedding>> GetWeddings(
            Expression<Func<Wedding, bool>> filter,
            int pageIndex,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            var source = _dbContext.Weddings.Where(filter);

            var count = await source.CountAsync();

            source = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var items = await source.ToListAsync();

            return new PaginatedList<Wedding>(items, pageIndex, pageSize, count);
        }

        protected void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}


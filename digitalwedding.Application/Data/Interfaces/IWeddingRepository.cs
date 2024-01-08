using System;
using System.Linq.Expressions;
using digitalwedding.Application.Data.Models.Repositories;
using digitalwedding.Contracts;

namespace digitalwedding.Application.Data.Interfaces
{
	public interface IWeddingRepository: IRepository<Wedding>
	{
        Task<PaginatedList<Wedding>> GetWeddings(Expression<Func<Wedding, bool>> filter,
        int pageIndex = 1,
        int pageSize = 20,
        CancellationToken cancellationToken = default);
    }
}


using System;
using System.Linq.Expressions;
using digitalwedding.Application.Data.Models.Repositories;
using digitalwedding.Contracts;

namespace digitalwedding.Application.Data.Interfaces
{
    public interface IGuestRepository : IRepository<Guest>
    {
        Task<PaginatedList<Guest>> GetGuests(Expression<Func<Guest, bool>> filter,
        int pageIndex = 1,
        int pageSize = 20,
        CancellationToken cancellationToken = default);
    }
    
}


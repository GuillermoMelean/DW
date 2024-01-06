using System;
using digitalwedding.Application.Data.Interfaces;
using digitalwedding.Application.Data.Models.Repositories;

namespace digitalwedding.Infrastructure.Data.Repositories
{

    public class GuestRepository : AppRepository<Guest>, IGuestRepository
    {
        public GuestRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}


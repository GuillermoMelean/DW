using System;
using digitalwedding.Application.Data.Interfaces;
using digitalwedding.Application.Data.Models.Repositories;

namespace digitalwedding.Infrastructure.Data.Repositories
{
	public class WeddingRepository: AppRepository<Wedding>, IWeddingRepository
	{
		public WeddingRepository(AppDbContext dbContext) : base(dbContext) { }
	}
}


using System;
using digitalwedding.Application.Data.Models.Repositories;

namespace digitalwedding.Infrastructure.Data.Repositories
{
	public class AppRepository<T>: Repository<AppDbContext, T> where T : Base
	{
		public AppRepository(AppDbContext dbContext) : base(dbContext) { }
	}
}


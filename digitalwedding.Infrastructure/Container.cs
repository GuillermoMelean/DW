using System;
using digitalwedding.Application.Data.Interfaces;
using digitalwedding.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace digitalwedding.Infrastructure
{
	public static class Container
	{
		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IWeddingRepository, WeddingRepository>();
		}

		public static void AddDbContextDigitalWedding(this IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>();
		}

		public static void AddInfrastructure(this IServiceCollection services)
		{
			services.AddDbContextDigitalWedding();
            services.AddRepositories();
		}
	}
}


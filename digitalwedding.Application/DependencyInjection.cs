using System;
using digitalwedding.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace digitalwedding.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IGuestService, GuestService>();
			services.AddScoped<IWeddingService, WeddingService>();

			return services;
		}
	}
}


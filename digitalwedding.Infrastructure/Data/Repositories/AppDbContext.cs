using digitalwedding.Application.Data.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace digitalwedding.Infrastructure.Data.Repositories
{
	public class AppDbContext: DbContext
	{
		public DbSet<Wedding> Weddings { get; set; }
		public DbSet<Guest> Guests { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//var connectionString = "Server=194.39.124.91;Id=cubic_guillermo;Password=Quo1049t%;Database=cubic_digital-wedding";
			var connectionString = "Server=194.39.124.91;User ID=cubic_guillermo;Password=Quo1049t%;Database=cubic_digital-wedding";


            var serverVersion = new MySqlServerVersion(new Version(10, 3, 39));
			optionsBuilder.UseMySql(connectionString, serverVersion);
		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
			builder.Entity<Wedding>();
			builder.Entity<Guest>();
        }
    }
}
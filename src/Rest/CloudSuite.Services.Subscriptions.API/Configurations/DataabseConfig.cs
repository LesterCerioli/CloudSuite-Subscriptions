using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Services.Subscriptions.API.Configurations
{
	public static class DataabseConfig
	{
		public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			services.AddDbContext<SubscriptionDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


		}
	}
}

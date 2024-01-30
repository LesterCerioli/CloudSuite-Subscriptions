using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Subscriptions;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Jobs
{
	public class SubscriptionWorkerService : BackgroundService
	{
		private readonly IServiceProvider _serviceProvider;

		public SubscriptionWorkerService(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				// Check the current time.
				DateTime now = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
				// Check if it's the desired time (07:00 AM or 03:00 PM).
				if ((now.Hour == 7 || now.Hour == 15) && now.Minute == 0)
				{
					using (var scope = _serviceProvider.CreateScope())
					{
						var subscriptionAppService = scope.ServiceProvider.GetRequiredService<SubscriptionAppService>();

						try
						{
							// Call methods from SubscriptionAppService
							var subscriptionViewModel = await subscriptionAppService.GetByActive(true);
							// ... (perform other operations as needed)

							// Example of calling the Save method
							var createSubscriptionCommand = new CreateSubscriptionCommand(/* necessary parameters */);
							await subscriptionAppService.Save(createSubscriptionCommand);
						}
						catch (Exception ex)
						{
							// Exception log and reprocessing.
							Console.WriteLine($"Error during processing: {ex.Message}");
							continue; // Continue to process again
						}
					}
				}
				// Wait 1 minute before checking again
				await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
			}
		}
	}
}

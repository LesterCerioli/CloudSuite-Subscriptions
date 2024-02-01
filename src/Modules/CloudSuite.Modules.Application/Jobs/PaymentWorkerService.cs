using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Commons.Valueobjects;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Jobs
{
	public class PaymentWorkerService : BackgroundService
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly ILogger<PaymentWorkerService> _logger;

		public PaymentWorkerService(IServiceProvider serviceProvider, ILogger<PaymentWorkerService> logger)
		{
			_serviceProvider = serviceProvider;
			_logger = logger;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				try
				{
					using (var scope = _serviceProvider.CreateScope())
					{
						var paymentAppService = scope.ServiceProvider.GetRequiredService<PaymentAppService>();

						// Perform necessary operations from PaymentAppService
						var cnpj = new Cnpj();
						var paymentByCnpj = await paymentAppService.GetByCnpj(cnpj);
						// ... (calls to other methods as needed)
						var number = "123456";
						var paymentByNumber = await paymentAppService.GetByNumber(number);
						// ... (calls to other methods as needed)

						// Example: await paymentAppService.Save(commandCreate);
						// Make sure to adjust method calls as needed
					}

					// Wait for 5 minutes before checking again
					await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
				}
				catch (Exception ex)
				{
					// Log exception and reprocess in case of failure
					_logger.LogError($"Error during payment processing: {ex.Message}");
				}
			}
		}

		private bool IsDesiredTime(DateTime dateTime)
		{
			// Define Brasília timezone
			var brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
			// Convert current time to Brasília timezone
			DateTime brasiliaNow = TimeZoneInfo.ConvertTime(dateTime, brasiliaTimeZone);

			// Desired times for processing
			TimeSpan[] desiredTimes = new[]
			{
				new TimeSpan(1, 0, 0),   // 01:00 AM
                new TimeSpan(6, 0, 0),   // 06:00 AM
                new TimeSpan(12, 0, 0),  // 12:00 PM
                new TimeSpan(18, 0, 0)   // 06:00 PM
            };

			// Check if the current time is within the desired times
			foreach (var desiredTime in desiredTimes)
			{
				var startTime = brasiliaNow.Date.Add(desiredTime);
				var endTime = startTime.AddMinutes(1); // Add 1 minute to consider the whole minute

				if (brasiliaNow >= startTime && brasiliaNow < endTime)
				{
					return true;
				}
			}

			// Return false if the current time is not within the desired times
			return false;
		}
	}
}

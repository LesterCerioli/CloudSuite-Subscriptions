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
	public class CompanyWorkerService : BackgroundService
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly ILogger<CompanyWorkerService> _logger;
		private readonly string fantasyNamed;
		private readonly string socialName;

		public CompanyWorkerService(IServiceProvider serviceProvider, ILogger<CompanyWorkerService> logger)
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
						var companyAppService = scope.ServiceProvider.GetRequiredService<CompanyAppService>();
						var cnpj = new Cnpj();
						var companyByCnpj = await companyAppService.GetByCnpj(cnpj);
						var companyByFantasyName = await companyAppService.GetByFantasyName(fantasyNamed);
						var companyBySocialName = await companyAppService.GetBySocialName(socialName);


					}

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

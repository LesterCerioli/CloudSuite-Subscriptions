using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.Services.Implementations;
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
	public class SubscriptionWorkService : BackgroundService
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly ILogger<SubscriptionWorkService> _logger;

		public SubscriptionWorkService(IServiceProvider serviceProvider, ILogger<SubscriptionWorkService> logger)
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
						var subscriptionAppService = scope.ServiceProvider.GetRequiredService<ISubscriptionAppService>();

						// Chama o método que processa o serviço Subscription
						await subscriptionAppService.ProcessSubscriptionService();

						// Log de sucesso
						_logger.LogInformation("Processamento do serviço Subscription concluído com sucesso.");

						// Aguarda 15 segundos antes de executar novamente
						await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
					}
				}
				catch (Exception ex)
				{
					// Log da exceção e reprocessamento
					_logger.LogError($"Erro no processamento: {ex.Message}");

					// Aguarda 15 segundos antes de tentar novamente
					await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
				}
			}
		}
	}
}

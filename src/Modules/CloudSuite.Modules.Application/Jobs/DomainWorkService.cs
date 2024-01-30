using CloudSuite.Modules.Application.Services.Contracts;
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
	public class DomainWorkService : BackgroundService
	{
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DomainWorkService> _logger;

        public DomainWorkService(IServiceProvider serviceProvider, ILogger<DomainWorkService> logger)
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
                        var domainAppservice = scope.ServiceProvider.GetRequiredService<IDomainAppService>();

                        // Chama o método que processa o serviço Payment
                        await domainAppservice.ProcessDomainService();

                        // Log de sucesso
                        _logger.LogInformation("Processamento do serviço Domain concluído com sucesso.");

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

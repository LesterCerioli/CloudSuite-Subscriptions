using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Payments
{
    public class CheckPaymentExistsByCnpjHandlers : IRequestHandler<CheckPaymentExistsByCnpjRequest, CheckPaymentExistsByCnpjResponse>
    {
        private IPaymentRepository _repositorioPayment;
        private readonly ILogger<CheckPaymentExistsByCnpjHandlers> _logger;

        public CheckPaymentExistsByCnpjHandlers(IPaymentRepository repositorioPayment, ILogger<CheckPaymentExistsByCnpjHandlers> logger)
        {
            _repositorioPayment = repositorioPayment;
            _logger = logger;
        }

        public async Task<CheckPaymentExistsByCnpjHandlers> Handle(CheckPaymentExistsByCnpjRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckPaymentExistsByCnpjRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckPaymentExistsByCnpjRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var payment = await _repositorioPayment.GetByCnpj(new Cnpj(request.Cnpj));
                    if (payment != null)
                    {
                        return await Task.FromResult(new CheckPaymentExistsByCnpjResponse(request.Id, true, validationResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPaymentExistsByCnpjResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckPaymentExistsByCnpjResponse(request.Id, false, validationResult));
        }
    }
}
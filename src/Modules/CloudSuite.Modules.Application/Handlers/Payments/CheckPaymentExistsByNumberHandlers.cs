using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using CloudSuite.Modules.Application.Validation.Payments;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Payments
{
    public class CheckPaymentExistsByNumberHandlers : IRequestHandler<CheckPaymentExistsByNumberRequest, CheckPaymentExistsByNumberResponse>
    {
        private IPaymentRepository _repositorioPayment;
        private readonly ILogger<CheckPaymentExistsByNumberHandlers> _logger;

        public CheckPaymentExistsByNumberHandlers(IPaymentRepository repositorioPayment, ILogger<CheckPaymentExistsByNumberHandlers> logger)
        {
            _repositorioPayment = repositorioPayment;
            _logger = logger;
        }

        public async Task<CheckPaymentExistsByNumberResponse>Handle(CheckPaymentExistsByNumberRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckPaymentExistsByNumberRequest:{JsonSerializer.Serialize(request)}");
            var validationResult = new CheckPaymentExistsByNumberRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var payment = await _repositorioPayment.GetByNumber(request.Number);
                    if(payment != null)
                    {
                        return await Task.FromResult(new CheckPaymentExistsByNumberResponse(request.Id, true, validationResult));
                    }
                }catch(Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPaymentExistsByNumberResponse(request.Id, "Failed to process the request."));
                }
            }

            return await Task.FromResult(new CheckPaymentExistsByNumberResponse(request.Id, false, validationResult));

        }
    }
}
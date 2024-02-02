using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using CloudSuite.Modules.Application.Validation.Payments;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Payments
{
    public class CheckPaymentExistsByPaidDateHandler : IRequestHandler<CheckPaymentExistsByPaidDateRequest, CheckPaymentExistsByPaidDateResponse>
    {
        private IPaymentRepository _repositorioPayment;
        private readonly Logger<CheckPaymentExistsByPaidDateHandler> _logger;

        public CheckPaymentExistsByPaidDateHandler(IPaymentRepository repositorioPayment, Logger<CheckPaymentExistsByPaidDateHandler> logger)
        {
            _repositorioPayment = repositorioPayment;
            _logger = logger;
        }

        public async Task<CheckPaymentExistsByPaidDateResponse> Handle(CheckPaymentExistsByPaidDateRequest request, CancellationToken cancellationToken)
        {

            _logger.LogInformation($"CheckPaymentExistsByPaidDateRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckPaymentExistsByPaidDateRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var payment = await _repositorioPayment.GetByPaidDate(request.PaidDate);
                    if(payment != null)
                    {
                        return await Task.FromResult(new CheckPaymentExistsByPaidDateResponse(request.Id, true, validationResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPaymentExistsByPaidDateResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckPaymentExistsByPaidDateResponse(request.Id, false, validationResult));
        }
    }
}

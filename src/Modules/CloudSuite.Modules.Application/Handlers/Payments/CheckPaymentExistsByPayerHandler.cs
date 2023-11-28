using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using CloudSuite.Modules.Application.Validation.Payments;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Payments
{
    public class CheckPaymentExistsByPayerHandler : IRequestHandler<CheckPaymentExistsByPayerRequest, CheckPaymentExistsByPayerResponse>
    {

        private IPaymentRepository _repositorioPayment;
        private readonly Logger<CheckPaymentExistsByPayerHandler> _logger;

        public CheckPaymentExistsByPayerHandler(IPaymentRepository repositorioPayment, Logger<CheckPaymentExistsByPayerHandler> logger)
        {
            _repositorioPayment = repositorioPayment;
            _logger = logger;
        }

        public async Task<CheckPaymentExistsByPayerResponse> Handle(CheckPaymentExistsByPayerRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckPaymentExistsByPayerRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckPaymentExistsByPayerRequestValidation().Validate(request);

            if(validationResult.IsValid)
            {
                try
                {
                    var payment = _repositorioPayment.GetByPayer(request.Payer);
                    if (payment != null)
                    {
                        return await Task.FromResult(new CheckPaymentExistsByPayerResponse(request.Id, true, validationResult));
                    }
                }catch(Exception ex) {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPaymentExistsByPayerResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckPaymentExistsByPayerResponse(request.Id, false, validationResult));
        }
    }
}

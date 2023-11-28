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
    public class CheckPaymentExistsByTotalHandler : IRequestHandler<CheckPaymentExistsByTotalRequest, CheckPaymentExistsByTotalResponse>
    {
        private IPaymentRepository _repositorioPayment;
        private readonly ILogger<CheckPaymentExistsByTotalHandler> _logger;

        public CheckPaymentExistsByTotalHandler(IPaymentRepository repositorioPayment, ILogger<CheckPaymentExistsByTotalHandler> logger)
        {
            _repositorioPayment = repositorioPayment;
            _logger = logger;
        }

        public async Task<CheckPaymentExistsByTotalResponse> Handle(CheckPaymentExistsByTotalRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckPaymentExistsByTotalRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckPaymentExistsByTotalRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var payment = await _repositorioPayment.GetByTotal(request.Total);
                    if(payment != null)
                    {
                        return await Task.FromResult(new CheckPaymentExistsByTotalResponse(request.Id, true, validationResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPaymentExistsByTotalResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckPaymentExistsByTotalResponse(request.Id, false, validationResult));
        }
    }
}

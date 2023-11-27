using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using CloudSuite.Modules.Application.Handlers.Payments.Responses;
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
    public class CheckPaymentExistsByExpireDateHandler : IRequestHandler<CheckPaymentExistsByExpireDateRequest, CheckPaymentExistsByExpireDateResponse>
    {
        private IPaymentRepository _repositorioPayment;
        private readonly ILogger<CheckPaymentExistsByExpireDateHandler> _logger;

        public CheckPaymentExistsByExpireDateHandler(IPaymentRepository repositorioPayment, ILogger<CheckPaymentExistsByExpireDateHandler> logger)
        {
            _repositorioPayment = repositorioPayment;
            _logger = logger;
        }

        public async Task<CheckPaymentExistsByExpireDateResponse> Handle(CheckPaymentExistsByExpireDateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckPaymentExistsByExpireDateRequest: {JsonSerializer.Serialize(request)}");

            var validationResult = new CheckPaymentExistsByExpireDateRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var payment = await _repositorioPayment.GetByExpireDate(request.ExpireDate);
                    if (payment != null)
                    {
                        return await Task.FromResult(new CheckPaymentExistsByExpireDateResponse(request.Id, true, validationResult));
                    }

                }catch (Exception ex) {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPaymentExistsByExpireDateResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckPaymentExistsByExpireDateResponse(request.Id, false, validationResult));
        }
    }
}

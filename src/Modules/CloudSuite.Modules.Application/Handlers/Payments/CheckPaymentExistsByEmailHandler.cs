using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using CloudSuite.Modules.Commons.Valueobjects;
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
    public class CheckPaymentExistsByEmailHandler : IRequestHandler<CheckPaymentExistsByEmailRequest, CheckPaymentExistsByEmailResponse>
    {
        private IPaymentRepository _repositorioPayment;
        private readonly ILogger<CheckPaymentExistsByEmailHandler> _logger;

        public CheckPaymentExistsByEmailHandler(IPaymentRepository repositorioPayment, ILogger<CheckPaymentExistsByEmailHandler> logger)
        {
            _repositorioPayment = repositorioPayment;
            _logger = logger;
        }

        public async Task<CheckPaymentExistsByEmailResponse> Handle(CheckPaymentExistsByEmailRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckPaymentExistsByEmailRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckPaymentExistsByEmailRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var payment = await _repositorioPayment.GetByEmail(new Email(request.Email));
                    if (payment != null)
                    {
                        return await Task.FromResult(new CheckPaymentExistsByEmailResponse(request.Id, true, validationResult));
                    }
                }catch(Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPaymentExistsByEmailResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckPaymentExistsByEmailResponse(request.Id, false, validationResult));
        }
    }
}

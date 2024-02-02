using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using CloudSuite.Modules.Application.Validation.Payments;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Payments
{
    public class CreatePaymentHandler
    {
        private IPaymentRepository _repositorioPayment;
        private readonly ILogger<CreatePaymentHandler> _logger;

        public CreatePaymentHandler(IPaymentRepository repositorioPayment, ILogger<CreatePaymentHandler> logger)
        {
            _repositorioPayment = repositorioPayment;
            _logger = logger;
        }

        public async Task<CreatePaymentResponse> Handle(CreatePaymentCommand command, CancellationToken cancellationToken){
            _logger.LogInformation($"CreatePaymentCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreatePaymentCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var paymentCnpj = await _repositorioPayment.GetByCnpj(new Cnpj(command.Cnpj));
                    var paymentEmail = await _repositorioPayment.GetByEmail(new Email(command.Email));
                    var paymentExpireDate = await _repositorioPayment.GetByExpireDate(command.ExpireTime);
                    var paymentNumber = await _repositorioPayment.GetByNumber(command.Number);
                    var paymentPaidDate = await _repositorioPayment.GetByPaidDate(command.PaidTime);
                    var paymentPayer = await _repositorioPayment.GetByPayer(command.Payer);
                    var paymentTotal = await _repositorioPayment.GetByTotal(command.Total);
                    var paymentTotalPaid = await _repositorioPayment.GetByTotalPaid(command.TotalPaid);

                    if (paymentCnpj != null && paymentEmail != null && paymentExpireDate != null && paymentNumber != null && paymentPaidDate != null && paymentPayer != null && paymentTotal != null && paymentTotalPaid != null)
                    {
                        return await Task.FromResult(new CreatePaymentResponse(command.Id, "Pagamento já cadastrado."));
                    }
                    await _repositorioPayment.Add(command.GetEntity());
                    return await Task.FromResult(new CreatePaymentResponse(command.Id, validationResult));
                }catch (Exception ex) {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreatePaymentResponse(command.Id, "Não foi possível processar sua solicitação."));
                }
            }

            return await Task.FromResult(new CreatePaymentResponse(command.Id, validationResult));

        }
    }
}
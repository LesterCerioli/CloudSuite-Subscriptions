using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using CloudSuite.Modules.Domain.Contracts.IPaymentRepository;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Payments
{
    public class CheckPaymentExistsByTotalPaidHandlers: IRequestHandler<CheckPaymentExistsByTotalPaidRequest, CheckPaymentExistsByTotalPaidResponse>
    {
        private IPaymentRepository _repositorioPayment;
        private readonly ILogger<CheckPaymentExistsByTotalPaidHandlers> _logger;

        public CheckPaymentExistsByTotalPaidHandlers(IPaymentRepository repositorioPayment, ILogger<CheckPaymentExistsByTotalPaidHandlers> logger)
        {
            _repositorioPayment = repositorioPayment;
            _logger = logger;
        }

        public async Task<CheckPaymentExistsByTotalPaidResponse> Handle(CheckPaymentExistsByTotalPaidRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckPaymentExistsByTotalPaidRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckPaymentExistsByTotalPaidRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var payment = await _repositorioPayment.GetByTotalPaid(request.TotalPaid);
                    if (payment != null)
                        return await Task.FromResult(new CheckPaymentExistsByTotalPaidResponse(request.Id, true, validationResult));
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPaymentExistsByNumberResponse(request.Id, "Não foi possível processar sua solicitação.");
                }
            }
            return await Task.FromResult(new CheckPaymentExistsByTotalPaidResponse(request.Id, false, validationResult);
        }
    }
}
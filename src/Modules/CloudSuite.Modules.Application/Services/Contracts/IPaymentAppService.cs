using CloudSuite.Modules.Application.Handlers.Payments;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IPaymentAppService
    {
        Task<PaymentViewModel> GetByNumber(string number);

        Task<PaymentViewModel> GetByPaidDate(DateTime? paidDate);

        Task<PaymentViewModel> GetByExpireDate(DateTime? expireDate);

        Task<PaymentViewModel> GetByTotal(decimal total);

        Task<PaymentViewModel> GetByTotalPaid(decimal totalPaid);

        Task<PaymentViewModel> GetByPayer(string payer);

        Task<PaymentViewModel> GetByCnpj(Cnpj cnpj);

        Task<PaymentViewModel> GetByEmail(Email email);

        Task Save(CreatePaymentCommand commandCreate);
    }
}
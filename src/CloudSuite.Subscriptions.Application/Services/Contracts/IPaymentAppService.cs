using CloudSuite.Commons.ValueObjects;
using CloudSuite.Subscriptions.Application.ViewModels;

namespace CloudSuite.Subscriptions.Application.Services.Contracts
{
    public interface IPaymentAppService
    {
        Task<PaymentViewModel> GetByNumber(string number);

        Task<PaymentViewModel> GetByPaidDate(DateTime? paidDate);

        Task<PaymentViewModel> GetByExpireDate(DateTime? expireDate);

        Task<PaymentViewModel> GetByTotal(decimal total);

        Task<PaymentViewModel> GetByPayer(string payer); 

        Task<PaymentViewModel> GetByCnpj(Cnpj cnpj);

        //Task Save(CreatePaymentCommand commandCreate);
         
    }
}
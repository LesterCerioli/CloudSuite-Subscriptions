using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Payments;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class PaymentAppService : IPaymentAppService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public PaymentAppService(
            IPaymentRepository paymentRepository,
            IMapper mapper,
            IMediatorHandler mediator
        )
        {
            _paymentRepository = paymentRepository;
            _mediator = mediator;
            _mapper = mapper;

        }
        public async Task<PaymentViewModel> GetByCnpj(Cnpj cnpj)
        {
            return _mapper.Map<PaymentViewModel>(await _paymentRepository.GetByCnpj(cnpj));
        }

        public async Task<PaymentViewModel> GetByExpireDate(DateTime? expireDate)
        {
            return _mapper.Map<PaymentViewModel>(await _paymentRepository.GetByExpireDate(expireDate));
        }

        public async Task<PaymentViewModel> GetByNumber(string number)
        {
            return _mapper.Map<PaymentViewModel>(await _paymentRepository.GetByNumber(number));
        }

        public async Task<PaymentViewModel> GetByPaidDate(DateTime? paidDate)
        {
            return _mapper.Map<PaymentViewModel>(await _paymentRepository.GetByPaidDate(paidDate));
        }

        public async Task<PaymentViewModel> GetByPayer(string payer)
        {
            return _mapper.Map<PaymentViewModel>(await _paymentRepository.GetByPayer(payer));
        }

        public async Task<PaymentViewModel> GetByTotal(decimal total)
        {
            return _mapper.Map<PaymentViewModel>(await _paymentRepository.GetByTotal(total));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
        public async Task Save(CreatePaymentCommand commandCreate)
        {
            await _paymentRepository.Add(commandCreate.GetEntity());
            
        }
    }
}
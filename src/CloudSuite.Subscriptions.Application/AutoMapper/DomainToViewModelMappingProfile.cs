using AutoMapper;
using CloudSuite.Subscriptions.Application.ViewModels;
using CloudSuite.Subscriptions.Domain.Models;

namespace CloudSuite.Subscriptions.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
		{
			CreateMap<Company, CompanyViewModel>();
			CreateMap<Customer, CustomerViewModel>();
			CreateMap<DomainEntidade, DomainViewModel>();
			CreateMap<Payment, PaymentViewModel>();
			CreateMap<Subscription, SubscriptionViewModel>();
            CreateMap<Contact, ContactViewModel>();
        }
        
    }
}
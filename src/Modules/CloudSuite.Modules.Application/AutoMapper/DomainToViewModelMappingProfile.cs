using AutoMapper;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.AutoMapper
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
		}
	}
}

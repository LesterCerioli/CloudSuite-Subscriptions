using CloudSuite.Infrastructure.Context;
using CloudSuite.Modules.Application.Jobs;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.CrossCutting
{
	public class NativeInjectorBootStrapper
	{
		public static void RegisterServices(IServiceCollection services)
		{
			// Infrastructure
			services.AddScoped<ICompanyRepository>();
			services.AddScoped<ICustomerRepository>();
			services.AddScoped<IDomainRepository>();
			services.AddScoped<IPaymentRepository>();
			//services.AddScoped<IPersonRepository>();
			services.AddScoped<ISubscriptionRepository>();


			services.AddScoped<SubscriptionDbContext>();

			// Application
			services.AddScoped<ICompanyAppService, CompanyAppService>();
			services.AddScoped<ICustomerAppService, CustomerAppService>();
			services.AddScoped<IDomainAppService, DomainAppService>();
			services.AddScoped<IPaymentAppService, PaymentAppService>();
			services.AddScoped<ISubscriptionAppService, SubscriptionAppService>();
			services.AddScoped<SubscriptionWorkService>();
			services.AddScoped<CompanyWorkService>();
			services.AddScoped<CustomerWorkService>();
			services.AddScoped<DomainWorkService>();
			services.AddScoped<PaymentWorkService>();

		}
	}
}

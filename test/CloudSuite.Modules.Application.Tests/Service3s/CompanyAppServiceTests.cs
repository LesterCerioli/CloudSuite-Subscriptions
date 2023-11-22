using AutoMapper;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Service3s
{
	public class CompanyAppServiceTests
	{
		[Fact]
		public async Task GetByCnpj_ShouldReturnCompanyViewModel()
		{
			var companyRepositoryMock = new Mock<ICompanyRepository>();

			var mapperMock = new Mock<IMapper>();

			


			var cnpj = new Cnpj("12345678901234"); // Replace with a valid CNPJ for testing
			var companyModel = new CompanyViewModel(); // Replace with a sample Company model
			var expectedViewModel = new CompanyViewModel(); // Replace with a samp

			//Act
			var result = await companyAppService.GetByCnpj(cnpj);

			// Assert
			Assert.NotNull(result);
			Assert.Same(expectedViewModel, result);

		}

		[Fact]
		public async Task GetByFantasyName_ShouldReturnCompanyViewModel()
		{
			var companyRepositoryMock = new Mock<ICompanyRepository>();
			var mapperMock = new Mock<IMapper>();

			

			var fantasyName = "Carioca .L.C";
			var companyModel = new CompanyViewModel();
			

		}
	}
}

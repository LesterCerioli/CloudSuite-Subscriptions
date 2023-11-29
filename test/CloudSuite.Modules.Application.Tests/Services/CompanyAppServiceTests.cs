using AutoMapper;
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
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services
{
	public class CompanyAppServiceTests
	{
		[Fact]
		public async Task GetCompanyByCnpj_ShouldReturnsCompanyViewModel()
		{
			var cnpj = new Cnpj("49.859.881/0001-90");
			var companyRepositoryMock = new Mock<ICompanyRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var companyAppService = new CompanyAppService(
				companyRepositoryMock.Object,
				mediatorHandlerMock.Object,
				mapperMock.Object);

			var companyEntity = new Company();
			companyRepositoryMock.Setup(repo => repo.GetByCnpj(cnpj)).ReturnsAsync(companyEntity);

			var expectedViewModel = new CompanyViewModel(/* create your expected view model here */);
			mapperMock.Setup(mapper => mapper.Map<CompanyViewModel>(companyEntity)).Returns(expectedViewModel);

			// Act
			var result = await companyAppService.GetByCnpj(cnpj);

			// Assert
			Assert.Equal(expectedViewModel, result);

		}

		[Fact]
		public async Task GetCompanyByCnpj_ShouldReturnsNullForNonExistentCompany()
		{
			// Arrange
			var cnpj = new Cnpj("00.000.000/0000-00");
			var companyRepositoryMock = new Mock<ICompanyRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var companyAppService = new CompanyAppService(
				companyRepositoryMock.Object,
				mediatorHandlerMock.Object,
				mapperMock.Object);

			companyRepositoryMock.Setup(repo => repo.GetByCnpj(cnpj)).ReturnsAsync((Company)null);

			// Act
			var result = await companyAppService.GetByCnpj(cnpj);

			// Assert
			Assert.Null(result);
		}
	}
}

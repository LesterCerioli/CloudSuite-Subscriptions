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
            var socialName = "Americanas";
            var fantasyName = "Lojas Americanas";
            var companyRepositoryMock = new Mock<ICompanyRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var companyAppService = new CompanyAppService(
				companyRepositoryMock.Object,
				mediatorHandlerMock.Object,
				mapperMock.Object);

			var companyEntity = new Company(cnpj, socialName, fantasyName);
			companyRepositoryMock.Setup(repo => repo.GetByCnpj(cnpj)).ReturnsAsync(companyEntity);

			var expectedViewModel = new CompanyViewModel();
			mapperMock.Setup(mapper => mapper.Map<CompanyViewModel>(companyEntity)).Returns(expectedViewModel);

			// Act
			var result = await companyAppService.GetByCnpj(cnpj);

			// Assert
			Assert.Equal(expectedViewModel, result);

		}

	/*	[Fact]
		public async Task GetCompanyByCnpj_ShouldReturnsNullForNonExistentCompany()
		{
            // Arrange
            var cnpj = new Cnpj("nonexistent-cnpj");
            var socialName = "Americanas";
            var fantasyName = "Lojas Americanas";
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
		}*/

        [Fact]
        public async Task GetBySocialName_ShouldReturnMappedViewModel()
        {
            // Arrange
            var cnpj = new Cnpj("76.883.915/0001-54");
            var socialName = "Americanas";
            var fantasyName = "Lojas Americanas";
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var companyEntity = new Company(cnpj, socialName, fantasyName);
            companyRepositoryMock.Setup(repo => repo.GetBySocialName(socialName)).ReturnsAsync(companyEntity);

            var expectedViewModel = new CompanyViewModel();
            mapperMock.Setup(mapper => mapper.Map<CompanyViewModel>(companyEntity)).Returns(expectedViewModel);

            // Act
            var result = await companyAppService.GetBySocialName(socialName);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Fact]
        public async Task GetByFantasyName_ShouldReturnMappedViewModel()
        {
            // Arrange
            var cnpj = new Cnpj("76.883.915/0001-54");
            var socialName = "Americanas";
            var fantasyName = "Lojas Americanas";
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var companyEntity = new Company(cnpj, socialName, fantasyName);
            companyRepositoryMock.Setup(repo => repo.GetByFantasyName(socialName)).ReturnsAsync(companyEntity);

            var expectedViewModel = new CompanyViewModel();
            mapperMock.Setup(mapper => mapper.Map<CompanyViewModel>(companyEntity)).Returns(expectedViewModel);

            // Act
            var result = await companyAppService.GetByFantasyName(socialName);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

    }
}

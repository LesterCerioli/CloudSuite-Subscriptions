using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Handlers.Customers;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services
{
	public class CompanyAppServiceTests
	{
        [Theory]
        [InlineData("49.859.881/0001-90", "Americanas", "Lojas Americanas", "2017-3-1")]
        [InlineData("27.562.604/0001-88", "Walmart", "Walmart Brasil", "1999-9-12")]
        [InlineData("54.628.754/0001-10", "Carrefour", "Carrefour Brasil", "2000-5-11")]
        public async Task GetCompanyBySocialName_ShouldReturnsCompanyViewModel(string cnpj, string socialName, string fantasyName, DateTime fundationDate)
        {
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object);

            var companyEntity = new Company(cnpj, socialName, fantasyName, fundationDate);
            companyRepositoryMock.Setup(repo => repo.GetBySocialName(cnpj)).ReturnsAsync(companyEntity);

            var expectedViewModel = new CompanyViewModel()
            {
                Id = companyEntity.Id,
                Cnpj = cnpj,
                SocialName = socialName,
                FantasyName = fantasyName,
                FundationDate = fundationDate
            };

            mapperMock.Setup(mapper => mapper.Map<CompanyViewModel>(companyEntity)).Returns(expectedViewModel);

            // Act
            var result = await companyAppService.GetBySocialName(cnpj);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("Americanas")]
        [InlineData("Walmart")]
        [InlineData("Carrefour")]
        public async Task GetCompanyBySocialName_ShouldHandleNullRepositoryResult(string socialName)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            companyRepositoryMock.Setup(repo => repo.GetBySocialName(It.IsAny<string>()))
                .ReturnsAsync((Company)null); // Simulate null result from the repository

            // Act
            var result = await companyAppService.GetBySocialName(socialName);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("Americanas")]
        [InlineData("Walmart")]
        [InlineData("Carrefour")]
        public async Task GetCompanyBySocialName_ShouldHandleInvalidMappingResult(string socialName)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            companyRepositoryMock.Setup(repo => repo.GetBySocialName(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => companyAppService.GetBySocialName(socialName));
        }

        [Theory]
        [InlineData("49.859.881/0001-90", "Americanas", "Lojas Americanas", "2017-3-1")]
        [InlineData("27.562.604/0001-88", "Walmart", "Walmart Brasil", "1999-9-12")]
        [InlineData("54.628.754/0001-10", "Carrefour", "Carrefour Brasil", "2000-5-11")]
        public async Task GetCompanyByCnpj_ShouldReturnsCompanyViewModel(string cnpj, string socialName, string fantasyName, DateTime fundationDate)
		{
            var companyRepositoryMock = new Mock<ICompanyRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var companyAppService = new CompanyAppService(
				companyRepositoryMock.Object,
				mediatorHandlerMock.Object,
				mapperMock.Object);

			var companyEntity = new Company(cnpj, socialName, fantasyName, fundationDate);
			companyRepositoryMock.Setup(repo => repo.GetByCnpj(cnpj)).ReturnsAsync(companyEntity);

			var expectedViewModel = new CompanyViewModel()
            {
                Id = companyEntity.Id,
                Cnpj = cnpj,
                SocialName = socialName,
                FantasyName = fantasyName,
                FundationDate = fundationDate
            };

			mapperMock.Setup(mapper => mapper.Map<CompanyViewModel>(companyEntity)).Returns(expectedViewModel);

			// Act
			var result = await companyAppService.GetByCnpj(cnpj);

			// Assert
			Assert.Equal(expectedViewModel, result);
		}

        [Theory]
        [InlineData("49.859.881/0001-90")]
        [InlineData("27.562.604/0001-88")]
        [InlineData("54.628.754/0001-10")]
        public async Task GetCompanyByCnpj_ShouldHandleNullRepositoryResult(string cnpj)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            companyRepositoryMock.Setup(repo => repo.GetByCnpj(It.IsAny<Cnpj>()))
                .ReturnsAsync((Company)null); // Simulate null result from the repository

            // Act
            var result = await companyAppService.GetByCnpj(cnpj);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("49.859.881/0001-90")]
        [InlineData("27.562.604/0001-88")]
        [InlineData("54.628.754/0001-10")]
        public async Task GetCompanyByCnpj_ShouldHandleInvalidMappingResult(string cnpj)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            companyRepositoryMock.Setup(repo => repo.GetByCnpj(It.IsAny<Cnpj>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => companyAppService.GetByCnpj(cnpj));
        }

        [Theory]
        [InlineData("09.641.757/0001-39", "Carrefour", "Carrefour Brasil", "2009-06-25")]
        [InlineData("02.581.860/0001-91", "Zé Ninguém", "Loja do Zé Ninguém", "2008-05-24")]
        [InlineData("26.613.282/0001-96", "Maria Ninguém", "Restaurante da Maria Ninguém", "2010-07-26")]
        public async Task GetCompanyByFantasyName_ShouldReturnMappedViewModel(string cnpj, string socialName, string fantasyName, DateTime fundationDate)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var companyEntity = new Company(cnpj, socialName, fantasyName, fundationDate);
            companyRepositoryMock.Setup(repo => repo.GetByFantasyName(fantasyName)).ReturnsAsync(companyEntity);

            var expectedViewModel = new CompanyViewModel()
            {
                Id = companyEntity.Id,
                Cnpj = cnpj,
                SocialName = socialName,
                FantasyName = fantasyName,
                FundationDate = fundationDate
            };
            mapperMock.Setup(mapper => mapper.Map<CompanyViewModel>(companyEntity)).Returns(expectedViewModel);

            // Act
            var result = await companyAppService.GetByFantasyName(fantasyName);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("Carrefour Brasil")]
        [InlineData("Loja do Zé Ninguém")]
        [InlineData("Restaurante da Maria Ninguém")]
        public async Task GetCompanyByFantasyName_ShouldHandleNullRepositoryResult(string fantasyName)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            companyRepositoryMock.Setup(repo => repo.GetByFantasyName(It.IsAny<string>()))
                .ReturnsAsync((Company)null); // Simulate null result from the repository

            // Act
            var result = await companyAppService.GetByFantasyName(fantasyName);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("Carrefour Brasil")]
        [InlineData("Loja do Zé Ninguém")]
        [InlineData("Restaurante da Maria Ninguém")]
        public async Task GetCompanyByFantasyName_ShouldHandleInvalidMappingResult(string fantasyName)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            companyRepositoryMock.Setup(repo => repo.GetByFantasyName(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => companyAppService.GetByFantasyName(fantasyName));
        }

        [Theory]
        [InlineData("09.641.757/0001-39", "Carrefour", "Carrefour Brasil", "2011-08-27")]
        [InlineData("02.581.860/0001-91", "Zé Ninguém", "Loja do Zé Ninguém", "2012-09-28")]
        [InlineData("26.613.282/0001-96", "Maria Ninguém", "Restaurante da Maria Ninguém", "2013-10-29")]
        public async Task Save_ShouldAddCompanyToRepository(string cnpj, string socialName, string fantasyName, DateTime fundationDate)
        {
            // Arrange
            var createCompanyCommand = new CreateCompanyCommand()
            {
                Cnpj = cnpj,
                SocialName = socialName,
                FantasyName = fantasyName,
                FundationDate = fundationDate
            };

            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CompanyAppService(
               companyRepositoryMock.Object,
               mediatorHandlerMock.Object,
               mapperMock.Object
            );

            // Act
            await customerAppService.Save(createCompanyCommand);

            // Assert
            companyRepositoryMock.Verify(repo => repo.Add(It.IsAny<Company>()), Times.Once);
        }

        [Fact]
        public async Task Save_ShouldHandleNullRepositoryResult()
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            CreateCompanyCommand commandCreate = null;

            companyRepositoryMock.Setup(repo => repo.Add(It.IsAny<Company>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => companyAppService.Save(commandCreate));

        }
        
        [Theory]
        [InlineData("09.641.757/0001-39", "Carrefour", "Carrefour Brasil", "2011-08-27")]
        [InlineData("02.581.860/0001-91", "Zé Ninguém", "Loja do Zé Ninguém", "2012-09-28")]
        [InlineData("26.613.282/0001-96", "Maria Ninguém", "Restaurante da Maria Ninguém", "2013-10-29")]
        public async Task Save_ShouldHandleInvalidMappingResult(string cnpj, string socialName, string fantasyName, DateTime fundationDate)
        {

            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var commandCreate = new CreateCompanyCommand()
            {
                Cnpj = cnpj,
                SocialName = socialName,
                FantasyName = fantasyName,
                FundationDate = fundationDate
            };

            // Act       
            companyRepositoryMock.Setup(repo => repo.Add(It.IsAny<Company>()))
            .Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => companyAppService.Save(commandCreate));
        }

    }
}

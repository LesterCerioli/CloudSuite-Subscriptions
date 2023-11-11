using System.Threading.Tasks;
using AutoMapper;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using Moq;
using NetDevPack.Mediator;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services
{
    public class CompanyAppServiceTest
    {
        [Fact]
        public async Task GetByCnpj_ShouldReturnCompanyViewModel()
        {
            // Arrange
            var mockCompanyRepository = new Mock<ICompanyRepository>();
            var mockMediatorHandler = new Mock<IMediatorHandler>();
            var mockMapper = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                mockCompanyRepository.Object,
                mockMediatorHandler.Object,
                mockMapper.Object
            );

            var mockCompany = new Company
            {
                // Set up your mock Company object as needed
            };

            var expectedViewModel = new CompanyViewModel
            {
                // Set up your expected ViewModel object as needed
            };

            mockCompanyRepository.Setup(repo => repo.GetByCnpj(It.IsAny<Cnpj>()))
                .ReturnsAsync(mockCompany);

            mockMapper.Setup(m => m.Map<CompanyViewModel>(It.IsAny<Company>()))
                .Returns(expectedViewModel);

            // Act
            var result = await companyAppService.GetByCnpj(new Cnpj("your_cnpj_here"));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedViewModel, result);

        }

    }
}
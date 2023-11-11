using System.Threading.Tasks;
using AutoMapper;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;
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
            using (var context = new MyDbContext(_dbContextOptions))
            {
                // Mock dependencies
                var mockCompanyRepository = new Mock<ICompanyRepository>();
                var mockMediatorHandler = new Mock<IMediatorHandler>();
                var mockMapper = new Mock<IMapper>();

                // Create an instance of CompanyRepository using the in-memory database context
                var companyRepository = new CompanyRepository(context);

                var companyAppService = new CompanyAppService(
                    companyRepository,
                    mockMediatorHandler.Object,
                    mockMapper.Object
                );

                var mockCompany = new Company(new Cnpj("12345678901234"), "MockSocialName", "MockFantasyName");

                var expectedViewModel = new CompanyViewModel
                {
                    // Set up your expected ViewModel object as needed
                };

                // Seed the in-memory database with a mock company
                context.Companies.Add(mockCompany);
                context.SaveChanges();

                mockCompanyRepository.Setup(repo => repo.GetByCnpj(It.IsAny<Cnpj>()))
                    .ReturnsAsync(mockCompany);

                mockMapper.Setup(m => m.Map<CompanyViewModel>(It.IsAny<Company>()))
                    .Returns(expectedViewModel);

                // Act
                var result = await companyAppService.GetByCnpj(new Cnpj("12345678901234"));

                // Assert
                Assert.NotNull(result);
                Assert.Equal(expectedViewModel, result);
            }

        }

    }
}
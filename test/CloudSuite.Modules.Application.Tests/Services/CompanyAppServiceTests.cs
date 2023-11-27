using System.Threading.Tasks;
using AutoMapper;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using Moq;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Tests.Services
{
    public class CompanyAppServiceTests
    {
       public async Task GetbyCnpj_ShouldsReturnsMappedViewModels() 
       {
           var cnpj = new Cnpj("12435665000100");
           var companyRepositoryMock = new Mock<ICompanyRepository>();
           var mediatorHandlerMock = new Mock<IMediatorHandler>();
           var mapperMock = new Mock<IMapper>();

           var companyAppService = new CompanyAppService()

        //    var result = await sut.GetByCnpj(new Cnpj("12345678901"));

        //    result.Should().NotBeNull();
        //

       }
    }
}
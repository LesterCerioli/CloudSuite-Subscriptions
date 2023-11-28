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
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services
{
    public class CustomerAppServiceTests
    {
        [Fact]
        public async Task GetByBusinessOwner_ShouldReturnMappedViewModel()
        {
            // Arrange
            var cnpj = new Cnpj("76.883.915/0001-54");
            var name = new Name("Lojas","Americanas");
            var email = new Email("americanas@dominio.com");
            var bussinessOwner = "Claudio Van Hussen";
            var createdOn = new DateTimeOffset(2022, 10, 23, 14, 0, 0, TimeSpan.Zero);
            var company = new Company(new Cnpj(), "b2w", "ponto frio");

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var customerEntity = new Customer(name, cnpj, email, bussinessOwner, createdOn, company);
            customerRepositoryMock.Setup(repo => repo.GetByBusinessOwner(bussinessOwner)).ReturnsAsync(customerEntity);

            var expectedViewModel = new CustomerViewModel();
            mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

            // Act
            var result = await customerAppService.GetByBusinessOwner(bussinessOwner);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Fact]
        public async Task GetByCreatedOn_ShouldReturnMappedViewModel()
        {
            // Arrange
            var cnpj = new Cnpj("76.883.915/0001-54");
            var name = new Name("Lojas", "Americanas");
            var email = new Email("americanas@dominio.com");
            var bussinessOwner = "Claudio Van Hussen";
            var createdOn = new DateTimeOffset(2022, 10, 23, 14, 0, 0, TimeSpan.Zero);
            var company = new Company(new Cnpj(), "b2w", "ponto frio");

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var customerEntity = new Customer(name, cnpj, email, bussinessOwner, createdOn, company);
            customerRepositoryMock.Setup(repo => repo.GetByCreatedOn(createdOn)).ReturnsAsync(customerEntity);

            var expectedViewModel = new CustomerViewModel();
            mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

            // Act
            var result = await customerAppService.GetByCreatedOn(createdOn);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Fact]
        public async Task GetByEmail_ShouldReturnMappedViewModel()
        {
            // Arrange
            var cnpj = new Cnpj("76.883.915/0001-54");
            var name = new Name("Lojas", "Americanas");
            var email = new Email("americanas@dominio.com");
            var bussinessOwner = "Claudio Van Hussen";
            var createdOn = new DateTimeOffset(2022, 10, 23, 14, 0, 0, TimeSpan.Zero);
            var company = new Company(new Cnpj(), "b2w", "ponto frio");

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var customerEntity = new Customer(name, cnpj, email, bussinessOwner, createdOn, company);
            customerRepositoryMock.Setup(repo => repo.GetByEmail(email)).ReturnsAsync(customerEntity);

            var expectedViewModel = new CustomerViewModel();
            mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

            // Act
            var result = await customerAppService.GetByEmail(email);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Fact]
        public async Task GetByCnpj_ShouldReturnMappedViewModel()
        {
            // Arrange
            var cnpj = new Cnpj("76.883.915/0001-54");
            var name = new Name("Lojas", "Americanas");
            var email = new Email("americanas@dominio.com");
            var bussinessOwner = "Claudio Van Hussen";
            var createdOn = new DateTimeOffset(2022, 10, 23, 14, 0, 0, TimeSpan.Zero);
            var company = new Company(new Cnpj(), "b2w", "ponto frio");

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var customerEntity = new Customer(name, cnpj, email, bussinessOwner, createdOn, company);
            customerRepositoryMock.Setup(repo => repo.GetByCnpj(cnpj)).ReturnsAsync(customerEntity);

            var expectedViewModel = new CustomerViewModel();
            mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

            // Act
            var result = await customerAppService.GetByCnpj(cnpj);

            // Assert
            Assert.Equal(expectedViewModel, result); 
        }

        [Fact]
        public async Task GetByName_ShouldReturnMappedViewModel()
        {
            // Arrange
            var cnpj = new Cnpj("76.883.915/0001-54");
            var name = new Name("Lojas", "Americanas");
            var email = new Email("americanas@dominio.com");
            var bussinessOwner = "Claudio Van Hussen";
            var createdOn = new DateTimeOffset(2022, 10, 23, 14, 0, 0, TimeSpan.Zero);
            var company = new Company(new Cnpj(), "b2w", "ponto frio");

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var customerEntity = new Customer(name, cnpj, email, bussinessOwner, createdOn, company);
            customerRepositoryMock.Setup(repo => repo.GetByName(name)).ReturnsAsync(customerEntity);

            var expectedViewModel = new CustomerViewModel();
            mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

            // Act
            var result = await customerAppService.GetByName(name);

            // Assert
            Assert.Equal(expectedViewModel, result); 
        }
    }
}

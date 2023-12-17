using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Customers;
using CloudSuite.Modules.Application.Handlers.Domains;
using CloudSuite.Modules.Application.Handlers.Payments;
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
	public class CustomerAppServiceTests
	{
        [Theory]
        [InlineData("77.485.673/0001-03", "Alice", "Johnson", "alice.johnson@dominio.com", "Alicia", "2023-01-01", "73.817.687/0001-26", "Empresa DEF", "Loja DEF", "2002-02-02")]
        [InlineData("24.266.482/0001-94", "Bob", "Smith", "bob.smith@dominio.com", "Roberto", "2023-03-03", "62.604.571/0001-92", "Empresa GHI", "Loja GHI", "2004-04-04")]
        [InlineData("66.449.319/0001-07", "Charlie", "Brown", "charlie.brown@dominio.com", "Carlos", "2023-05-05", "51.368.327/0001-51", "Empresa JKL", "Loja JKL", "2006-06-06")]
        public async Task GetCustomerByBusinessOwner_ShouldReturnCustomerViewModel(string cnpjNumber, string firstName, string lastName, string emailAdress, string bussinessOwner, DateTimeOffset createdOn, string cnpjCompany, string socialName, string fantasyName, DateTime fundationDate)
		{
            // Arrange
            var cnpj = new Cnpj(cnpjNumber);
            var name = new Name(firstName, lastName);
            var email = new Email(emailAdress);
            var customerRepositoryMock = new Mock<ICustomerRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var customerAppService = new CustomerAppService(
				customerRepositoryMock.Object,
				mapperMock.Object,
				mediatorHandlerMock.Object
            );

			var customerEntity = new Customer(name, cnpj, email, bussinessOwner, createdOn);
			customerRepositoryMock.Setup(repo => repo.GetByBusinessOwner(bussinessOwner)).ReturnsAsync(customerEntity);

            var expectedViewModel = new CustomerViewModel()
            {
                Name = firstName,
                Cnpj = cnpjNumber,
                Email = emailAdress,
                BusinessOwner = bussinessOwner,
                CreatedOn = createdOn
                
            };
			mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

			// Act
			var result = await customerAppService.GetByBusinessOwner(bussinessOwner);

			// Assert
			Assert.Equal(expectedViewModel, result);
		}

        [Theory]
        [InlineData("Alicia")]
        [InlineData("Roberto")]
        [InlineData("Carlos")]
        public async Task GetCustomerByBusinessOwner_ShouldHandleNullRepositoryResult(string businessOwner)
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            customerRepositoryMock.Setup(repo => repo.GetByBusinessOwner(It.IsAny<string>()))
                .ReturnsAsync((Customer)null); // Simulate null result from the repository

            // Act
            var result = await customerAppService.GetByBusinessOwner(businessOwner);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("Alicia")]
        [InlineData("Roberto")]
        [InlineData("Carlos")]
        public async Task GetCustomerByBusinessOwner_ShouldHandleInvalidMappingResult(string businessOwner)
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            customerRepositoryMock.Setup(repo => repo.GetByBusinessOwner(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => customerAppService.GetByBusinessOwner(businessOwner));
        }

        [Theory]
        [InlineData("76.883.915/0001-54", "John", "Doe","emaildaempresa@seudominio.com", "Diones", "2021-04-25", "57.344.793/0001-83", "B2W","Lojas Americanas", "1998-03-21" )]
        [InlineData("93.216.371/0001-96", "Jane", "Smith", "email1@dominio.com", "Carlos", "2022-05-30", "31.498.147/0001-87", "Empresa XYZ", "Loja XYZ", "2000-06-15")]
        [InlineData("95.939.218/0001-12", "Bob", "Johnson", "email2@dominio.com", "Roberto", "2022-06-30", "42.124.773/0001-20", "Empresa ABC", "Loja ABC", "2001-07-16")]
        public async Task GetByCreatedOn_ShouldReturnMappedViewModel(string cnpjNumber, string firstName, string lastName, string emailAdress, string bussinessOwner, DateTimeOffset createdOn, string cnpjCompany, string socialName, string fantasyName, DateTime fundationDate)
        {
            // Arrange
            var cnpj = new Cnpj(cnpjNumber);
            var name = new Name(firstName, lastName);
            var email = new Email(emailAdress);

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var customerEntity = new Customer(name, cnpj, email, bussinessOwner, createdOn);
            customerRepositoryMock.Setup(repo => repo.GetByCreatedOn(createdOn)).ReturnsAsync(customerEntity);

            var expectedViewModel = new CustomerViewModel()
            {
                Name = firstName,//verificar com o lester sobre a viewmodel
                Cnpj = cnpjNumber,
                Email = emailAdress,
                BusinessOwner = bussinessOwner,
                CreatedOn = createdOn
            };
            mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

            // Act
            var result = await customerAppService.GetByCreatedOn(createdOn);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("1998-03-21")]
        [InlineData("2000-06-15")]
        [InlineData("2001-07-16")]
        public async Task GetCustomerByCreatedOn_ShouldHandleNullRepositoryResult(DateTimeOffset createdOn)
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            customerRepositoryMock.Setup(repo => repo.GetByCreatedOn(It.IsAny<DateTimeOffset>()))
                .ReturnsAsync((Customer)null); // Simulate null result from the repository

            // Act
            var result = await customerAppService.GetByCreatedOn(createdOn);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("1998-03-21")]
        [InlineData("2000-06-15")]
        [InlineData("2001-07-16")]
        public async Task GetCustomerByCreatedOn_ShouldHandleInvalidMappingResult(DateTimeOffset createdOn)
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            customerRepositoryMock.Setup(repo => repo.GetByCreatedOn(It.IsAny<DateTimeOffset>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => customerAppService.GetByCreatedOn(createdOn));
        }


        [Theory]
        [InlineData("37.840.432/0001-10", "Harry", "Hill", "harry.hill@dominio.com", "Henrique", "2024-03-15")]
        [InlineData("68.224.923/0001-60", "Ivy", "Iverson", "ivy.iverson@dominio.com", "Ivone", "2024-05-17")]
        [InlineData("17.549.552/0001-56", "Jack", "Jackson", "jack.jackson@dominio.com", "João", "2024-07-19")]
        public async Task GetByEmail_ShouldReturnMappedViewModel(string cnpjNumber, string firstName, string lastName, string emailAdress, string bussinessOwner, DateTimeOffset createdOn)
        {
            // Arrange
            var cnpj = new Cnpj(cnpjNumber);
            var name = new Name(firstName, lastName);
            var email = new Email(emailAdress);

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var customerEntity = new Customer(name, cnpj, email, bussinessOwner, createdOn);
            customerRepositoryMock.Setup(repo => repo.GetByEmail(email)).ReturnsAsync(customerEntity);

            var expectedViewModel = new CustomerViewModel()
            {
                Name = firstName,//verificar com o lester sobre a viewmodel
                Cnpj = cnpjNumber,
                Email = emailAdress,
                BusinessOwner = bussinessOwner,
                CreatedOn = createdOn
            };
            mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

            // Act
            var result = await customerAppService.GetByEmail(email);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("harry.hill@dominio.com")]
        [InlineData("ivy.iverson@dominio.com")]
        [InlineData("jack.jackson@dominio.com")]
        public async Task GetCustomerByEmail_ShouldHandleNullRepositoryResult(string emailAdress)
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            customerRepositoryMock.Setup(repo => repo.GetByEmail(It.IsAny<Email>()))
                .ReturnsAsync((Customer)null); // Simulate null result from the repository

            var email = new Email(emailAdress);

            // Act
            var result = await customerAppService.GetByEmail(email);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("harry.hill@dominio.com")]
        [InlineData("ivy.iverson@dominio.com")]
        [InlineData("jack.jackson@dominio.com")]
        public async Task GetCustomerByEmail_ShouldHandleInvalidMappingResult(string emailAdress)
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            customerRepositoryMock.Setup(repo => repo.GetByEmail(It.IsAny<Email>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            var email = new Email(emailAdress);

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => customerAppService.GetByEmail(email));
        }

        [Theory]
        [InlineData("50.396.936/0001-51", "Eva", "Evans", "eva.evans@dominio.com", "Eva", "2023-09-09")]
        [InlineData("27.967.357/0001-08", "Frank", "Franklin", "frank.franklin@dominio.com", "Francisco", "2023-11-11")]
        [InlineData("92.807.534/0001-42", "Grace", "Green", "grace.green@dominio.com", "Graça", "2024-01-13")]
        public async Task GetCustomerByCnpj_ShouldReturnMappedViewModel(string cnpjNumber, string firstName, string lastName, string emailAdress, string bussinessOwner, DateTimeOffset createdOn)
        {
            // Arrange
            var cnpj = new Cnpj(cnpjNumber);
            var name = new Name(firstName, lastName);
            var email = new Email(emailAdress);

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var customerEntity = new Customer(name, cnpj, email, bussinessOwner, createdOn);
            customerRepositoryMock.Setup(repo => repo.GetByCnpj(cnpj)).ReturnsAsync(customerEntity);

            var expectedViewModel = new CustomerViewModel()
            {
                Name = firstName,//verificar com o lester sobre a viewmodel
                Cnpj = cnpjNumber,
                Email = emailAdress,
                BusinessOwner = bussinessOwner,
                CreatedOn = createdOn
            };
            mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

            // Act
            var result = await customerAppService.GetByCnpj(cnpj);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("50.396.936/0001-51")]
        [InlineData("27.967.357/0001-08")]
        [InlineData("92.807.534/0001-42")]
        public async Task GetCustomerByCnpj_ShouldHandleNullRepositoryResult(string cnpj)
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            customerRepositoryMock.Setup(repo => repo.GetByCnpj(It.IsAny<Cnpj>()))
                .ReturnsAsync((Customer)null); // Simulate null result from the repository

            // Act
            var result = await customerAppService.GetByCnpj(cnpj);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("50.396.936/0001-51")]
        [InlineData("27.967.357/0001-08")]
        [InlineData("92.807.534/0001-42")]
        public async Task GetCustomerByCnpj_ShouldHandleInvalidMappingResult(string cnpj)
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            customerRepositoryMock.Setup(repo => repo.GetByCnpj(It.IsAny<Cnpj>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => customerAppService.GetByCnpj(cnpj));
        }

        [Theory]
        [InlineData("90.202.251/0001-41", "Bob", "Smith", "bob.smith@dominio.com", "Roberto", "2023-03-03")]
        [InlineData("43.147.942/0001-00", "Charlie", "Brown", "charlie.brown@dominio.com", "Carlos", "2023-05-05")]
        [InlineData("39.322.117/0001-27", "David", "Davis", "david.davis@dominio.com", "Davi", "2023-07-07")]
        public async Task Save_ShouldAddCustomerToRepository(string cnpjNumber, string firstName, string lastName, string emailAdress, string bussinessOwner, DateTimeOffset createdOn)
		{
			// Arrange
			var createCustomerCommand = new CreateCustomerCommand()
            {
                FirstName = firstName,
                LastName = lastName,
                Cnpj = cnpjNumber,
                Email = emailAdress,
                BusinessOwner = bussinessOwner,
                CreatedOn = createdOn
            };
			var customerRepositoryMock = new Mock<ICustomerRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var customerAppService = new CustomerAppService(
				customerRepositoryMock.Object,
				mapperMock.Object,
				mediatorHandlerMock.Object
			);

			// Act
			await customerAppService.Save(createCustomerCommand);

			// Assert
			customerRepositoryMock.Verify(repo => repo.Add(It.IsAny<Customer>()), Times.Once);
		}

        [Fact]
        public async Task Save_ShouldHandleNullRepositoryResult()
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
                );

            CreateCustomerCommand commandCreate = null;

            customerRepositoryMock.Setup(repo => repo.Add(It.IsAny<Customer>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => customerAppService.Save(commandCreate));

        }

        [Theory]
        [InlineData("90.202.251/0001-41", "Bob", "Smith", "bob.smith@dominio.com", "Roberto", "2023-03-03")]
        [InlineData("43.147.942/0001-00", "Charlie", "Brown", "charlie.brown@dominio.com", "Carlos", "2023-05-05")]
        [InlineData("39.322.117/0001-27", "David", "Davis", "david.davis@dominio.com", "Davi", "2023-07-07")]
        public async Task Save_ShouldHandleInvalidMappingResult(string cnpjNumber, string firstName, string lastName, string emailAdress, string bussinessOwner, DateTimeOffset createdOn)
        {

            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var customerAppService = new CustomerAppService(
                customerRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
                );

            var commandCreate = new CreateCustomerCommand()
            {
               FirstName = firstName,
               LastName = lastName,
               Cnpj = cnpjNumber,
               Email = emailAdress,
               BusinessOwner = bussinessOwner,
               CreatedOn = createdOn
            };

            // Act       
            customerRepositoryMock.Setup(repo => repo.Add(It.IsAny<Customer>()))
            .Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => customerAppService.Save(commandCreate));
        }
    }
}

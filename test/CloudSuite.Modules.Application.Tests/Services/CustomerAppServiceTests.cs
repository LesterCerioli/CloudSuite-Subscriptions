using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Customers;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using Moq;
using NetDevPack.Mediator;
using NetDevPack.Messaging;
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
        [InlineData("77.485.673/0001-03", "Alice", "Johnson", "alice.johnson@dominio.com", "Alicia", "2023-01-01", "73.817.687/0001-26", "Empresa DEF", "Loja DEF", "2002-02-02")]
        [InlineData("24.266.482/0001-94", "Bob", "Smith", "bob.smith@dominio.com", "Roberto", "2023-03-03", "62.604.571/0001-92", "Empresa GHI", "Loja GHI", "2004-04-04")]
        [InlineData("66.449.319/0001-07", "Charlie", "Brown", "charlie.brown@dominio.com", "Carlos", "2023-05-05", "51.368.327/0001-51", "Empresa JKL", "Loja JKL", "2006-06-06")]
        public async Task GetCustomerByBusinessOwner_ShouldReturnCustomerViewModel(string cnpjNumber, string firstName, string lastName, string emailAdress, string bussinessOwner, DateTimeOffset createdOn, string cnpjCompany, string socialName, string fantasyName, DateTime fundationDate)
		{
            // Arrange
            var cnpj = new Cnpj(cnpjNumber);
            var name = new Name(firstName, lastName);
            var email = new Email(emailAdress);
            var company = new Company(new Cnpj(cnpjCompany), socialName, fantasyName, fundationDate);
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

			var expectedViewModel = new CustomerViewModel()
            {
                Name = firstName,//verificar com o lester sobre a viewmodel
                Cnpj = cnpjNumber,
                Email = emailAdress,
                BusinessOwner = bussinessOwner,
                CreatedOn = createdOn,
               // Company = company
                
            };
			mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

			// Act
			var result = await customerAppService.GetByBusinessOwner(bussinessOwner);

			// Assert
			Assert.Equal(expectedViewModel, result);
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
            var company = new Company(new Cnpj(cnpjCompany), socialName, fantasyName, fundationDate);

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

            var expectedViewModel = new CustomerViewModel()
            {
                //verificar a view models com o lester
            };
            mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

            // Act
            var result = await customerAppService.GetByCreatedOn(createdOn);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("37.840.432/0001-10", "Harry", "Hill", "harry.hill@dominio.com", "Henrique", "2024-03-15", "71.569.663/0001-70", "Empresa YZ", "Loja YZ", "2016-04-16")]
        [InlineData("68.224.923/0001-60", "Ivy", "Iverson", "ivy.iverson@dominio.com", "Ivone", "2024-05-17", "71.569.663/0001-70", "Empresa ZA", "Loja ZA", "2018-06-18")]
        [InlineData("17.549.552/0001-56", "Jack", "Jackson", "jack.jackson@dominio.com", "João", "2024-07-19", "15.638.799/0001-13", "Empresa AB", "Loja AB", "2020-08-20")]
        public async Task GetByEmail_ShouldReturnMappedViewModel(string cnpjNumber, string firstName, string lastName, string emailAdress, string bussinessOwner, DateTimeOffset createdOn, string cnpjCompany, string socialName, string fantasyName, DateTime fundationDate)
        {
            // Arrange
            var cnpj = new Cnpj(cnpjNumber);
            var name = new Name(firstName, lastName);
            var email = new Email(emailAdress);
            var company = new Company(new Cnpj(cnpjCompany), socialName, fantasyName, fundationDate);

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

            var expectedViewModel = new CustomerViewModel()
            {
                //VErificar as view models
            };
            mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

            // Act
            var result = await customerAppService.GetByEmail(email);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("50.396.936/0001-51", "Eva", "Evans", "eva.evans@dominio.com", "Eva", "2023-09-09", "04.670.881/0001-09", "Empresa PQR", "Loja PQR", "2010-10-10")]
        [InlineData("27.967.357/0001-08", "Frank", "Franklin", "frank.franklin@dominio.com", "Francisco", "2023-11-11", "52.136.577/0001-29", "Empresa STU", "Loja STU", "2012-12-12")]
        [InlineData("92.807.534/0001-42", "Grace", "Green", "grace.green@dominio.com", "Graça", "2024-01-13", "99.793.557/0001-94", "Empresa VWX", "Loja VWX", "2014-02-14")]
        public async Task GetByCnpj_ShouldReturnMappedViewModel(string cnpjNumber, string firstName, string lastName, string emailAdress, string bussinessOwner, DateTimeOffset createdOn, string cnpjCompany, string socialName, string fantasyName, DateTime fundationDate)
        {
            // Arrange
            var cnpj = new Cnpj(cnpjNumber);
            var name = new Name(firstName, lastName);
            var email = new Email(emailAdress);
            var company = new Company(new Cnpj(cnpjCompany), socialName, fantasyName, fundationDate);

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

            var expectedViewModel = new CustomerViewModel()
            {
                //veririfcar as view models
            };
            mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

            // Act
            var result = await customerAppService.GetByCnpj(cnpj);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("90.202.251/0001-41", "Bob", "Smith", "bob.smith@dominio.com", "Roberto", "2023-03-03", "47.510.462/0001-12", "Empresa GHI", "Loja GHI", "2004-04-04")]
        [InlineData("43.147.942/0001-00", "Charlie", "Brown", "charlie.brown@dominio.com", "Carlos", "2023-05-05", "95.007.084/0001-00", "Empresa JKL", "Loja JKL", "2006-06-06")]
        [InlineData("39.322.117/0001-27", "David", "Davis", "david.davis@dominio.com", "Davi", "2023-07-07", "89.469.600/0001-07", "Empresa MNO", "Loja MNO", "2008-08-08")]
        public async Task Save_ShouldAddCustomerToRepository(string cnpjNumber, string firstName, string lastName, string emailAdress, string bussinessOwner, DateTimeOffset createdOn, string cnpjCompany, string socialName, string fantasyName, DateTime fundationDate)
		{
			// Arrange
			var createCustomerCommand = new CreateCustomerCommand()
            {
                FirstName = firstName,
                LastName = lastName,
                Cnpj = cnpjNumber,
                Email = emailAdress,
                BusinessOwner = bussinessOwner,
                CreatedOn = createdOn,
                Company = new Company(new Cnpj(cnpjCompany), socialName, fantasyName, fundationDate)
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
	}
}

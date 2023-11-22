using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Customers;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
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

namespace CloudSuite.Modules.Application.Tests.Service3s
{
	public class CustomerAppServiceTests
	{
		
		[Fact]
		public async Task GetByBusinessOwner_ShouldReturnCustomerViewModel()
		{
			var customerRepositoryMock = new Mock<ICustomerRepository>();
			var mapperMock = new Mock<IMapper>();

			var customerAppService = new CustomerAppService(
				customerRepositoryMock.Object,
				mapperMock.Object,
				It.IsAny<IMediatorHandler>());

			var businessowner = "John Doe";

			var customerModel = new CustomerViewModel();

			var expectedViewModel = new CustomerViewModel();


						
		}

		[Fact]
		public void Dispose_ShouldSuppressFinalize()
		{
			var customerRepositoryMock = new Mock<ICustomerRepository>();

			var mapperMock = new Mock<IMapper>();

			var customerAppService = new CustomerAppService(
				customerRepositoryMock.Object,
				mapperMock.Object,
				It.IsAny<IMediatorHandler>()
			);

			//Assert
			customerAppService.Dispose();

			// Assert
			//customerRepositoryMock.Verify(repo => repo.Dispose(), Times.Once);
		}

		// Example of a test for Save method
		[Fact]
		public async Task Save_ShouldThrowNotImplementedException()
		{
			// Arrange
			var customerRepositoryMock = new Mock<ICustomerRepository>();
			var mapperMock = new Mock<IMapper>();

			var customerAppService = new CustomerAppService(
				customerRepositoryMock.Object,
				mapperMock.Object,
				It.IsAny<IMediatorHandler>()
			);

			var createCustomerCommand = new CreateCustomerCommand(); // Replace with a valid CreateCustomerCommand object

			// Act and Assert
			await Assert.ThrowsAsync<NotImplementedException>(() => customerAppService.Save(createCustomerCommand));
		}


	}
}

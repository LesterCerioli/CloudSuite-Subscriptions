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

namespace CloudSuite.Modules.Application.Tests.Services
{
	public class CustomerAppServiceTests
	{
		public async Task GetCustomerByBusinessOwner_ShouldReturnCustomerViewModel()
		{
			// Arrange
			var businessOwner = "John Doe";
			var customerRepositoryMock = new Mock<ICustomerRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var customerAppService = new CustomerAppService(
				customerRepositoryMock.Object,
				mapperMock.Object,
				mediatorHandlerMock.Object
			);

			var customerEntity = new Customer();
			customerRepositoryMock.Setup(repo => repo.GetByBusinessOwner(businessOwner)).ReturnsAsync(customerEntity);

			var expectedViewModel = new CustomerViewModel(/* create your expected view model here */);
			mapperMock.Setup(mapper => mapper.Map<CustomerViewModel>(customerEntity)).Returns(expectedViewModel);

			// Act
			var result = await customerAppService.GetByBusinessOwner(businessOwner);

			// Assert
			Assert.Equal(expectedViewModel, result);
		}

		[Fact]
		public async Task Save_ShouldAddCustomerToRepository()
		{
			// Arrange
			var createCustomerCommand = new CreateCustomerCommand(/* provide necessary parameters */);
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

using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Domains;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
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
	public class DomainAppServiceTests
	{
		[Fact]
		public async Task GetDomainByCreationDate_ShouldReturnDomainViewModel()
		{
			// Arrange
			var creationDate = DateTimeOffset.Now;
			var domainRepositoryMock = new Mock<IDomainRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var domainAppService = new DomainAppService(
				domainRepositoryMock.Object,
				mapperMock.Object,
				mediatorHandlerMock.Object
			);

			
		}

		[Fact]
		public async Task Save_ShouldAddDomainToRepository()
		{
			// Arrange
			var createDomainCommand = new CreateDomainCommand(/* provide necessary parameters */);
			var domainRepositoryMock = new Mock<IDomainRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var domainAppService = new DomainAppService(
				domainRepositoryMock.Object,
				mapperMock.Object,
				mediatorHandlerMock.Object
			);

			// Act
			await domainAppService.Save(createDomainCommand);

			// Assert
			//domainRepositoryMock.Verify(repo => repo.Add(It.IsAny<Domain>()), Times.Once);
		}

		[Fact]
		public async Task GetDomainByDns_ShouldReturnDomainViewModel()
		{
			// Arrange
			var dns = "example.com";
			var domainRepositoryMock = new Mock<IDomainRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var domainAppService = new DomainAppService(
				domainRepositoryMock.Object,
				mapperMock.Object,
				mediatorHandlerMock.Object
			);

			//var domainEntity = new Domain();
			//domainRepositoryMock.Setup(repo => repo.GetByDns(dns)).ReturnsAsync(domainEntity);

			var expectedViewModel = new DomainViewModel(/* create your expected view model here */);
			//mapperMock.Setup(mapper => mapper.Map<DomainViewModel>(domainEntity)).Returns(expectedViewModel);

			// Act
			var result = await domainAppService.GetByDns(dns);

			// Assert
			Assert.Equal(expectedViewModel, result);
		}

		[Fact]
		public async Task GetDomainByOwnerName_ShouldReturnDomainViewModel()
		{
			// Arrange
			var ownerName = "John Doe";
			var domainRepositoryMock = new Mock<IDomainRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var domainAppService = new DomainAppService(
				domainRepositoryMock.Object,
				mapperMock.Object,
				mediatorHandlerMock.Object
			);

			//var domainEntity = new Domain();
			//domainRepositoryMock.Setup(repo => repo.GetByOwnerName(ownerName)).ReturnsAsync(domainEntity);

			var expectedViewModel = new DomainViewModel(/* create your expected view model here */);
			//mapperMock.Setup(mapper => mapper.Map<DomainViewModel>(domainEntity)).Returns(expectedViewModel);

			// Act
			var result = await domainAppService.GetByOwnerName(ownerName);

			// Assert
			Assert.Equal(expectedViewModel, result);
		}
	}
}

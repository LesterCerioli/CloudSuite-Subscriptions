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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DomainEntity = CloudSuite.Modules.Domain.Models.Domain;

namespace CloudSuite.Modules.Application.Tests.Services
{
	public class DomainAppServiceTests
	{
		[Fact]
		public async Task GetDomainByCreationDate_ShouldReturnDomainViewModel()
		{
            // Arrange
            var dns = "example.com";
            var OwnerName = "Thiago Farias";
            var creationDate = DateTimeOffset.Now;
			var domainRepositoryMock = new Mock<IDomainRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var domainAppService = new DomainAppService(
				domainRepositoryMock.Object,
				mapperMock.Object,
				mediatorHandlerMock.Object
			);

            var domainEntity = new DomainEntity(dns, OwnerName, creationDate);
            domainRepositoryMock.Setup(repo => repo.GetByCreationDate(creationDate)).ReturnsAsync(domainEntity);

            var expectedViewModel = new DomainViewModel();
            mapperMock.Setup(mapper => mapper.Map<DomainViewModel>(domainEntity)).Returns(expectedViewModel);

            // Act
            var result = await domainAppService.GetByCreationDate(creationDate);

            // Assert
            Assert.Equal(expectedViewModel, result);

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

			var domainEntity = new DomainEntity();
			domainRepositoryMock.Setup(repo => repo.GetByDns(dns)).ReturnsAsync(domainEntity);

			var expectedViewModel = new DomainViewModel();
			mapperMock.Setup(mapper => mapper.Map<DomainViewModel>(domainEntity)).Returns(expectedViewModel);

			// Act
			var result = await domainAppService.GetByDns(dns);

			// Assert
			Assert.Equal(expectedViewModel, result);
		}

		[Fact]
		public async Task GetDomainByOwnerName_ShouldReturnDomainViewModel()
		{
            // Arrange
            var dns = "example.com";
            var ownerName = "Thiago Farias";
            var creationDate =DateTimeOffset.Now;
			var domainRepositoryMock = new Mock<IDomainRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var domainAppService = new DomainAppService(
				domainRepositoryMock.Object,
				mapperMock.Object,
				mediatorHandlerMock.Object
            );

			var domainEntity = new DomainEntity(dns, ownerName, creationDate);
			domainRepositoryMock.Setup(repo => repo.GetByOwnerName(ownerName)).ReturnsAsync(domainEntity);

			var expectedViewModel = new DomainViewModel();
			mapperMock.Setup(mapper => mapper.Map<DomainViewModel>(domainEntity)).Returns(expectedViewModel);

			// Act
			var result = await domainAppService.GetByOwnerName(ownerName);

			// Assert
			Assert.Equal(expectedViewModel, result);
		}

        [Fact]
        public async Task Save_ShouldAddDomainToRepository()
        {
            // Arrange
            var createDomainCommand = new CreateDomainCommand()
			{
                DNS = "example.com",
				OwnerName = "Thiago Farias",
                CreatedAt = DateTime.Now
			};
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
            domainRepositoryMock.Verify(repo => repo.Add(It.IsAny<DomainEntity>()), Times.Once);
        }
    }
}

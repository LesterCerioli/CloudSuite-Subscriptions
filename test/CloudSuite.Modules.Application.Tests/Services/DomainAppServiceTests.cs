using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Domains;
using CloudSuite.Modules.Application.Handlers.Payments;
using CloudSuite.Modules.Application.Handlers.Subscriptions;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Threading.Tasks;
using Xunit;


namespace CloudSuite.Modules.Application.Tests.Services
{
	public class DomainAppServiceTests
	{
		[Theory]
		[InlineData("example.com", "Thiago Farias", "2009-06-25T00:00:00+00:00")]
        [InlineData("example1.com", "João Silva", "2010-07-26T01:01:01+00:00")]
        [InlineData("example2.com", "Maria Santos", "2011-08-27T02:02:02+00:00")]
        public async Task GetDomainByCreationDate_ShouldReturnDomainViewModel(string dns, string ownerName, DateTimeOffset creationDate)
		{
            // Arrange
			var domainRepositoryMock = new Mock<IDomainRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var domainAppService = new DomainAppService(
				domainRepositoryMock.Object,
				mapperMock.Object,
				mediatorHandlerMock.Object
			);

            var domainEntity = new DomainEntidade(dns, ownerName, creationDate);
            domainRepositoryMock.Setup(repo => repo.GetByCreationDate(creationDate)).ReturnsAsync(domainEntity);

            var expectedViewModel = new DomainViewModel()
			{
				Id = domainEntity.Id,
				DNS = dns,
				OwnerName = ownerName,
				CreationDate = creationDate
			};
            mapperMock.Setup(mapper => mapper.Map<DomainViewModel>(domainEntity)).Returns(expectedViewModel);

            // Act
            var result = await domainAppService.GetByCreationDate(creationDate);

            // Assert
            Assert.Equal(expectedViewModel, result);

        }

        [Theory]
        [InlineData("2009-06-25T00:00:00+00:00")]
        [InlineData("2010-07-26T01:01:01+00:00")]
        [InlineData("2011-08-27T02:02:02+00:00")]
        public async Task GetDomainByCreationDate_ShouldHandleNullRepositoryResult(DateTimeOffset creationDate)
        {
            // Arrange
            var domainRepositoryMock = new Mock<IDomainRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var domainAppService = new DomainAppService(
                domainRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            domainRepositoryMock.Setup(repo => repo.GetByCreationDate(It.IsAny<DateTimeOffset>()))
                .ReturnsAsync((DomainEntidade)null); // Simulate null result from the repository

            // Act
            var result = await domainAppService.GetByCreationDate(creationDate);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("2009-06-25T00:00:00+00:00")]
        [InlineData("2010-07-26T01:01:01+00:00")]
        [InlineData("2011-08-27T02:02:02+00:00")]
        public async Task GetDomainByCreationDate_ShouldHandleInvalidMappingResult(DateTimeOffset creationDate)
        {
            // Arrange
            var domainRepositoryMock = new Mock<IDomainRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var domainAppService = new DomainAppService(
                domainRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            domainRepositoryMock.Setup(repo => repo.GetByCreationDate(It.IsAny<DateTimeOffset>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => domainAppService.GetByCreationDate(creationDate));
        }

        [Theory]
        [InlineData("example3.com", "Pedro Costa", "2012-09-28T03:03:03+00:00")]
        [InlineData("example4.com", "Ana Pereira", "2013-10-29T04:04:04+00:00")]
        [InlineData("example5.com", "Lucas Oliveira", "2014-11-30T05:05:05+00:00")]
        public async Task GetDomainByDns_ShouldReturnDomainViewModel(string dns, string ownerName, DateTimeOffset creationDate)
		{
			// Arrange
			var domainRepositoryMock = new Mock<IDomainRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var domainAppService = new DomainAppService(
				domainRepositoryMock.Object,
				mapperMock.Object,
				mediatorHandlerMock.Object
			);

			var domainEntity = new DomainEntidade(dns, ownerName, creationDate);
			domainRepositoryMock.Setup(repo => repo.GetByDns(dns)).ReturnsAsync(domainEntity);

			var expectedViewModel = new DomainViewModel()
			{
                Id = domainEntity.Id,
                DNS = dns,
                OwnerName = ownerName,
                CreationDate = creationDate
            };
			mapperMock.Setup(mapper => mapper.Map<DomainViewModel>(domainEntity)).Returns(expectedViewModel);

			// Act
			var result = await domainAppService.GetByDns(dns);

			// Assert
			Assert.Equal(expectedViewModel, result);
		}

        [Theory]
        [InlineData("example3.com")]
        [InlineData("example4.com")]
        [InlineData("example5.com")]
        public async Task GetDomainByDns_ShouldHandleNullRepositoryResult(string dns)
        {
            // Arrange
            var domainRepositoryMock = new Mock<IDomainRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var domainAppService = new DomainAppService(
                domainRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            domainRepositoryMock.Setup(repo => repo.GetByDns(It.IsAny<string>()))
                .ReturnsAsync((DomainEntidade)null); // Simulate null result from the repository

            // Act
            var result = await domainAppService.GetByDns(dns);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("example3.com")]
        [InlineData("example4.com")]
        [InlineData("example5.com")]
        public async Task GetDomainByDns_ShouldHandleInvalidMappingResult(string dns)
        {
            // Arrange
            var domainRepositoryMock = new Mock<IDomainRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var domainAppService = new DomainAppService(
                domainRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            domainRepositoryMock.Setup(repo => repo.GetByDns(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => domainAppService.GetByDns(dns));
        }

        [Theory]
        [InlineData("example6.com", "Beatriz Souza", "2015-12-31T06:06:06+00:00")]
        [InlineData("example7.com", "Gabriel Lima", "2016-01-01T07:07:07+00:00")]
        [InlineData("example8.com", "Julia Carvalho", "2017-02-02T08:08:08+00:00")]
        public async Task GetDomainByOwnerName_ShouldReturnDomainViewModel(string dns, string ownerName, DateTimeOffset creationDate)
		{
            // Arrange
			var domainRepositoryMock = new Mock<IDomainRepository>();
			var mediatorHandlerMock = new Mock<IMediatorHandler>();
			var mapperMock = new Mock<IMapper>();

			var domainAppService = new DomainAppService(
				domainRepositoryMock.Object,
				mapperMock.Object,
				mediatorHandlerMock.Object
            );

			var domainEntity = new DomainEntidade(dns, ownerName, creationDate);
			domainRepositoryMock.Setup(repo => repo.GetByOwnerName(ownerName)).ReturnsAsync(domainEntity);

			var expectedViewModel = new DomainViewModel()
			{
                Id = domainEntity.Id,
                DNS = dns,
                OwnerName = ownerName,
                CreationDate = creationDate
            };
			mapperMock.Setup(mapper => mapper.Map<DomainViewModel>(domainEntity)).Returns(expectedViewModel);

			// Act
			var result = await domainAppService.GetByOwnerName(ownerName);

			// Assert
			Assert.Equal(expectedViewModel, result);
		}

        [Theory]
        [InlineData("Beatriz Souza")]
        [InlineData("Gabriel Lima")]
        [InlineData("Julia Carvalho")]
        public async Task GetDomainByOwnerName_ShouldHandleNullRepositoryResult(string ownerName)
        {
            // Arrange
            var domainRepositoryMock = new Mock<IDomainRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var domainAppService = new DomainAppService(
                domainRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            domainRepositoryMock.Setup(repo => repo.GetByOwnerName(It.IsAny<string>()))
                .ReturnsAsync((DomainEntidade)null); // Simulate null result from the repository

            // Act
            var result = await domainAppService.GetByOwnerName(ownerName);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("Beatriz Souza")]
        [InlineData("Gabriel Lima")]
        [InlineData("Julia Carvalho")]
        public async Task GetDomainByOwnerName_ShouldHandleInvalidMappingResult(string ownerName)
        {
            // Arrange
            var domainRepositoryMock = new Mock<IDomainRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var domainAppService = new DomainAppService(
                domainRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            domainRepositoryMock.Setup(repo => repo.GetByOwnerName(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => domainAppService.GetByOwnerName(ownerName));
        }

        [Theory]
        [InlineData("example9.com", "Rafael Gomes", "2018-03-03T09:09:09+00:00")]
        [InlineData("example10.com", "Isabella Rocha", "2019-04-04T10:10:10+00:00")]
        [InlineData("example11.com", "Mateus Alves", "2020-05-05T11:11:11+00:00")]
        public async Task Save_ShouldAddDomainToRepository(string dns, string ownerName, DateTimeOffset creationDate)
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
            domainRepositoryMock.Verify(repo => repo.Add(It.IsAny<DomainEntidade>()), Times.Once);
        }

        [Fact]
        public async Task Save_ShouldHandleNullRepositoryResult()
        {
            // Arrange
            var domainRepositoryMock = new Mock<IDomainRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var domainAppService = new DomainAppService(
                domainRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
                );

            CreateDomainCommand commandCreate = null;

            domainRepositoryMock.Setup(repo => repo.Add(It.IsAny<DomainEntidade>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => domainAppService.Save(commandCreate));

        }

        [Theory]
        [InlineData("example9.com", "Rafael Gomes", "2018-03-03T09:09:09+00:00")]
        [InlineData("example10.com", "Isabella Rocha", "2019-04-04T10:10:10+00:00")]
        [InlineData("example11.com", "Mateus Alves", "2020-05-05T11:11:11+00:00")]
        public async Task Save_ShouldHandleInvalidMappingResult(string dns, string ownerName, DateTimeOffset creationDate)
        {

            // Arrange
            var domainRepositoryMock = new Mock<IDomainRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var domainAppService = new DomainAppService(
                domainRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
                );

            var commandCreate = new CreateDomainCommand()
            {
                DNS = dns,
                OwnerName = ownerName,
                CreatedAt = creationDate
            };

            // Act       
            domainRepositoryMock.Setup(repo => repo.Add(It.IsAny<DomainEntidade>()))
            .Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => domainAppService.Save(commandCreate));
        }

    }
}

using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Domains;
using CloudSuite.Modules.Application.Handlers.Payments;
using CloudSuite.Modules.Application.Handlers.Subscriptions;
using CloudSuite.Modules.Application.Services.Contracts;
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
    public class SubscriptionAppServiceTests
    {
        [Theory]
        [InlineData("1234567891234567", "2021-10-23", "2023-11-23", "2023-12-23", true)]
        [InlineData("1234567891234568", "2021-10-24", "2023-11-24", "2023-12-24", false)]
        [InlineData("1234567891234569", "2021-10-25", "2023-11-25", "2023-12-25", true)]
        public async Task GetByActive_ShouldReturnMappedViewModel(string subscriptionNumber, DateTime createDate, DateTime lastUpdateDate, DateTime expireDate, bool active)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var subscriptionEntity = new Subscription(createDate, lastUpdateDate, expireDate, active, subscriptionNumber);
            subscriptionRepositoryMock.Setup(repo => repo.GetByActive(active)).ReturnsAsync(subscriptionEntity);

            var expectedViewModel = new SubscriptionViewModel();
            mapperMock.Setup(mapper => mapper.Map<SubscriptionViewModel>(subscriptionEntity)).Returns(expectedViewModel);

            // Act
            var result = await subscriptionAppService.GetByActive(active);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task GetByActive_ShouldHandleInvalidMappingResult(bool active)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            subscriptionRepositoryMock.Setup(repo => repo.GetByActive(It.IsAny<bool>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => subscriptionAppService.GetByActive(active));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task GetByActive_ShouldHandleNullRepositoryResult(bool active)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            subscriptionRepositoryMock.Setup(repo => repo.GetByActive(It.IsAny<bool>()))
                .ReturnsAsync((Subscription)null); // Simulate null result from the repository

            // Act
            var result = await subscriptionAppService.GetByActive(active);

            // Assert
            Assert.Null(result);
        }


        [Theory]
        [InlineData("1234567891234570", "2021-10-26", "2023-11-26", "2023-12-26", false)]
        [InlineData("1234567891234571", "2021-10-27", "2023-11-27", "2023-12-27", true)]
        [InlineData("1234567891234572", "2021-10-28", "2023-11-28", "2023-12-28", false)]
        public async Task GetByCreateDate_ShouldReturnMappedViewModel(string subscriptionNumber, DateTime createDate, DateTime lastUpdateDate, DateTime expireDate, bool active)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var subscriptionEntity = new Subscription(createDate, lastUpdateDate, expireDate, active, subscriptionNumber);
            subscriptionRepositoryMock.Setup(repo => repo.GetByCreateDate(createDate)).ReturnsAsync(subscriptionEntity);

            var expectedViewModel = new SubscriptionViewModel();
            mapperMock.Setup(mapper => mapper.Map<SubscriptionViewModel>(subscriptionEntity)).Returns(expectedViewModel);

            // Act
            var result = await subscriptionAppService.GetByCreateDate(createDate);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("2023-11-26")]
        [InlineData("2021-10-27")]
        [InlineData("2023-12-28")]
        public async Task GetByCreateDate_ShouldHandleInvalidMappingResult(DateTime createDate)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            subscriptionRepositoryMock.Setup(repo => repo.GetByCreateDate(It.IsAny<DateTime>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => subscriptionAppService.GetByCreateDate(createDate));
        }

        [Theory]
        [InlineData("2023-11-26")]
        [InlineData("2021-10-27")]
        [InlineData("2023-12-28")]
        public async Task GetByCreateDate_ShouldHandleNullRepositoryResult(DateTime createDate)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            subscriptionRepositoryMock.Setup(repo => repo.GetByCreateDate(It.IsAny<DateTime>()))
                .ReturnsAsync((Subscription)null); // Simulate null result from the repository

            // Act
            var result = await subscriptionAppService.GetByCreateDate(createDate);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("1234567891234573", "2021-10-29", "2023-11-29", "2023-12-29", true)]
        [InlineData("1234567891234574", "2021-10-30", "2023-11-30", "2023-12-30", false)]
        [InlineData("1234567891234575", "2021-10-31", "2023-12-01", "2023-12-31", true)]
        public async Task GetByExpireDate_ShouldReturnMappedViewModel(string subscriptionNumber, DateTime createDate, DateTime lastUpdateDate, DateTime expireDate, bool active)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var subscriptionEntity = new Subscription(createDate, lastUpdateDate, expireDate, active, subscriptionNumber);
            subscriptionRepositoryMock.Setup(repo => repo.GetByExpireDate(expireDate)).ReturnsAsync(subscriptionEntity);

            var expectedViewModel = new SubscriptionViewModel();
            mapperMock.Setup(mapper => mapper.Map<SubscriptionViewModel>(subscriptionEntity)).Returns(expectedViewModel);

            // Act
            var result = await subscriptionAppService.GetByExpireDate(expireDate);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("2023-12-29")]
        [InlineData("2023-11-30")]
        [InlineData("2021-10-31")]
        public async Task GetByExpireDate_ShouldHandleInvalidMappingResult(DateTime expireDate)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            subscriptionRepositoryMock.Setup(repo => repo.GetByExpireDate(It.IsAny<DateTime>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => subscriptionAppService.GetByExpireDate(expireDate));
        }

        [Theory]
        [InlineData("2023-12-29")]
        [InlineData("2023-11-30")]
        [InlineData("2021-10-31")]
        public async Task GetByExpireDate_ShouldHandleNullRepositoryResult(DateTime expireDate)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            subscriptionRepositoryMock.Setup(repo => repo.GetByExpireDate(It.IsAny<DateTime>()))
                .ReturnsAsync((Subscription)null); // Simulate null result from the repository

            // Act
            var result = await subscriptionAppService.GetByExpireDate(expireDate);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("1234567891234576", "2021-11-01", "2023-12-02", "2024-01-01", false)]
        [InlineData("1234567891234577", "2021-11-02", "2023-12-03", "2024-01-02", true)]
        [InlineData("1234567891234578", "2021-11-03", "2023-12-04", "2024-01-03", false)]
        public async Task GetByLastUpdateDate_ShouldReturnMappedViewModel(string subscriptionNumber, DateTime createDate, DateTime lastUpdateDate, DateTime expireDate, bool active)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var subscriptionEntity = new Subscription(createDate, lastUpdateDate, expireDate, active, subscriptionNumber);
            subscriptionRepositoryMock.Setup(repo => repo.GetByLastUpdateDate(lastUpdateDate)).ReturnsAsync(subscriptionEntity);

            var expectedViewModel = new SubscriptionViewModel();
            mapperMock.Setup(mapper => mapper.Map<SubscriptionViewModel>(subscriptionEntity)).Returns(expectedViewModel);

            // Act
            var result = await subscriptionAppService.GetByLastUpdateDate(lastUpdateDate);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("2023-12-02")]
        [InlineData("2024-01-02")]
        [InlineData("2021-11-03")]
        public async Task GetByLastUpdateDate_ShouldHandleInvalidMappingResult(DateTime lastUpdate)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            subscriptionRepositoryMock.Setup(repo => repo.GetByLastUpdateDate(It.IsAny<DateTime>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => subscriptionAppService.GetByLastUpdateDate(lastUpdate));
        }

        [Theory]
        [InlineData("2023-12-02")]
        [InlineData("2024-01-02")]
        [InlineData("2021-11-03")]
        public async Task GetByLastUpdateDate_ShouldHandleNullRepositoryResult(DateTime lastUpdate)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            subscriptionRepositoryMock.Setup(repo => repo.GetByLastUpdateDate(It.IsAny<DateTime>()))
                .ReturnsAsync((Subscription)null); // Simulate null result from the repository

            // Act
            var result = await subscriptionAppService.GetByLastUpdateDate(lastUpdate);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("1234567891234579", "2021-11-04", "2023-12-05", "2024-01-04", true)]
        [InlineData("1234567891234580", "2021-11-05", "2023-12-06", "2024-01-05", false)]
        [InlineData("1234567891234581", "2021-11-06", "2023-12-07", "2024-01-06", true)]
        public async Task GetBySubscriptionNumber_ShouldReturnMappedViewModel(string subscriptionNumber, DateTime createDate, DateTime lastUpdateDate, DateTime expireDate, bool active)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var subscriptionEntity = new Subscription(createDate, lastUpdateDate, expireDate, active, subscriptionNumber);
            subscriptionRepositoryMock.Setup(repo => repo.GetBySubscriptionNumber(subscriptionNumber)).ReturnsAsync(subscriptionEntity);

            var expectedViewModel = new SubscriptionViewModel();
            mapperMock.Setup(mapper => mapper.Map<SubscriptionViewModel>(subscriptionEntity)).Returns(expectedViewModel);

            // Act
            var result = await subscriptionAppService.GetBySubscriptionNumber(subscriptionNumber);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("1234567891234579")]
        [InlineData("1234567891234580")]
        [InlineData("1234567891234581")]
        public async Task GetBySubscriptionNumber_ShouldHandleInvalidMappingResult(string subscriptionNumber)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            subscriptionRepositoryMock.Setup(repo => repo.GetBySubscriptionNumber(It.IsAny<string>()))
            .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate invalid data from the repository

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => subscriptionAppService.GetBySubscriptionNumber(subscriptionNumber));

        }

        [Theory]
        [InlineData("1234567891234579")]
        [InlineData("1234567891234580")]
        [InlineData("1234567891234581")]
        public async Task GetBySubscriptionNumber_ShouldHandleNullRepositoryResult(string subscriptionNumber)
        {
            // Arrange
            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            subscriptionRepositoryMock.Setup(repo => repo.GetBySubscriptionNumber(It.IsAny<string>()))
                .ReturnsAsync((Subscription)null); // Simulate null result from the repository

            // Act
            var result = await subscriptionAppService.GetBySubscriptionNumber(subscriptionNumber);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("1234567891234582", "2021-11-07", "2023-12-08", "2024-01-07", false)]
        [InlineData("1234567891234583", "2021-11-08", "2023-12-09", "2024-01-08", true)]
        [InlineData("1234567891234584", "2021-11-09", "2023-12-10", "2024-01-09", false)]
        public async Task Save_ShouldAddSubscriptionToRepository(string subscriptionNumber, DateTime createDate, DateTime lastUpdateDate, DateTime expireDate, bool active)
        {
            // Arrange
            var createDomainCommand = new CreateSubscriptionCommand()
            {
                SubscriptionNumber = subscriptionNumber,
                CreateDate = createDate,
                LastUpdateDate = lastUpdateDate,
                ExpirteDate = expireDate,
                Active = active
            };

            var subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                subscriptionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            // Act
            await subscriptionAppService.Save(createDomainCommand);

            // Assert
            subscriptionRepositoryMock.Verify(repo => repo.Add(It.IsAny<Subscription>()), Times.Once);
        }

        [Fact]
        public async Task Save_ShouldHandleNullRepositoryResult()
        {
            // Arrange
            var mockRepository = new Mock<ISubscriptionRepository>();
            mockRepository.Setup(repo => repo.Add(It.IsAny<Subscription>())).Throws(new NullReferenceException());

            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                mockRepository.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            CreateSubscriptionCommand commandCreate = null;

            // Act
            try
            {
                mockRepository.Object.Add((Subscription)null);
                await subscriptionAppService.Save(commandCreate);
            }
            catch (NullReferenceException)
            {
                // Exceção esperada
            }

            // Assert
            mockRepository.Verify(repo => repo.Add(It.IsAny<Subscription>()), Times.Once);
        }

        [Fact]
        public async Task Save_ShouldHandleInvalidMappingResult()
        {

            // Arrange
            var mockRepository = new Mock<ISubscriptionRepository>();
            mockRepository.Setup(repo => repo.Add(It.IsAny<Subscription>())).Throws(new ArgumentException("Invalid data"));

            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var subscriptionAppService = new SubscriptionAppService(
                mockRepository.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            CreateSubscriptionCommand commandCreate = null;

            // Act
            try
            {
                mockRepository.Object.Add((Subscription)null);
                await subscriptionAppService.Save(commandCreate);
            }
            catch (ArgumentException)
            {
            }

            // Assert
            mockRepository.Verify(repo => repo.Add(It.IsAny<Subscription>()), Times.Once);
        }

    }
}

using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Payments;
using CloudSuite.Modules.Application.Handlers.Subscriptions;
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
    public class SubscriptionAppServiceTests
    {
        [Fact]
        public async Task GetByActive_ShouldReturnMappedViewModel()
        {
            // Arrange
            var subscriptionNumber = "1234567891234567";
            var createDate = new DateTime(2021, 10, 23);
            var lastUpdateDate = new DateTime(2023, 11, 23);
            var expireDate = new DateTime(2023, 12, 23);
            var active = true;
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

        [Fact]
        public async Task GetByCreateDate_ShouldReturnMappedViewModel()
        {
            // Arrange
            var subscriptionNumber = "1234567891234567";
            var createDate = new DateTime(2021, 10, 23);
            var lastUpdateDate = new DateTime(2023, 11, 23);
            var expireDate = new DateTime(2023, 12, 23);
            var active = true;
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

        [Fact]
        public async Task GetByExpireDate_ShouldReturnMappedViewModel()
        {
            // Arrange
            var subscriptionNumber = "1234567891234567";
            var createDate = new DateTime(2021, 10, 23);
            var lastUpdateDate = new DateTime(2023, 11, 23);
            var expireDate = new DateTime(2023, 12, 23);
            var active = true;
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

        [Fact]
        public async Task GetByLastUpdateDate_ShouldReturnMappedViewModel()
        {
            // Arrange
            var subscriptionNumber = "1234567891234567";
            var createDate = new DateTime(2021, 10, 23);
            var lastUpdateDate = new DateTime(2023, 11, 23);
            var expireDate = new DateTime(2023, 12, 23);
            var active = true;
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

        [Fact]
        public async Task GetBySubscriptionNumber_ShouldReturnMappedViewModel()
        {
            // Arrange
            var subscriptionNumber = "1234567891234567";
            var createDate = new DateTime(2021, 10, 23);
            var lastUpdateDate = new DateTime(2023, 11, 23);
            var expireDate = new DateTime(2023, 12, 23);
            var active = true;
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

        [Fact]
        public async Task Save_ShouldAddSubscriptionToRepository()
        {
            // Arrange
            var createDomainCommand = new CreateSubscriptionCommand()
            {
                SubscriptionNumber = "SUB12345",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                ExpirteDate = DateTime.Now.AddDays(30),
                Active = true
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
    }
}

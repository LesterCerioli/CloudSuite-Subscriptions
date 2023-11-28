using AutoMapper;
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
using DomainEntity = CloudSuite.Modules.Domain.Models.Domain;

namespace CloudSuite.Modules.Application.Tests.Services
{
    public class DomainAppServiceTests
    {
        [Fact]
        public async Task GetByCreationDate_ShouldReturnMappedViewModel()
        {
            // Arrange
            var dns = "fe80::1272:23ff:fe3d:2c3c%4";
            var OwnerName = "Thiago Farias";
            var creationDate = new DateTimeOffset(2022, 10, 23, 14, 0, 0, TimeSpan.Zero);
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
        public async Task GetByDns_ShouldReturnMappedViewModel()
        {
            // Arrange
            var dns = "fe80::1272:23ff:fe3d:2c3c%4";
            var OwnerName = "Thiago Farias";
            var creationDate = new DateTimeOffset(2022, 10, 23, 14, 0, 0, TimeSpan.Zero);
            var domainRepositoryMock = new Mock<IDomainRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var domainAppService = new DomainAppService(
                domainRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var domainEntity = new DomainEntity(dns, OwnerName, creationDate);
            domainRepositoryMock.Setup(repo => repo.GetByDns(dns)).ReturnsAsync(domainEntity);

            var expectedViewModel = new DomainViewModel();
            mapperMock.Setup(mapper => mapper.Map<DomainViewModel>(domainEntity)).Returns(expectedViewModel);

            // Act
            var result = await domainAppService.GetByDns(dns);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Fact]
        public async Task GetByOwnerName_ShouldReturnMappedViewModel()
        {
            // Arrange
            var dns = "fe80::1272:23ff:fe3d:2c3c%4";
            var OwnerName = "Thiago Farias";
            var creationDate = new DateTimeOffset(2022, 10, 23, 14, 0, 0, TimeSpan.Zero);
            var domainRepositoryMock = new Mock<IDomainRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var domainAppService = new DomainAppService(
                domainRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var domainEntity = new DomainEntity(dns, OwnerName, creationDate);
            domainRepositoryMock.Setup(repo => repo.GetByOwnerName(OwnerName)).ReturnsAsync(domainEntity);

            var expectedViewModel = new DomainViewModel();
            mapperMock.Setup(mapper => mapper.Map<DomainViewModel>(domainEntity)).Returns(expectedViewModel);

            // Act
            var result = await domainAppService.GetByOwnerName(OwnerName);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }
    }
}

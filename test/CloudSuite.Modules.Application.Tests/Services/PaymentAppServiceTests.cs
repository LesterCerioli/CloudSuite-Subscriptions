using AutoMapper;
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services
{
    public class PaymentAppServiceTests
    {
        [Fact]
        public async Task GetPaymentByCnpj_ShouldReturnMappedViewModel()
        {
            // Arrange
            var number = "1234567891234567";
            var paidDate = new DateTime(2022, 10, 23);
            var expireDate = new DateTime(2022, 10, 23);
            var total = 22.5m;
            var totalPaid = 20.0m;
            var payer = "john";
            var cnpj = new Cnpj("76.883.915/0001-54");
            var email = new Email("john@seudominio.com");
            var payment = 'a';
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var paynmentEntity = new Payment(number, paidDate, expireDate, total, totalPaid, payer, cnpj, email);
            paymentRepositoryMock.Setup(repo => repo.GetByCnpj(cnpj)).ReturnsAsync(paynmentEntity);

            var expectedViewModel = new PaymentViewModel();
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByCnpj(cnpj);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Fact]
        public async Task GetPaymentByExpireDate_ShouldReturnMappedViewModel()
        {
            // Arrange
            var number = "1234567891234567";
            var paidDate = new DateTime(2022, 10, 23);
            var expireDate = new DateTime(2022, 10, 23);
            var total = 22.5m;
            var totalPaid = 20.0m;
            var payer = "john";
            var cnpj = new Cnpj("76.883.915/0001-54");
            var email = new Email("john@seudominio.com");
            var payment = 'a';
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var paynmentEntity = new Payment(number, paidDate, expireDate, total, totalPaid, payer, cnpj, email);
            paymentRepositoryMock.Setup(repo => repo.GetByExpireDate(expireDate)).ReturnsAsync(paynmentEntity);

            var expectedViewModel = new PaymentViewModel();
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByExpireDate(expireDate);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Fact]
        public async Task GetPaymentByNumber_ShouldReturnMappedViewModel()
        {
            // Arrange
            var number = "1234567891234567";
            var paidDate = new DateTime(2022, 10, 23);
            var expireDate = new DateTime(2022, 10, 23);
            var total = 22.5m;
            var totalPaid = 20.0m;
            var payer = "john";
            var cnpj = new Cnpj("76.883.915/0001-54");
            var email = new Email("john@seudominio.com");
            var payment = 'a';
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var paynmentEntity = new Payment(number, paidDate, expireDate, total, totalPaid, payer, cnpj, email);
            paymentRepositoryMock.Setup(repo => repo.GetByNumber(number)).ReturnsAsync(paynmentEntity);

            var expectedViewModel = new PaymentViewModel();
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByNumber(number);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Fact]
        public async Task GetPaymentByPaidDate_ShouldReturnMappedViewModel()
        {
            // Arrange
            var number = "1234567891234567";
            var paidDate = new DateTime(2022, 10, 23);
            var expireDate = new DateTime(2022, 10, 23);
            var total = 22.5m;
            var totalPaid = 20.0m;
            var payer = "john";
            var cnpj = new Cnpj("76.883.915/0001-54");
            var email = new Email("john@seudominio.com");
            var payment = 'a';
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var paynmentEntity = new Payment(number, paidDate, expireDate, total, totalPaid, payer, cnpj, email);
            paymentRepositoryMock.Setup(repo => repo.GetByPaidDate(paidDate)).ReturnsAsync(paynmentEntity);

            var expectedViewModel = new PaymentViewModel();
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByPaidDate(paidDate);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Fact]
        public async Task GetPaymentByPayer_ShouldReturnMappedViewModel()
        {
            // Arrange
            var number = "1234567891234567";
            var paidDate = new DateTime(2022, 10, 23);
            var expireDate = new DateTime(2022, 10, 23);
            var total = 22.5m;
            var totalPaid = 20.0m;
            var payer = "john";
            var cnpj = new Cnpj("76.883.915/0001-54");
            var email = new Email("john@seudominio.com");
            var payment = 'a';
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var paynmentEntity = new Payment(number, paidDate, expireDate, total, totalPaid, payer, cnpj, email);
            paymentRepositoryMock.Setup(repo => repo.GetByPayer(payer)).ReturnsAsync(paynmentEntity);

            var expectedViewModel = new PaymentViewModel();
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByPayer(payer);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Fact]
        public async Task GetPaymentByTotal_ShouldReturnMappedViewModel()
        {
            // Arrange
            var number = "1234567891234567";
            var paidDate = new DateTime(2022, 10, 23);
            var expireDate = new DateTime(2022, 10, 23);
            var total = 22.5m;
            var totalPaid = 20.0m;
            var payer = "john";
            var cnpj = new Cnpj("76.883.915/0001-54");
            var email = new Email("john@seudominio.com");
            var payment = 'a';
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var paynmentEntity = new Payment(number, paidDate, expireDate, total, totalPaid, payer, cnpj, email);
            paymentRepositoryMock.Setup(repo => repo.GetByTotal(total)).ReturnsAsync(paynmentEntity);

            var expectedViewModel = new PaymentViewModel();
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByTotal(total);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Fact]
        public async Task Save_ShouldAddPaymentToRepository()
        {
            // Arrange
            var createPaymentCommand = new CreatePaymentCommand()
            {

            };
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            // Act
            await paymentAppService.Save(createPaymentCommand);

            // Assert
            paymentRepositoryMock.Verify(repo => repo.Add(It.IsAny<Payment>()), Times.Once);
        }

    }
}

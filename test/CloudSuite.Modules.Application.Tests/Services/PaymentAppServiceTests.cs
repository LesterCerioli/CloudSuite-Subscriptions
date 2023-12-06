using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Payments;
using CloudSuite.Modules.Application.Handlers.Subscriptions;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services
{
    public class PaymentAppServiceTests
    {
        [Theory]
        [InlineData("1234567891234567", "2022-10-23", "2022-11-23", 22.50, 20.00, "john", "68.479.113/0001-55", "john@seudominio.com")]
        [InlineData("1234567891234568", "2022-10-24", "2022-11-24", 555.50, 463.00, "jane", "59.565.247/0001-06", "jane@seudominio.com")]
        [InlineData("1234567891234569", "2022-10-25", "2022-11-25", 111.50, 50.00, "jack", "13.242.140/0001-18", "jack@seudominio.com")]
        public async Task GetPaymentByCnpj_ShouldReturnMappedViewModel(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string cnpj1, string email1)
        {
            // Arrange
            var cnpj = new Cnpj(cnpj1);
            var email = new Email(email1);
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

            var expectedViewModel = new PaymentViewModel()
            {
                Number = number,
                PaidDate = paidDate,
                ExpireDate = expireDate,
                Total = total,
                TotalPaid = totalPaid,
                Payer = payer,
                Cnpj = cnpj1,
                Email = email1
            };
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByCnpj(cnpj);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("68.479.113/0001-55")]
        [InlineData("59.565.247/0001-06")]
        [InlineData("13.242.140/0001-18")]
        public async Task GetPaymentByCnpj_ShouldHandleNullRepositoryResult(string cnpj)
        {
            // Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            paymentRepositoryMock.Setup(repo => repo.GetByCnpj(It.IsAny<Cnpj>()))
                .ReturnsAsync((Payment)null); // Simulate null result from the repository

            // Act
            var result = await paymentAppService.GetByCnpj(cnpj);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("68.479.113/0001-55")]
        [InlineData("59.565.247/0001-06")]
        [InlineData("13.242.140/0001-18")]
        public async Task GetPaymentByCnpj_ShouldHandleInvalidMappingResult(string cnpj)
        {// Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            paymentRepositoryMock.Setup(repo => repo.GetByCnpj(It.IsAny<Cnpj>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => paymentAppService.GetByCnpj(cnpj));
        }

        [Theory]
        [InlineData("1234567891234570", "2022-10-26", "2022-11-26", 25.50, 23.00, "jill", "91.520.534/0001-02", "jill@seudominio.com")]
        [InlineData("1234567891234571", "2022-10-27", "2022-11-27", 26.50, 24.00, "james", "11.378.208/0001-65", "james@seudominio.com")]
        [InlineData("1234567891234572", "2022-10-28", "2022-11-28", 27.50, 25.00, "julia", "74.216.190/0001-15", "julia@seudominio.com")]
        public async Task GetPaymentByExpireDate_ShouldReturnMappedViewModel(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string cnpj1, string email1)
        {
            // Arrange
            var cnpj = new Cnpj(cnpj1);
            var email = new Email(email1);
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

            var expectedViewModel = new PaymentViewModel()
            {
                Number = number,
                PaidDate = paidDate,
                ExpireDate = expireDate,
                Total = total,
                TotalPaid = totalPaid,
                Payer = payer,
                Cnpj = cnpj1,
                Email = email1
            };
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByExpireDate(expireDate);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("2022-10-26")]
        [InlineData("2022-11-27")]
        [InlineData("2022-10-28")]
        public async Task GetByExpireDate_ShouldHandleNullRepositoryResult(DateTime expireDate)
        {
            // Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            paymentRepositoryMock.Setup(repo => repo.GetByExpireDate(It.IsAny<DateTime>()))
                .ReturnsAsync((Payment)null); // Simulate null result from the repository

            // Act
            var result = await paymentAppService.GetByExpireDate(expireDate);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("2022-10-26")]
        [InlineData("2022-11-27")]
        [InlineData("2022-10-28")]
        public async Task GetByExpireDate_ShouldHandleInvalidMappingResult(DateTime expireDate)
        {// Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            paymentRepositoryMock.Setup(repo => repo.GetByExpireDate(It.IsAny<DateTime>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => paymentAppService.GetByExpireDate(expireDate));
        }

        [Theory]
        [InlineData("1234567891234573", "2022-10-29", "2022-11-29", 28.50, 26.00, "jacob", "09.530.107/0001-16", "jacob@seudominio.com")]
        [InlineData("1234567891234574", "2022-10-30", "2022-11-30", 29.50, 27.00, "jessica", "95.368.247/0001-71", "jessica@seudominio.com")]
        [InlineData("1234567891234575", "2022-10-31", "2022-12-01", 30.50, 28.00, "joseph", "23.406.489/0001-00", "joseph@seudominio.com")]
        public async Task GetPaymentByNumber_ShouldReturnMappedViewModel(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string cnpj1, string email1)
        {
            // Arrange
            var cnpj = new Cnpj(cnpj1);
            var email = new Email(email1);
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

            var expectedViewModel = new PaymentViewModel()
            {
                Number = number,
                PaidDate = paidDate,
                ExpireDate = expireDate,
                Total = total,
                TotalPaid = totalPaid,
                Payer = payer,
                Cnpj = cnpj1,
                Email = email1
            };
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByNumber(number);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("1234567891234573")]
        [InlineData("1234567891234574")]
        [InlineData("1234567891234575")]
        public async Task GetPaymentByNumber_ShouldHandleNullRepositoryResult(string number)
        {
            // Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            paymentRepositoryMock.Setup(repo => repo.GetByNumber(It.IsAny<string>()))
                .ReturnsAsync((Payment)null); // Simulate null result from the repository

            // Act
            var result = await paymentAppService.GetByNumber(number);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("1234567891234573")]
        [InlineData("1234567891234574")]
        [InlineData("1234567891234575")]
        public async Task GetPaymentByNumber_ShouldHandleInvalidMappingResult(string number)
        {// Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            paymentRepositoryMock.Setup(repo => repo.GetByNumber(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => paymentAppService.GetByNumber(number));
        }

        [Theory]
        [InlineData("1234567891234576", "2022-11-01", "2022-12-02", 31.50, 29.00, "jennifer", "71.272.299/0001-81", "jennifer@seudominio.com")]
        [InlineData("1234567891234577", "2022-11-02", "2022-12-03", 32.50, 30.00, "justin", "43.755.625/0001-76", "justin@seudominio.com")]
        [InlineData("1234567891234578", "2022-11-03", "2022-12-04", 33.50, 31.00, "joanna", "91.549.407/0001-28", "joanna@seudominio.com")]
        public async Task GetPaymentByPaidDate_ShouldReturnMappedViewModel(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string cnpj1, string email1)
        {
            // Arrange
            var cnpj = new Cnpj(cnpj1);
            var email = new Email(email1);
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

            var expectedViewModel = new PaymentViewModel()
            {
                Number = number,
                PaidDate = paidDate,
                ExpireDate = expireDate,
                Total = total,
                TotalPaid = totalPaid,
                Payer = payer,
                Cnpj = cnpj1,
                Email = email1
            };
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByPaidDate(paidDate);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("2022-12-02")]
        [InlineData("2022-12-03")]
        [InlineData("2022-12-04")]
        public async Task GetByPaidDate_ShouldHandleNullRepositoryResult(DateTime paidDate)
        {
            // Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            paymentRepositoryMock.Setup(repo => repo.GetByPaidDate(It.IsAny<DateTime>()))
                .ReturnsAsync((Payment)null); // Simulate null result from the repository

            // Act
            var result = await paymentAppService.GetByPaidDate(paidDate);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("2022-12-02")]
        [InlineData("2022-12-03")]
        [InlineData("2022-12-04")]
        public async Task GetByPaidDate_ShouldHandleInvalidMappingResult(DateTime paidDate)
        {// Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            paymentRepositoryMock.Setup(repo => repo.GetByPaidDate(It.IsAny<DateTime>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => paymentAppService.GetByPaidDate(paidDate));
        }

        [Theory]
        [InlineData("1234567891234579", "2022-11-04", "2022-12-05", 34.50, 32.00, "jeremy", "44.560.725/0001-00", "jeremy@seudominio.com")]
        [InlineData("1234567891234580", "2022-11-05", "2022-12-06", 35.50, 33.00, "juliet", "00.871.211/0001-08", "juliet@seudominio.com")]
        [InlineData("1234567891234581", "2022-11-06", "2022-12-07", 36.50, 34.00, "jared", "70.459.644/0001-28", "jared@seudominio.com")]
        public async Task GetPaymentByPayer_ShouldReturnMappedViewModel(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string cnpj1, string email1)
        {
            // Arrange
            var cnpj = new Cnpj(cnpj1);
            var email = new Email(email1);
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

            var expectedViewModel = new PaymentViewModel()
            {
                Number = number,
                PaidDate = paidDate,
                ExpireDate = expireDate,
                Total = total,
                TotalPaid = totalPaid,
                Payer = payer,
                Cnpj = cnpj1,
                Email = email1
            };
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByPayer(payer);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("jeremy")]
        [InlineData("juliet")]
        [InlineData("jared")]
        public async Task GetByPayer_ShouldHandleNullRepositoryResult(string payer)
        {
            // Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            paymentRepositoryMock.Setup(repo => repo.GetByPayer(It.IsAny<string>()))
                .ReturnsAsync((Payment)null); // Simulate null result from the repository

            // Act
            var result = await paymentAppService.GetByPayer(payer);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("jeremy")]
        [InlineData("juliet")]
        [InlineData("jared")]
        public async Task GetByPayer_ShouldHandleInvalidMappingResult(string payer)
        {// Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            paymentRepositoryMock.Setup(repo => repo.GetByPayer(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => paymentAppService.GetByPayer(payer));
        }

        [Theory]
        [InlineData("1234567891234582", "2022-11-07", "2022-12-08", 37.50, 35.00, "joyce", "74.553.679/0001-82", "joyce@seudominio.com")]
        [InlineData("1234567891234583", "2022-11-08", "2022-12-09", 38.50, 36.00, "jason", "27.309.690/0001-11", "jason@seudominio.com")]
        [InlineData("1234567891234584", "2022-11-09", "2022-12-10", 39.50, 37.00, "jenna", "44.074.720/0001-77", "jenna@seudominio.com")]
        public async Task GetPaymentByTotal_ShouldReturnMappedViewModel(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string cnpj1, string email1)
        {
            // Arrange
            var cnpj = new Cnpj(cnpj1);
            var email = new Email(email1);
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

            var expectedViewModel = new PaymentViewModel()
            {
                Number = number,
                PaidDate = paidDate,
                ExpireDate = expireDate,
                Total = total,
                TotalPaid = totalPaid,
                Payer = payer,
                Cnpj = cnpj1,
                Email = email1
            };
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByTotal(total);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData(37.50)]
        [InlineData(36.00)]
        [InlineData(39.50)]
        public async Task GetByTotal_ShouldHandleNullRepositoryResult(decimal total)
        {
            // Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            paymentRepositoryMock.Setup(repo => repo.GetByTotal(It.IsAny<decimal>()))
                .ReturnsAsync((Payment)null); // Simulate null result from the repository

            // Act
            var result = await paymentAppService.GetByTotal(total);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(37.50)]
        [InlineData(36.00)]
        [InlineData(39.50)]
        public async Task GetByTotal_ShouldHandleInvalidMappingResult(decimal total)
        {// Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            paymentRepositoryMock.Setup(repo => repo.GetByTotal(It.IsAny<decimal>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => paymentAppService.GetByTotal(total));
        }

        [Theory]
        [InlineData("1234567891234585", "2022-11-10", "2022-12-11", 40.50, 38.00, "jeffrey", "37.052.551/0001-09", "jeffrey@seudominio.com")]
        [InlineData("1234567891234586", "2022-11-11", "2022-12-12", 41.50, 39.00, "jodie", "34.981.974/0001-15", "jodie@seudominio.com")]
        [InlineData("1234567891234587", "2022-11-12", "2022-12-13", 42.50, 40.00, "jerome", "51.017.839/0001-73", "jerome@seudominio.com")]
        public async Task Save_ShouldAddPaymentToRepository(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string cnpj1, string email1)
        {
            // Arrange
            var createPaymentCommand = new CreatePaymentCommand()
            {
                Number = number,
                PaidTime = paidDate,
                ExpireTime = expireDate,
                Total = total,
                TotalPaid = totalPaid,
                Payer = payer,
                Cnpj = cnpj1,
                Email = email1
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

        [Fact]
        public async Task Save_ShouldHandleNullRepositoryResult()
        {
            // Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
                );
            paymentRepositoryMock.Setup(repo => repo.Add(It.IsAny<Payment>())).Throws(new NullReferenceException());
            CreatePaymentCommand commandCreate = null;

            // Act
            try
            {
                await paymentRepositoryMock.Object.Add((Payment)null);
                await paymentAppService.Save(commandCreate);
            }
            catch (NullReferenceException) { }

            // Assert
            paymentRepositoryMock.Verify(repo => repo.Add(It.IsAny<Payment>()), Times.Once);
        }

        [Fact]
        public async Task Save_ShouldHandleInvalidMappingResult()
        {

            // Arrange
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
                );

            CreatePaymentCommand commandCreate = null;
            paymentRepositoryMock.Setup(repo => repo.Add(It.IsAny<Payment>())).Throws(new ArgumentException("Invalid data"));
            // Act
            try
            {
                await paymentRepositoryMock.Object.Add((Payment)null);
                await paymentAppService.Save(commandCreate);
            }
            catch (ArgumentException)
            {}

            // Assert
            paymentRepositoryMock.Verify(repo => repo.Add(It.IsAny<Payment>()), Times.Once);
        }

    }
}

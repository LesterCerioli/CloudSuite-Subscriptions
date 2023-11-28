﻿using AutoMapper;
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
    {/*
        //[Fact]
        public async Task GetByCnpj_ShouldReturnMappedViewModel()
        {
            // Arrange
            var number = "1234567891234567";
            var paidDate = new DateTime(2022, 10, 23);
            var expireDate = new DateTime(2022, 10, 23);
            var total = "22.12";
            var totalPaid = "20.00";
            var payer = "john";
            var cnpj = "76.883.915/0001-54";
            var email = "john@seudominio.com";
            var payment = 'a';
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var paynmentEntity = new Payment(payment, number, paidDate, expireDate, total, totalPaid, payer, cnpj, email);
            paymentRepositoryMock.Setup(repo => repo.GetByCnpj(cnpj)).ReturnsAsync(paynmentEntity);

            var expectedViewModel = new PaymentViewModel();
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByCnpj(cnpj);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        //[Fact]
        public async Task GetByExpireDate_ShouldReturnMappedViewModel()
        {
            // Arrange
            var number = "1234567891234567";
            var paidDate = new DateTime(2022, 10, 23);
            var expireDate = new DateTime(2022, 10, 23);
            var total = "22.12";
            var totalPaid = "20.00";
            var payer = "john";
            var cnpj = "76.883.915/0001-54";
            var email = "john@seudominio.com";
            var payment = 'a';
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var paynmentEntity = new Payment(payment, number, paidDate, expireDate, total, totalPaid, payer, cnpj, email);
            paymentRepositoryMock.Setup(repo => repo.GetByExpireDate(expireDate)).ReturnsAsync(paynmentEntity);

            var expectedViewModel = new PaymentViewModel();
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByExpireDate(expireDate);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        //[Fact]
        public async Task GetByNumber_ShouldReturnMappedViewModel()
        {
            // Arrange
            var number = "1234567891234567";
            var paidDate = new DateTime(2022, 10, 23);
            var expireDate = new DateTime(2022, 10, 23);
            var total = "22.12";
            var totalPaid = "20.00";
            var payer = "john";
            var cnpj = "76.883.915/0001-54";
            var email = "john@seudominio.com";
            var payment = 'a';
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var paynmentEntity = new Payment(payment, number, paidDate, expireDate, total, totalPaid, payer, cnpj, email);
            paymentRepositoryMock.Setup(repo => repo.GetByNumber(number)).ReturnsAsync(paynmentEntity);

            var expectedViewModel = new PaymentViewModel();
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByNumber(number);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        //[Fact]
        public async Task GetByPaidDate_ShouldReturnMappedViewModel()
        {
            // Arrange
            var number = "1234567891234567";
            var paidDate = new DateTime(2022, 10, 23);
            var expireDate = new DateTime(2022, 10, 23);
            var total = "22.12";
            var totalPaid = "20.00";
            var payer = "john";
            var cnpj = "76.883.915/0001-54";
            var email = "john@seudominio.com";
            var payment = 'a';
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var paynmentEntity = new Payment(payment, number, paidDate, expireDate, total, totalPaid, payer, cnpj, email);
            paymentRepositoryMock.Setup(repo => repo.GetByPaidDate(paidDate)).ReturnsAsync(paynmentEntity);

            var expectedViewModel = new PaymentViewModel();
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByPaidDate(paidDate);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        //[Fact]
        public async Task GetByPayer_ShouldReturnMappedViewModel()
        {
            // Arrange
            var number = "1234567891234567";
            var paidDate = new DateTime(2022, 10, 23);
            var expireDate = new DateTime(2022, 10, 23);
            var total = "22.12";
            var totalPaid = "20.00";
            var payer = "john";
            var cnpj = "76.883.915/0001-54";
            var email = "john@seudominio.com";
            var payment = 'a';
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var paynmentEntity = new Payment(payment, number, paidDate, expireDate, total, totalPaid, payer, cnpj, email);
            paymentRepositoryMock.Setup(repo => repo.GetByPayer(payer)).ReturnsAsync(paynmentEntity);

            var expectedViewModel = new PaymentViewModel();
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByPayer(payer);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        //[Fact]
        public async Task GetByTotal_ShouldReturnMappedViewModel()
        {
            // Arrange
            var number = "1234567891234567";
            var paidDate = new DateTime(2022, 10, 23);
            var expireDate = new DateTime(2022, 10, 23);
            var total = 22.12;
            var totalPaid = 20.0;
            var payer = "john";
            var cnpj = "76.883.915/0001-54";
            var email = "john@seudominio.com";
            var payment = 'a';
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var paymentAppService = new PaymentAppService(
                paymentRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var paynmentEntity = new Payment(payment, number, paidDate, expireDate, total, totalPaid, payer, cnpj, email);
            paymentRepositoryMock.Setup(repo => repo.GetByTotal(total)).ReturnsAsync(paynmentEntity);

            var expectedViewModel = new PaymentViewModel();
            mapperMock.Setup(mapper => mapper.Map<PaymentViewModel>(paynmentEntity)).Returns(expectedViewModel);

            // Act
            var result = await paymentAppService.GetByTotal(total);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        */

    }
}
using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Contacts;
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
    public class ContactAppServiceTests
    {
        [Theory]
        [InlineData("igor moreira", "igorsantos@gmail.com", "77988890987", " Difficulty finding reliable information on a given topic online.")]
        [InlineData("gabriela correa", "gabrielacorrea@icloud.com", "71998876745", "Hello, I would like to hire the services of a software house to develop a customized software for my business.")]
        [InlineData("cristiano ronaldo", "ronaldocristiano@outlook.com", "21973648765", " ")]
        public async Task GetContactByEmail_ShouldReturnsCompanyViewModel(string name, string email, string telephone, string bodyMessage)
        {
            var contactRepositoryMock = new Mock<IContactRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var contactAppService = new ContactAppService(
                contactRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object);

            var contactEntity = new Contact(new Name(name), new Email(email), bodyMessage, new Telephone(telephone));
            contactRepositoryMock.Setup(repo => repo.GetByEmail(new Email(email))).ReturnsAsync(contactEntity);

            var expectedViewModel = new ContactViewModel()
            {
                Id = contactEntity.Id,
                Name = name,
                Email = email,
                Telephone = telephone,
                BodyMessage = bodyMessage
            };

            mapperMock.Setup(mapper => mapper.Map<ContactViewModel>(contactEntity)).Returns(expectedViewModel);

            // Act
            var result = await contactAppService.GetByEmail(new Email(email));

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("carlos@gmail.com")]
        [InlineData("ana@icloud.com")]
        [InlineData("pedro@outlook.com")]
        public async Task GetContactByEmail_ShouldHandleNullRepositoryResult(string email)
        {
            // Arrange

            var contactRepositoryMock = new Mock<IContactRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var contactAppService = new ContactAppService(
                contactRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object);

            contactRepositoryMock.Setup(repo => repo.GetByEmail(It.IsAny<Email>()))
                .ReturnsAsync((Contact)null); // Simulate null result from the repository

            // Act
            var result = await contactAppService.GetByEmail(new Email(email));

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("lucia@yahoo.com")]
        [InlineData("joao@bol.com.br")]
        [InlineData("marcos@uol.com.br")]
        public async Task GetContactByEmail_ShouldHandleInvalidMappingResult(string email)
        {
            // Arrange
            var contactRepositoryMock = new Mock<IContactRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var contactAppService = new ContactAppService(
                contactRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object);

            contactRepositoryMock.Setup(repo => repo.GetByEmail(It.IsAny<Email>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => contactAppService.GetByEmail(new Email(email)));
        }

        [Theory]
        [InlineData("maria silva", "mariasilva@yahoo.com", "11987654321", "I need help with my math homework.Can you explain how to solve this equation ? 2x + 3 = 7")]
        [InlineData("rodrigo lima", "rodrigolima@bol.com.br", "85999988776", "I am interested in learning more about artificial intelligence.Can you recommend me some online courses or books ?")]
        [InlineData("julia santos", "juliasantos@gmail.com", "31988887777", "I want to buy a new laptop.What are the best brands and models in the market ?")]
        public async Task GetContactByName_ShouldReturnsCompanyViewModel(string name, string email, string telephone, string bodyMessage)
        {
            var contactRepositoryMock = new Mock<IContactRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var contactAppService = new ContactAppService(
                contactRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object);

            var contactEntity = new Contact(new Name(name), new Email(email), bodyMessage, new Telephone(telephone));
            contactRepositoryMock.Setup(repo => repo.GetByName(new Name(name))).ReturnsAsync(contactEntity);

            var expectedViewModel = new ContactViewModel()
            {
                Id = contactEntity.Id,
                Name = name,
                Email = email,
                Telephone = telephone,
                BodyMessage = bodyMessage
            };

            mapperMock.Setup(mapper => mapper.Map<ContactViewModel>(contactEntity)).Returns(expectedViewModel);

            // Act
            var result = await contactAppService.GetByName(new Name(name));

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("51973645298")]
        [InlineData("77988374932")]
        [InlineData("71933647382")]
        public async Task GetContactByName_ShouldHandleNullRepositoryResult(string name)
        {
            // Arrange

            var contactRepositoryMock = new Mock<IContactRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var contactAppService = new ContactAppService(
                contactRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object);

            contactRepositoryMock.Setup(repo => repo.GetByName(It.IsAny<Name>()))
                .ReturnsAsync((Contact)null); // Simulate null result from the repository

            // Act
            var result = await contactAppService.GetByName(new Name(name));

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("21999887766")]
        [InlineData("85987654321")]
        [InlineData("11988776655")]
        public async Task GetContactByName_ShouldHandleInvalidMappingResult(string name)
        {
            // Arrange
            var contactRepositoryMock = new Mock<IContactRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var contactAppService = new ContactAppService(
                contactRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object);

            contactRepositoryMock.Setup(repo => repo.GetByName(It.IsAny<Name>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => contactAppService.GetByName(new Name(name)));
        }

        [Theory]
        [InlineData("maria silva", "mariasilva@yahoo.com", "1198765432123", "I need help with my math homework.Can you explain how to solve this equation ? 2x + 3 = 7")]
        [InlineData("rodrigo lima", "rodrigolima@bol.com.br", "8599998877612", "I am interested in learning more about artificial intelligence.Can you recommend me some online courses or books ?")]
        [InlineData("julia santos", "juliasantos@gmail.com", "3198888777712", "I want to buy a new laptop.What are the best brands and models in the market ?")]
        public async Task GetContactByTelephone_ShouldReturnsCompanyViewModel(string name, string email, string telephone, string bodyMessage)
        {
            var contactRepositoryMock = new Mock<IContactRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var contactAppService = new ContactAppService(
                contactRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object);

            var contactEntity = new Contact(new Name(name), new Email(email), bodyMessage, new Telephone(telephone));
            contactRepositoryMock.Setup(repo => repo.GetByTelephone(new Telephone(telephone))).ReturnsAsync(contactEntity);

            var expectedViewModel = new ContactViewModel()
            {
                Id = contactEntity.Id,
                Name = name,
                Email = email,
                Telephone = telephone,
                BodyMessage = bodyMessage
            };

            mapperMock.Setup(mapper => mapper.Map<ContactViewModel>(contactEntity)).Returns(expectedViewModel);

            // Act
            var result = await contactAppService.GetByTelephone(new Telephone(telephone));

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("51973645298")]
        [InlineData("77988374932")]
        [InlineData("71933647382")]
        public async Task GetContactByTelephone_ShouldHandleNullRepositoryResult(string name)
        {
            // Arrange

            var contactRepositoryMock = new Mock<IContactRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var contactAppService = new ContactAppService(
                contactRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object);

            contactRepositoryMock.Setup(repo => repo.GetByTelephone(It.IsAny<Telephone>()))
                .ReturnsAsync((Contact)null); // Simulate null result from the repository

            // Act
            var result = await contactAppService.GetByTelephone(new Telephone(name));

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("21999887766")]
        [InlineData("85987654321")]
        [InlineData("11988776655")]
        public async Task GetContactByTelephone_ShouldHandleInvalidMappingResult(string telephone)
        {
            // Arrange
            var contactRepositoryMock = new Mock<IContactRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var contactAppService = new ContactAppService(
                contactRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object);

            contactRepositoryMock.Setup(repo => repo.GetByTelephone(It.IsAny<Telephone>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => contactAppService.GetByTelephone(new Telephone(telephone)));
        }

        [Theory]
        [InlineData("carlos pereira", "carlospereira@hotmail.com", "21987651234", "I want to travel to Europe next year.What are the best destinations and tips ?")]
        [InlineData("ana clara", "anaclara@outlook.com", "71988896655", "I love reading books.Can you suggest me some good novels or authors ?")]
        [InlineData("pedro henrique", "pedrohenrique@gmail.com", "41999994444", "I need to improve my English skills.Can you help me with some exercises or resources ?")]
        public async Task Save_ShouldAddCompanyToRepository(string name, string email, string telephone, string bodyMessage)
        {
            // Arrange
            var createContactCommand = new CreateContactCommand()
            {
                Name = name,
                Email = email,
                Telephone = telephone,
                BodyMessage = bodyMessage
            };

            var contactRepositoryMock = new Mock<IContactRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var contactAppService = new ContactAppService(
                contactRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object);

            // Act
            await contactAppService.Save(createContactCommand);

            // Assert
            contactRepositoryMock.Verify(repo => repo.Add(It.IsAny<Contact>()), Times.Once);
        }

        [Fact]
        public async Task Save_ShouldHandleNullRepositoryResult()
        {
            // Arrange
            var contactRepositoryMock = new Mock<IContactRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var contactAppService = new ContactAppService(
                contactRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object);

            CreateContactCommand commandCreate = null;

            contactRepositoryMock.Setup(repo => repo.Add(It.IsAny<Contact>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => contactAppService.Save(commandCreate));
        }

        [Theory]
        [InlineData("lucas silveira", "lucassilveira@uol.com.br", "51988895555", "I like to play online games.Can you tell me some fun and free options ?")]
        [InlineData("marina costa", "marinacosta@terra.com.br", "81999992222", "I want to learn how to play guitar.Can you give me some tips or tutorials ?")]
        [InlineData("felipe rocha", "feliperocha@icloud.com", "61987653333", "I need to write an essay about climate change.Can you help me with some sources or arguments ?")]
        public async Task Save_ShouldHandleInvalidMappingResult(string name, string email, string telephone, string bodyMessage)
        {

            // Arrange
            var contactRepositoryMock = new Mock<IContactRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var contactAppService = new ContactAppService(
                contactRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object);

            var commandCreate = new CreateContactCommand()
            {
                Name = name,
                Email = email,
                Telephone = telephone,
                BodyMessage = bodyMessage
            };

            // Act       
            contactRepositoryMock.Setup(repo => repo.Add(It.IsAny<Contact>()))
            .Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => contactAppService.Save(commandCreate));
        }

    }
}

using CyberPet.Api.Models;
using CyberPet.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CyberPet.Api.Controllers
{
    public class UsersControllerTest
    {
        protected UsersController ControllerUnderTest { get; }
        protected Mock<IUserService> UserServiceMock { get;  }

        public UsersControllerTest()
        {
            UserServiceMock = new Mock<IUserService>();
            ControllerUnderTest = new UsersController(UserServiceMock.Object);
        }


        public class ReadAllAsync : UsersControllerTest
        {
            [Fact]
            public async Task Should_return_OkObjectResult_with_users()
            {
                //Arrange
                var expectedUsers = new User[]
                {
                    new User { Name = "Gabriel Meyer", Email = "ghmeyer0@gmail.com"},
                    new User { Name = "Renato Rezende", Email = "rrschiavo@gmail.com"}
                };
                UserServiceMock
                    .Setup(x => x.ReadAllAsync())
                    .ReturnsAsync(expectedUsers);

                //Act
                var result = await ControllerUnderTest.ReadAllAsync();

                //Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(expectedUsers, okResult.Value);
            }
        }

        public class ReadOneAsync : UsersControllerTest
        {
            [Fact]
            public async Task Deve_retornar_OkObjectResult_com_o_usuario_esperado()
            {
                // Arrange 
                Guid id = Guid.NewGuid();
                var expectedUser = new User
                {
                    Id = id,
                    Email = "ghmeyer0@gmail.com",
                    Name = "Gabriel Helko Meyer",
                    Password = "aaaaa"
                };
                UserServiceMock
                    .Setup(x => x.ReadOneAsync(id))
                    .ReturnsAsync(expectedUser);

                // Act
                var result = await ControllerUnderTest.ReadOneAsync(id);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(expectedUser, okResult.Value);

            }

            [Fact]
            public async Task Deve_retornar_OkObjectResult_vazio()
            {
                // Arrange
                Guid id = Guid.NewGuid();
                User expectedValue = null;
                UserServiceMock
                    .Setup(x => x.ReadOneAsync(id))
                    .ReturnsAsync(expectedValue);

                // Act
                var result = await ControllerUnderTest.ReadOneAsync(id);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Null(okResult.Value);
            }
        }

        public class UpdateAsync : UsersControllerTest
        {
            [Fact]
        }
    }
}

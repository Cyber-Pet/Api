using CyberPet.Api.Models;
using CyberPet.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
            public async void Should_return_OkObjectResult_with_users()
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
    }
}

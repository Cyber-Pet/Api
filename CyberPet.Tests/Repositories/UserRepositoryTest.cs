using CyberPet.Api.Models;
using MongoDB.Driver;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xunit;

namespace CyberPet.Api.Repositories
{
    class UserRepositoryTest
    {
        protected UserRepository RepositoryUnderTest { get; }
        protected Mock<IMongoCollection<User>> CyberPetDatabaseMock { get; }
        public UserRepositoryTest()
        {
            RepositoryUnderTest = new UserRepository(CyberPetDatabaseMock.Object);
        }
        public class ReadAllAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_retornar_todos_os_usuario()
            {
                // Arrange
                var expectedUsers = new Collection<User>(new List<User>
                {
                    new User { Email = "ghmeyer0@gmail.com",   Name = "Gabriel Helko Meyer", Password = "ababa" },
                    new User { Email = "ghmeyer0@hotmail.com",   Name = "Gabriel Helko Meyer", Password = "ababa" }
                });

                CyberPetDatabaseMock.Setup(x => x.Find(Builders<User>.Filter.Empty, null).ToList()).Returns(expectedUsers);

                // Act
                var result = await RepositoryUnderTest.ReadAllAsync();

                // Assert

                Assert.Collection(result,
                    user => Assert.Same(Users[0], user),
                    user => Assert.Same(Users[1], user)
                    );
            }
        }

        public class ReadOneAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_retornar_o_usuario_esperado()
            {
                // Arrange
            }
        }
    }
}

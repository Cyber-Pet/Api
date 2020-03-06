using CyberPet.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace CyberPet.Api.Repositories
{
    class UserRepositoryTest
    {
        protected UserRepository RepositoryUnderTest { get; }
        protected CyberPetContext CyberPetDatabaseMock { get; }
        public UserRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<CyberPetContext>()
                         .UseInMemoryDatabase(databaseName: "InMemoryCyberPetDb")
                         .Options;
            CyberPetDatabaseMock = new CyberPetContext(options);
            RepositoryUnderTest = new UserRepository(CyberPetDatabaseMock);
        }
        public class ReadAllAsync : UserRepositoryTest
        {
            [Fact]
            public async void Deve_retornar_todos_os_usuario()
            {
                // Arrange
                var expectedUsers = new Collection<User>(new List<User>
                {
                    new User { Email = "ghmeyer0@gmail.com",   Name = "Gabriel Helko Meyer", Password = "ababa" },
                    new User { Email = "ghmeyer0@hotmail.com",   Name = "Gabriel Helko Meyer", Password = "ababa" }
                });
                CyberPetDatabaseMock.AddRange(expectedUsers);

                // Act
                var result = await RepositoryUnderTest.ReadAllAsync();

                // Assert

                Assert.Equal(2, result.Count());
            }
        }

        public class ReadOneAsync : UserRepositoryTest
        {
            [Fact]
            public async void Deve_retornar_o_usuario_esperado()
            {
                // Arrange

                Guid id = Guid.NewGuid();
                 
                var expectedUsers = new Collection<User>(new List<User>
                {
                    new User { Id = id, Email = "ghmeyer0@gmail.com",   Name = "Gabriel Helko Meyer", Password = "ababa"},
                    new User { Email = "ghmeyer0@gmail.com",   Name = "Gabriel Helko Meyer", Password = "ababa" },
                    new User { Email = "ghmeyer0@hotmail.com",   Name = "Gabriel Helko Meyer", Password = "ababa" }
                });
                CyberPetDatabaseMock.AddRange(expectedUsers);

                // Act

                var result = await RepositoryUnderTest.ReadOneAsync(id);

                //  Assert

                Assert.Equal(result.Email, "ghmeyer0@gmail.com");
            }
        }
    }
}

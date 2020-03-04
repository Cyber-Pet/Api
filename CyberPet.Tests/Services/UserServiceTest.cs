using CyberPet.Api.Models;
using CyberPet.Api.Repositories;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xunit;

namespace CyberPet.Api.Services
{
    public class UserServiceTest
    {
        protected UserService ServiceUnderTest { get; }
        protected Mock<IUserRepository> UserRepositoryMock { get; }
        public UserServiceTest()
        {
            UserRepositoryMock = new Mock<IUserRepository>();
            ServiceUnderTest = new UserService(UserRepositoryMock.Object);
        }

        public class ReadAllAsync : UserServiceTest
        {
            [Fact]
            public async Task Deve_retornar_todos_os_usuario()
            {
                // Arrange
                var expectedUsers = new ReadOnlyCollection<User>(new List<User>
                {
                    new User { Name = "Gabriel Meyer", Email = "ghmeyer0@gmail.com"},
                    new User { Name = "Renato Rezende", Email = "rrschiavo@gmail.com"}
                });
                UserRepositoryMock
                    .Setup(x => x.ReadAllAsync())
                    .ReturnsAsync(expectedUsers);

                // Act
                var result = await ServiceUnderTest.ReadAllAsync();

                // Assert
                Assert.Same(expectedUsers, result);
            }
        }
        public class ReadOneAsync : UserServiceTest
        {
            [Fact]
            public async Task Deve_retornar_o_usuario_esperado()
            {
                // Arrange
                var userId = ObjectId.GenerateNewId();
                var expectedUser = new User { Id = userId, Name = "Gabriel Meyer", Email = "ghmeyer0@gmail.com" };
                UserRepositoryMock
                    .Setup(x => x.ReadOneAsync(userId))
                    .ReturnsAsync(expectedUser);

                // Act
                var result = await ServiceUnderTest.ReadOneAsync(userId);

                // Assert
                Assert.Same(expectedUser, result);

            }
            [Fact]
            public async Task Deve_retornar_null_se_o_usuario_nao_existir()
            {
                // Arrange
                var userId = ObjectId.GenerateNewId();
                UserRepositoryMock
                    .Setup(x => x.ReadOneAsync(userId))
                    .ReturnsAsync(default(User));

                // Act
                var result = await ServiceUnderTest.ReadOneAsync(userId);

                // Assert
                Assert.Null(result);
            }
        }
        
        public class CreateAsync : UserServiceTest
        {
            [Fact]
            public async Task Deve_criar_e_retornar_o_usuario_especificado()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => ServiceUnderTest.CreateAsync(null));
            }
        }

        public class UpdateAsync : UserServiceTest
        {
            [Fact]
            public async Task Deve_atualizar_e_retornar_o_usuario_especificado()
            {
                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => ServiceUnderTest.UpdateAsync(null));
            }
        }
        public class DeleteAsync : UserServiceTest
        {
            [Fact]
            public async Task Deve_deletar_e_retornar_o_usuario_especificado()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => ServiceUnderTest.DeleteAsync(ObjectId.Empty));
            }
        }
    }
    
}

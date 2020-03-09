using CyberPet.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CyberPet.Api.Repositories
{
    public class UserRepositoryTest
    {
        protected UserRepository RepositoryUnderTest { get; }
        protected CyberPetContext CyberPetDatabaseMock { get; }
        private static Guid testId = Guid.NewGuid();
        public UserRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<CyberPetContext>()
                         .UseInMemoryDatabase(databaseName: "InMemoryCyberPetDb")
                         .Options;
            CyberPetDatabaseMock = new CyberPetContext(options);
            CyberPetDatabaseMock.Users.AddRangeAsync(new Collection<User>(new List<User>
                {
                    new User { Id = testId, Email = "ghmeyer0@gmail.com",   Name = "Gabriel Helko Meyer", Password = "ababa" },
                    new User { Id = Guid.NewGuid(), Email = "gustavoreinertbsi@gmail.com",   Name = "Gustavo Reinert", Password = "ababa" },
                    new User { Id = Guid.NewGuid(), Email = "rrschiavo@gmail.com",   Name = "Renato", Password = "ababa" }
                }));
            CyberPetDatabaseMock.SaveChangesAsync();

            RepositoryUnderTest = new UserRepository(CyberPetDatabaseMock);
        }
        public class ReadAllAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_retornar_todos_os_usuario()
            {
                // Arrange

                // Act
                var result = await RepositoryUnderTest.ReadAll();

                // Assert
                Assert.Equal(3, result.Count());
            }
        }

        public class ReadOneAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_retornar_o_usuario_esperado()
            {
                // Arrange

                // Act
                var result = await RepositoryUnderTest.ReadOneAsync(testId);

                // Assert
                Assert.Equal("ghmeyer0@gmail.com", result.Email);
            }

            [Fact]
            public async Task Deve_retornar_vazio()
            {
                // Arrange
                var id = Guid.NewGuid();

                // Act 
                var result = await RepositoryUnderTest.ReadOneAsync(id);

                // Assert
                Assert.Null(result);
            }
        }

        public class CreateAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_criar_um_usuario()
            {
                // Arrange
                var newUser = new User
                {
                    Email = "exemplo@exemplo.com",
                    Name = "Exemplo",
                    Password = "aaaaa"
                };
                // Act
                var result = await RepositoryUnderTest.CreateAsync(newUser);

                // Assert
                Assert.NotNull(result);
                Assert.True(Utils.IsGuid(result.Id));
            }
        }

        public class UpdateAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_atualizar_o_usuario()
            {
                // Arrange
                var id = Guid.NewGuid();
                var updatedUser = new User
                {
                    Id = id,
                    Email = "email@exemplo.com.br",
                    Name = "Exemplo Teste",
                    Password = "senha_segura"
                };
                await CyberPetDatabaseMock.Users.AddAsync(updatedUser);
                await CyberPetDatabaseMock.SaveChangesAsync();

                updatedUser.Name = "Nome Alternativo";

                // Act
                var result = await RepositoryUnderTest.UpdateAsync(updatedUser);

                // Assert
                Assert.Equal("Nome Alternativo", result.Name);
            }
        }

        public class DeleteAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_remover_o_usuario()
            {
                // Arrange
                var id = Guid.NewGuid();
                var deletedUser = new User
                {
                    Id = id,
                    Email = "email@exemplo.com.br",
                    Name = "Exemplo Teste",
                    Password = "senha_segura"
                };
                await CyberPetDatabaseMock.AddAsync(deletedUser);

                // Act
                var result = await RepositoryUnderTest.DeleteAsync(id);

                // Assert
                Assert.Equal(deletedUser, result);
            }

        }

    }
}

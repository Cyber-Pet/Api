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
        public UserRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<CyberPetContext>()
                         .UseInMemoryDatabase(databaseName: "InMemoryCyberPetDb")
                         .Options;
            CyberPetDatabaseMock = new CyberPetContext(options);

            var users = new Collection<User>(new List<User>
                {
                    new User { Id = Guid.NewGuid(), Email = "ghmeyer0@gmail.com",   Name = "Gabriel Helko Meyer", Password = "ababa" },
                    new User { Id = Guid.NewGuid(), Email = "gustavoreinertbsi@gmail.com",   Name = "Gustavo Reinert", Password = "ababa" },
                    new User { Id = Guid.NewGuid(), Email = "rrschiavo@gmail.com",   Name = "Renato", Password = "ababa" }
                });

            RepositoryUnderTest = new UserRepository(CyberPetDatabaseMock);
        }
        public class ReadAllAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_retornar_todos_os_usuario()
            {
                // Arrange
                var id = Guid.NewGuid();
                await CyberPetDatabaseMock.AddAsync(new User
                {
                    Id = id,
                    Email = "email@exemplo.com.br",
                    Name = "Exemplo Teste",
                    Password = "senha_segura"
                });

                // Act
                var result = await RepositoryUnderTest.ReadAllAsync();

                // Assert
                Assert.Equal(4, result.Count());
            }
        }

        public class ReadOneAsync : UserRepositoryTest
        {
            [Fact]
            public async Task Deve_retornar_o_usuario_esperado()
            {
                // Arrange
                var id = Guid.NewGuid();
                await CyberPetDatabaseMock.AddAsync(new User
                {
                    Id = id,
                    Email = "email@exemplo.com.br",
                    Name = "Exemplo Teste",
                    Password = "senha_segura"
                });

                // Act
                var result = await RepositoryUnderTest.ReadOneAsync(id);

                // Assert
                Assert.Equal("email@exemplo.com.br", result.Email);
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
                Guid guidResult;

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
                await CyberPetDatabaseMock.AddAsync(updatedUser);

                updatedUser.Name = "Nome Alternativo";

                // Act
                var result = await RepositoryUnderTest.UpdateAsync(id, updatedUser);

                // Assert
                Assert.Equal("Nome Alternativo", result.Name);
            }
        }

    }
}

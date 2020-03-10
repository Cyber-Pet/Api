using CyberPet.Api.Models;
using CyberPet.Api.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CyberPet.Api.Repositories
{
    public class UserRepositoryTest
    {
        protected UserRepository RepositoryUnderTest { get; }
        protected CyberPetContext CyberPetDatabaseMock { get; }
        private static Guid testId = new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c");
        public UserRepositoryTest()
        {
            CyberPetDatabaseMock = SqliteCyberPetContextFactory.GetCyberPetContext();
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
                Assert.True(StringUtils.IsGuid(result.Id));
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

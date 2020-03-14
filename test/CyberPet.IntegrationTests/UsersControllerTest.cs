using CyberPet.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace CyberPet.IntegrationTests
{
    public class UsersControllerTest : BaseHttpTest
    {
       
        public class GetAllAsync : UsersControllerTest
        {
            [Fact]

            public async Task Deve_retornar_os_usuarios()
            {
                var result = await Client.GetAsync("api/Users");
                result.EnsureSuccessStatusCode();
                Assert.NotNull(result);
                
                var users = JsonConvert.DeserializeObject<User[]>(await result.Content.ReadAsStringAsync());
                Assert.NotEmpty(users);
                Assert.Equal(3, users.Length);
            }
        }
    }
}

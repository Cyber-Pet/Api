using CyberPet.Api.Models;

namespace CyberPet.Api.Repositories
{
    class UserRepositoryTest
    {
        protected UserRepository RepositoryUnderTest { get; }
        protected User[] Users { get; }
        public UserRepositoryTest()
        {
            Users = new User[]
            {
                new User { Email = "ghmeyer0@gmail.com",    }
            }
        }
    }
}

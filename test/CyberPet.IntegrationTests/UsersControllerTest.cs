using CyberPet.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberPet.IntegrationTests
{
    public class UsersControllerTest : BaseHttpTest
    {
        public class ReadAllAsync : UsersControllerTest
        {
            private IEnumerable<User> Users => new User[]
            {
                new User { Email = "ghmeyer0@gmail.com", Name = "Gabriel Helko Meyer", Password = "aaa"}
            };

        }
    }
}

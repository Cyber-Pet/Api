﻿using CyberPet.Api.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberPet.Api.Services
{
    public class UserService : IUserService
    {
        public Task<User> CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteAsync(ObjectId Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> ReadOneAsync(ObjectId Id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
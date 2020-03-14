﻿using CyberPet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<User> ReadOneBy(Expression<Func<User, bool>> expression);
        Task<int> CreateAsync(User user);
        Task<int> UpdateAsync(User user);
        Task<int> DeleteAsync(Guid id);
    }
}

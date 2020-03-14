﻿using CyberPet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CyberPet.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid Id);
        Task<User> ReadOneBy(Expression<Func<User, bool>> expression);
        Task<User> CreateAsync(User user);
        Task<int> UpdateAsync(User user);
        Task<int> DeleteAsync(Guid Id);
    }
}

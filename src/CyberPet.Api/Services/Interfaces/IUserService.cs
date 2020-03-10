using CyberPet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CyberPet.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ReadAllAsync();
        Task<User> ReadOneAsync(Guid Id);
        Task<User> ReadOneBy(Expression<Func<User, bool>> expression);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(Guid Id);

    }
}

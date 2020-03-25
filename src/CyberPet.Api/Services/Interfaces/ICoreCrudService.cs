using CyberPet.Api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Services.Interfaces
{
    public interface ICoreCrudService<TEntity>
        where TEntity : ICoreModel
    {
        Task<int> CreateAsync(TEntity entity);

        Task<int> DeleteAsync(Guid id);

        Task<TEntity> GetByIdAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<int> UpdateAsync(TEntity entity);

    }
}

using CyberPet.Api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositories.Interfaces
{
    public interface ICoreRepository<TEntity>
        where TEntity : ICoreModel
    { 
        Task<int> CreateAsync(TEntity entity);
        
        Task<int> DeleteAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> GetByIdAsync(Guid id);


        Task<int> UpdateAsync(TEntity entity);
    }
}

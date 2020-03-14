using CyberPet.Api.Models.Interfaces;
using LinqKit;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositories.Interfaces
{
    public interface ICoreRepository<TEntity> where TEntity : ICoreModel
    {
        Task<TEntity> ReadByIdAsync(Guid id);
        Task<List<TEntity>> ReadAsync(ExpressionStarter<TEntity> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> CreateAsync(TEntity entity);
        Task<int> DeleteAsync(Guid id);
    }
}

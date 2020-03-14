using CyberPet.Api.Models;
using CyberPet.Api.Repositories.Interfaces;
using LinqKit;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositories
{
    public class CoreRepository<TEntity> : ICoreRepository<TEntity> where TEntity : CoreModel
    {
        private readonly CyberPetContext _context;
        public CoreRepository(CyberPetContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(TEntity entity)
        {
            await _context.AddAsync<TEntity>(entity);
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> ReadAsync(ExpressionStarter<TEntity> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> ReadByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

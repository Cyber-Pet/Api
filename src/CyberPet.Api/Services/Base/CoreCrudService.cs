using CyberPet.Api.Models.Base;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories.Interfaces;
using CyberPet.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CyberPet.Api.Services.Base
{
    public class CoreCrudService<TEntity, TRepository> : ICoreCrudService<TEntity>
        where TEntity : CoreModel
        where TRepository : ICoreRepository<TEntity>
    {
        protected readonly TRepository _repository;
        protected readonly INotifier _notifier;

        public CoreCrudService(INotifier notifier, TRepository repository)
        {
            _notifier = notifier;
            _repository = repository;
        }
        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public virtual async Task<int> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity  = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                _notifier.Add("Nenhum registro encontrado");
                return null;
            }
            return entity;

        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return await _repository.GetByCondition(expression);
        }
    }
}

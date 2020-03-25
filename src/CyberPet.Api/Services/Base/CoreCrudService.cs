using CyberPet.Api.Models.Base;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories.Interfaces;
using CyberPet.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Services.Base
{
    public class CoreCrudService<TEntity, TRepository> : ICoreCrudService<TEntity>
        where TEntity : CoreModel
        where TRepository : ICoreRepository<TEntity>
    {
        protected readonly TRepository repository;
        protected readonly INotifier notifier;

        public CoreCrudService(INotifier notifier, TRepository repository)
        {
            this.notifier = notifier;
            this.repository = repository;
        }
        public async Task<int> CreateAsync(TEntity entity)
        {
            return await this.repository.CreateAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await this.repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await this.repository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            return await this.repository.UpdateAsync(entity);
        }
    }
}

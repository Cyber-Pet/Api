using AutoMapper;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.ViewModel.Base;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberPet.Api.Controllers.Base
{
    public class CoreCrudController<TService, TEntityViewModel, TEntity> : CoreController
        where TEntityViewModel : BaseViewModel
        where TService : ICoreCrudService<TEntity>
        where TEntity : ICoreModel
    {
        protected readonly TService _service;
        protected readonly IMapper _mapper;
        public CoreCrudController(INotifier notifier, IMapper mapper, TService service) : base(notifier)
        {
            _service = service;
            _mapper = mapper;
        }
        /// <summary> 
        /// Cadastra uma nova entidade
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<ActionResult<TEntityViewModel>> Post(TEntityViewModel entityViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var entity = this._mapper.Map<TEntity>(entityViewModel);
            entity.Id = NewId.NextGuid();
            var resultado = await _service.CreateAsync(entity);
            return CustomResponse("Entidade Cadastrada com Sucesso", resultado);
        }

        [HttpGet]
        public async Task<ActionResult<List<TEntityViewModel>>> GetAsync()
        {
            if (!ModelState.IsValid) return CustomBadRequest(ModelState);
            var registros = await _service.GetAllAsync();
            var result = _mapper.Map<List<TEntityViewModel>>(registros);
            return CustomResponse("Dados recuperados",result);
        }

        /// <summary>
        /// Lista os parametros de acordo o codigo passado
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TEntityViewModel>> Get(Guid id)
        {
            if (!ModelState.IsValid) return CustomBadRequest(ModelState);
            var resultado = await _service.GetByIdAsync(id);
            return CustomResponse("Registro Encontrado", _mapper.Map<TEntityViewModel>(resultado));
        }

        /// <summary>
        /// Atualiza os dados de acordo com os parametros passados
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TEntityViewModel>> Put(Guid id, TEntityViewModel entityViewModel)
        {
            if (!ModelState.IsValid) return CustomBadRequest(ModelState);
            entityViewModel.Id = id;
            var entity = _mapper.Map<TEntity>(entityViewModel);
            return CustomResponse("Registro Atualizado com Sucesso!",await _service.UpdateAsync(entity));
        }

        /// <summary>
        /// Remove o registro da base de dados
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

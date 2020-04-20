using AutoMapper;
using CyberPet.Api.Controllers.Base;
using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CyberPet.Api.Controllers
{
    public class BowlController : CoreCrudController<IBowlService, BowlRequest, BowlResponse, Bowl>
    {
        public BowlController(INotifier notifier, IMapper mapper, IBowlService bowlService) : base(notifier, mapper, bowlService) { }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<BowlResponse>> Post(BowlRequest entityViewModel)
        {
            return base.Post(entityViewModel);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult> Delete(Guid id)
        {
            return base.Delete(id);
        }
    }
}

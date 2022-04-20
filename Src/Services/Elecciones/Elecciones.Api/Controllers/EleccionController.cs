using Elecciones.Service.EventHandlers.Command;
using Elecciones.Service.Query;
using Elecciones.Service.Query.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elecciones.Api.Controllers
{
    [ApiController]
    [Route("v1/Elecciones")]
    public class EleccionController : ControllerBase
    {
        private readonly IEleccionQueryService _EleccionQueryService;
        private readonly ILogger<EleccionController> _logger;
        private readonly IMediator _mediator;

        public EleccionController(
           ILogger<EleccionController> logger,
           IEleccionQueryService EleccionQueryService,
           IMediator mediator)
        {
            _logger = logger;
            _EleccionQueryService = EleccionQueryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<EleccionDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<long> Candidato = null;

            if (!string.IsNullOrEmpty(ids))
            {
                Candidato = ids.Split(',').Select(x => Convert.ToInt64(x));
            }

            return await _EleccionQueryService.GetAllAsync(page, take, Candidato);
        }

        [HttpGet("{IdEleccion}")]
        public async Task<EleccionDto> Get(int IdEleccion)
        {
            return await _EleccionQueryService.GetAsync(IdEleccion);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EleccionCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(EleccionUpdateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }
    }
}

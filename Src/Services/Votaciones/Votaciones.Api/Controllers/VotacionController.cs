using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votaciones.Service.Query;

namespace Votaciones.Api.Controllers
{
    [ApiController]
    [Route("v1/Elecciones")]
    public class VotacionController : ControllerBase
    {
        private readonly IVotacionQueryService _VotacionQueryService;
        private readonly ILogger<VotacionController> _logger;
        private readonly IMediator _mediator;

        public VotacionController(
           ILogger<VotacionController> logger,
           IVotacionQueryService VotacionQueryService,
           IMediator mediator)
        {
            _logger = logger;
            _VotacionQueryService = VotacionQueryService;
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

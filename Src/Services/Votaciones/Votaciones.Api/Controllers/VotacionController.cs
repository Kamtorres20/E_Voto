using Elecciones.Service.Query.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votaciones.Service.EventHandlers.Command;
using Votaciones.Service.Query;

namespace Votaciones.Api.Controllers
{
    [ApiController]
    [Route("v1/Votaciones")]
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
        public async Task<DataCollection<VotacionDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<long> Candidato = null;

            if (!string.IsNullOrEmpty(ids))
            {
                Candidato = ids.Split(',').Select(x => Convert.ToInt64(x));
            }

            return await _VotacionQueryService.GetAllAsync(page, take, Candidato);
        }

        [HttpGet("{IdVotacion}")]
        public async Task<VotacionDto> Get(int IdVotacion)
        {
            return await _VotacionQueryService.GetAsync(IdVotacion);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VotacionCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(VotacionUpdateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }
    }
}

using Candidatos.Service.EventHandlers.Command;
using Candidatos.Service.Queries;
using Candidatos.Service.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidatos.Api.Controllers
{
    [ApiController]
    [Route("v1/Candidato")]
    public class CandidatosController : ControllerBase
    {
        private readonly ICandidatoQueryService _CandidatoQueryService;
        private readonly ILogger<CandidatosController> _logger;
        private readonly IMediator _mediator;

        public CandidatosController(
            ILogger<CandidatosController> logger,
            ICandidatoQueryService CandidatoQueryService,
            IMediator mediator)
        {
            _logger = logger;
            _CandidatoQueryService = CandidatoQueryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<CandidatoDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<long> Candidato = null;

            if (!string.IsNullOrEmpty(ids))
            {
                Candidato = ids.Split(',').Select(x => Convert.ToInt64(x));
            }

            return await _CandidatoQueryService.GetAllAsync(page, take, Candidato);
        }

        [HttpGet("{DocumentType},{identity}")]
        public async Task<CandidatoDto> Get(int DocumentType,string identity)
        {
            return await _CandidatoQueryService.GetAsync(DocumentType, identity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidatoCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CandidatoUpdateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }
    }
}

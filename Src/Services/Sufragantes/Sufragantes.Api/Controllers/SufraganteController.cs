using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using Sufragantes.Service.EventHandlers.Command;
using Sufragantes.Service.Queries;
using Sufragantes.Service.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sufragantes.Api.Controllers
{
    [ApiController]
    [Route("v1/Sufragante")]
    public class SufraganteController : ControllerBase
    {
        private readonly ISufraganteQueryService _SufraganteQueryService;
        private readonly ILogger<SufraganteController> _logger;
        private readonly IMediator _mediator;

        public SufraganteController(
            ILogger<SufraganteController> logger,
            ISufraganteQueryService SufraganteQueryService,
            IMediator mediator)
        {
            _logger = logger;
            _SufraganteQueryService = SufraganteQueryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<SufraganteDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<long> Sufragante = null;

            if (!string.IsNullOrEmpty(ids))
            {
                Sufragante = ids.Split(',').Select(x => Convert.ToInt64(x));
            }

            return await _SufraganteQueryService.GetAllAsync(page, take, Sufragante);
        }

        [HttpGet("{DocumentType},{identity}")]
        public async Task<SufraganteDto> Get(int DocumentType,string identity)
        {
            return await _SufraganteQueryService.GetAsync(DocumentType, identity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SufraganteCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(SufraganteUpdateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }
    }
}

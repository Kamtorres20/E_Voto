using Elecciones.Domain;
using Elecciones.Persistence.Database;
using Elecciones.Service.EventHandlers.Command;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Elecciones.Service.EventHandlers
{
    public class EleccionCreateEventHandlers : INotificationHandler<EleccionCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EleccionCreateEventHandlers> _logger;


        public EleccionCreateEventHandlers(
         ApplicationDbContext context,
         ILogger<EleccionCreateEventHandlers> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(EleccionCreateCommand command, CancellationToken cancellationtoken)
        {
            await _context.AddAsync(new Eleccion
            {
                Titulo = command.Titulo,
                DescripcionTitulo = command.DescripcionTitulo,
                orden = command.orden,
                Estado = command.Estado,
                
            });

            await _context.SaveChangesAsync();

        }

    }
}

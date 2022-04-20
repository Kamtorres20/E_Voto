using Elecciones.Persistence.Database;
using Elecciones.Service.EventHandlers.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Elecciones.Service.EventHandlers
{
    public class EleccionUpdateEventHandlers : INotificationHandler<EleccionUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EleccionUpdateEventHandlers> _logger;

        public EleccionUpdateEventHandlers(
            ApplicationDbContext context,
            ILogger<EleccionUpdateEventHandlers> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(EleccionUpdateCommand command, CancellationToken cancellationtoken)
        {
            var Posts = await _context.Tbl_Elecciones.Where(x => x.Id == command.Id).ToListAsync();

            var entry = Posts.SingleOrDefault(x => x.Id == command.Id);

            entry.Titulo = command.Titulo;
            entry.DescripcionTitulo = command.DescripcionTitulo;
            entry.orden = command.orden;
            entry.Estado = command.Estado;
           

            await _context.SaveChangesAsync();

        }

    }
}

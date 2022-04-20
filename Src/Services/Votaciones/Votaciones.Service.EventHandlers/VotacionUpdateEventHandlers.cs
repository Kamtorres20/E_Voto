using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Votaciones.Persistence.Database;
using Votaciones.Service.EventHandlers.Command;

namespace Votaciones.Service.EventHandlers
{
    public class VotacionUpdateEventHandlers : INotificationHandler<VotacionUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VotacionUpdateEventHandlers> _logger;

        public VotacionUpdateEventHandlers(
            ApplicationDbContext context,
            ILogger<VotacionUpdateEventHandlers> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(VotacionUpdateCommand command, CancellationToken cancellationtoken)
        {
            var Posts = await _context.Tbl_Votacion.Where(x => x.Id == command.Id).ToListAsync();

            var entry = Posts.SingleOrDefault(x => x.Id == command.Id);

            entry.Id_Eleccion = command.Id_Eleccion;
            entry.Id_Candidato = command.Id_Candidato;
            entry.Id_Sufragante = command.Id_Sufragante;
            entry.Salto = command.Salto;


            await _context.SaveChangesAsync();

        }
    }
}

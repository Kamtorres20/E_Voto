using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Votaciones.Domain;
using Votaciones.Persistence.Database;
using Votaciones.Service.EventHandlers.Command;

namespace Votaciones.Service.EventHandlers 
{
    public class VotacionCreateEventHandlers : INotificationHandler<VotacionCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VotacionCreateEventHandlers> _logger;


        public VotacionCreateEventHandlers(
         ApplicationDbContext context,
         ILogger<VotacionCreateEventHandlers> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(VotacionCreateCommand command, CancellationToken cancellationtoken)
        {
            await _context.AddAsync(new Votacion
            {
                Id_Eleccion = command.Id_Eleccion,
                Id_Candidato = command.Id_Candidato,
                Id_Sufragante = command.Id_Sufragante,
                Salto = command.Salto,

            });

            await _context.SaveChangesAsync();

        }

    }
}

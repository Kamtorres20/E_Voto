using Candidatos.Domain;
using Candidatos.Persistence.Database;
using Candidatos.Service.EventHandlers.Command;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Service.EventHandlers
{
    public class CandidatoCreateEventHandlers : INotificationHandler<CandidatoCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CandidatoCreateEventHandlers> _logger;

        public CandidatoCreateEventHandlers(
         ApplicationDbContext context,
         ILogger<CandidatoCreateEventHandlers> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(CandidatoCreateCommand command, CancellationToken cancellationtoken)
        {
            await _context.AddAsync(new Candidato
            {
                Tipo_Identificacion = command.Tipo_Identificacion,
                Identificacion = command.Identificacion,
                Nombres = command.Nombres,
                Apellidos = command.Apellidos,
                FechaNacimiento = command.FechaNacimiento,
                Foto = command.Foto,
                CorreoElectronico = command.CorreoElectronico,
                Propuesta = command.Propuesta,
                DescripcionPropuesta = command.DescripcionPropuesta
            });

            await _context.SaveChangesAsync();

        }
    }
}

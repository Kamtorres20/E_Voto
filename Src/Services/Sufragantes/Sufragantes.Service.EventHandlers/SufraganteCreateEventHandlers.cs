using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sufragantes.Domain;
using Sufragantes.Persistence.Database;
using Sufragantes.Service.EventHandlers.Command;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sufragantes.Service.EventHandlers
{
    public class SufraganteCreateEventHandlers : INotificationHandler<SufraganteCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SufraganteCreateEventHandlers> _logger;

        public SufraganteCreateEventHandlers(
         ApplicationDbContext context,
         ILogger<SufraganteCreateEventHandlers> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(SufraganteCreateCommand command, CancellationToken cancellationtoken)
        {
            await _context.AddAsync(new Sufragante
            {
                Tipo_Identificacion = command.Tipo_Identificacion,
                Identificacion = command.Identificacion,
                Nombres = command.Nombres,
                Apellidos = command.Apellidos,
                FechaNacimiento = command.FechaNacimiento,
                Sexo = command.Sexo,
                CorreoElectronico = command.CorreoElectronico
            });

            await _context.SaveChangesAsync();

        }
    }
}

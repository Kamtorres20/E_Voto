using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sufragantes.Domain;
using Sufragantes.Persistence.Database;
using Sufragantes.Service.EventHandlers.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufragantes.Service.EventHandlers
{
    public class SufraganteUpdateEventHandlers: INotificationHandler<SufraganteUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SufraganteUpdateEventHandlers> _logger;

        public SufraganteUpdateEventHandlers(
        ApplicationDbContext context,
        ILogger<SufraganteUpdateEventHandlers> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(SufraganteUpdateCommand command, CancellationToken cancellationtoken)
        {
            var Posts = await _context.tbl_Sufragantes.Where(x => x.Tipo_Identificacion == command.Tipo_Identificacion
                                                               && x.Identificacion == command.Identificacion).ToListAsync();

            var entry = Posts.SingleOrDefault(x => x.Tipo_Identificacion == command.Tipo_Identificacion
                                                                && x.Identificacion == command.Identificacion);

            entry.Nombres = command.Nombres;
            entry.Apellidos = command.Apellidos;
            entry.FechaNacimiento = command.FechaNacimiento;
            entry.CorreoElectronico = command.CorreoElectronico;
            entry.Sexo = command.Sexo;

            await _context.SaveChangesAsync();

        }
    }
}

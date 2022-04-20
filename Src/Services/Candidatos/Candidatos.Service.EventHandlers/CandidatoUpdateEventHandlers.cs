using Candidatos.Persistence.Database;
using Candidatos.Service.EventHandlers.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Candidatos.Service.EventHandlers
{
    public class CandidatoUpdateEventHandlers : INotificationHandler<CandidatoUpdateCommand>
    {

        private readonly ApplicationDbContext _context;
        private readonly ILogger<CandidatoUpdateEventHandlers> _logger;
        public CandidatoUpdateEventHandlers(
            ApplicationDbContext context,
            ILogger<CandidatoUpdateEventHandlers> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(CandidatoUpdateCommand command, CancellationToken cancellationtoken)
        {
            var Posts = await _context.tbl_Candidatos.Where(x => x.Tipo_Identificacion == command.Tipo_Identificacion
                                                               && x.Identificacion == command.Identificacion).ToListAsync();

            var entry = Posts.SingleOrDefault(x => x.Tipo_Identificacion == command.Tipo_Identificacion
                                                                && x.Identificacion == command.Identificacion);

            entry.Nombres = command.Nombres;
            entry.Apellidos = command.Apellidos;
            entry.FechaNacimiento = command.FechaNacimiento;
            entry.CorreoElectronico = command.CorreoElectronico;
            entry.Foto = command.Foto;
            entry.Propuesta = command.Propuesta;
            entry.DescripcionPropuesta = command.DescripcionPropuesta;

            await _context.SaveChangesAsync();

        }
    }
}

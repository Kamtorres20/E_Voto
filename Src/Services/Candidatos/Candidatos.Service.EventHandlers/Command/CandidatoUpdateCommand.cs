using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidatos.Service.EventHandlers.Command
{
    public class CandidatoUpdateCommand : INotification
    {
        public int Tipo_Identificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Foto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Propuesta { get; set; }
        public string DescripcionPropuesta { get; set; }
    }
}

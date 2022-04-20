using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufragantes.Service.EventHandlers.Command
{
    public class SufraganteUpdateCommand : INotification
    {
        public int Tipo_Identificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Sexo { get; set; }
        public string CorreoElectronico { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Votaciones.Service.EventHandlers.Command
{
    public class VotacionCreateCommand : INotification
    {
        public long Id_Eleccion { get; set; }
        public long Id_Candidato { get; set; }
        public long Id_Sufragante { get; set; }
        public int Salto { get; set; }
    }
}

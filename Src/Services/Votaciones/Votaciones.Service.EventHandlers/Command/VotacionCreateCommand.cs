using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Votaciones.Service.EventHandlers.Command
{
    public class VotacionCreateCommand : INotification
    {
        public int Id_Eleccion { get; set; }
        public int Id_Candidato { get; set; }
        public int Id_Sufragante { get; set; }
        public int Salto { get; set; }
    }
}

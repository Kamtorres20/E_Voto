using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elecciones.Service.EventHandlers.Command
{
    public class EleccionCreateCommand : INotification
    {
        public string Titulo { get; set; }
        public string DescripcionTitulo { get; set; }
        public int orden { get; set; }
        public int Estado { get; set; }
    }
}

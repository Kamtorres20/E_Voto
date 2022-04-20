using System;
using System.Collections.Generic;
using System.Text;

namespace Elecciones.Service.Query.DTOs
{
    public class EleccionDto
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string DescripcionTitulo { get; set; }
        public int orden { get; set; }
        public int Estado { get; set; }
    }
}

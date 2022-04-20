using System;
using System.Collections.Generic;
using System.Text;

namespace Elecciones.Service.Query.DTOs
{
    public class VotacionDto
    {
        public long Id { get; set; }
        public long Id_Eleccion { get; set; }
        public long Id_Candidato { get; set; }
        public long Id_Sufragante { get; set; }
        public int Salto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Elecciones.Service.Query.DTOs
{
    public class VotacionDto
    {
        public long Id { get; set; }
        public int Id_Eleccion { get; set; }
        public int Id_Candidato { get; set; }
        public int Id_Sufragante { get; set; }
        public int Salto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sufragantes.Service.Queries.DTOs
{
    public class SufraganteDto
    {
        public long Id { get; set; }
        public int Tipo_Identificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Sexo { get; set; }
        public string CorreoElectronico { get; set; }
    }
}

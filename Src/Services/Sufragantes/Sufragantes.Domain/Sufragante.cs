using System;
using System.ComponentModel.DataAnnotations;

namespace Sufragantes.Domain
{
    public class Sufragante
    {
        [Key]
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

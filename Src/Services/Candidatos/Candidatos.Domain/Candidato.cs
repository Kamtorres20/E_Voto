using System;
using System.ComponentModel.DataAnnotations;

namespace Candidatos.Domain
{
    public class Candidato
    {
        [Key]
        public long Id { get; set; }
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

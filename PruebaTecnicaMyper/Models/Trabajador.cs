using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaMyper.Models
{
    public class Trabajador
    {
        [Key]
        public string NumDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoDocumento { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNac { get; set; }
        public string Direccion { get; set; }
        public string Foto { get; set; } //URL local
    }
}

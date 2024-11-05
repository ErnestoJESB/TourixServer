using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ActividadImagenDTO
    {
        public int ActividadID { get; set; }
        public int AgenciaID { get; set; } 
        public string NombreActividad { get; set; } 
        public string? Descripcion { get; set; }  
        public decimal Precio { get; set; } 
        public int Duracion { get; set; }
        public string Direccion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string ImagenURL { get; set; }
    }
}

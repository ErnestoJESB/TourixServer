using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ReservacionDTO
    {
        public int ReservacionID { get; set; }
        public string NombreCliente{ get; set; }
        public string NombreActividad{ get; set; }
        public DateTime FechaReservacion { get; set; }
        public int CantidadPersonas { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string? ImagenURL { get; set; }
    }
}

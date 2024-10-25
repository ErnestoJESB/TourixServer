using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservaciones
    {
        [Key]
        public int ReservacionID { get; set; }
        public int ClienteID { get; set; }
        public int? ActividadID { get; set; }
        public int? PaqueteID { get; set; }
        public DateTime FechaReservacion { get; set; }
        public int CantidadPersonas { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}

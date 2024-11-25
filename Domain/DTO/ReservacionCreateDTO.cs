using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ReservacionCreateDTO
    {
        public int ClienteID { get; set; }
        public DateTime FechaReservacion { get; set; }
        public int CantidadPersonas { get; set; }
        public decimal Total { get; set; }
        public string Tipo { get; set; }
        public int ID { get; set; }
        public int DisponibilidadID { get; set; }
    }
}

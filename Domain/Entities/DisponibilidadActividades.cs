using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DisponibilidadActividades
    {
        [Key]
        public int DisponibilidadID { get; set; }
        public int ActividadID { get; set; }
        public int CupoMaximo { get; set; }
        public int CupoRestante { get; set; }
        public DateTime FechaHora { get; set; }
    }
}

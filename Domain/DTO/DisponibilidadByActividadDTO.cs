using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class DisponibilidadByActividadDTO
    {
        public int ActividadId { get; set; }
        public int CupoRestante { get; set; }
        public DateTime FechaHora { get; set; }
    }
}

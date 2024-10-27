using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class DisponibilidadActividadesDTO
    { 
        public int ActividadID { get; set; }
        public int CupoMaximo { get; set; }
        public DateTime FechaHora { get; set; }
    }
}

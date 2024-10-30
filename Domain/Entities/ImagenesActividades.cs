using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ImagenesActividades
    {
        [Key]
        public int ImagenID { get; set; }
        public string ImagenURL { get; set; }
        public int ActividadID { get; set; }
    }
}

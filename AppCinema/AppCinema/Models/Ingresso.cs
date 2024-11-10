using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCinema.Models
{
    internal class Ingresso
    {
        public double Valor { get; set; }
        public string Horario { get; set; }
        public string Data { get; set; }
        public string Tipo { get; set; }
        public int QuantiIngre { get; set; }
    }
}

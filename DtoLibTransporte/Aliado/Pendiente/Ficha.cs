using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Aliado.Pendiente
{
    public class Ficha
    {
        public int aliadoId { get; set; }
        public string aliadoCod { get; set; }
        public string aliadoCiRif { get; set; }
        public string aliadoNombre { get; set; }
        public decimal importeDiv { get; set; }
        public decimal acumuladoDiv { get; set; }
        public decimal montoAnticipoDiv { get; set; }
        public decimal montoAnticipoRetDiv { get; set; }
        public decimal montoAnticipoAnuladoDiv { get; set; }
        public decimal montoAnticipoRetAnuladoDiv { get; set; }
        public int cntDoc { get; set; }
    }
}
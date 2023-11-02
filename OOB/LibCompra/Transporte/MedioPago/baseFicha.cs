using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.MedioPago
{
    abstract public class baseFicha
    {
        public string id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
    }
}
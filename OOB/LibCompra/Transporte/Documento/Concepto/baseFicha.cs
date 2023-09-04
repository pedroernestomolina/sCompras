using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Documento.Concepto
{
    abstract public class baseFicha
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }
}
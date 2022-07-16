using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Documento.Cargar.Factura
{
    
    public class FichaPrdDeposito
    {

        public string autoPrd { get; set; }
        public string autoDep { get; set; }
        public decimal cantidadUnd { get; set; }
        public string nombrePrd { get; set; }


        public FichaPrdDeposito()
        {
            autoPrd = "";
            autoDep = "";
            cantidadUnd = 0.0m;
            nombrePrd = "";
        }

    }

}
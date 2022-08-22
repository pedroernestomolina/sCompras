using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Documento.Cargar.Factura
{
    
    public class FichaPrdPrecioHistorico
    {

        public string autoPrd { get; set; }
        public string nota { get; set; }
        public string precioId { get; set; }
        public decimal precio { get; set; }
        public string empaque { get; set; }
        public int contenido { get; set; }
        public  decimal tasaFactorCambio{ get; set; }


        public FichaPrdPrecioHistorico()
        {
            autoPrd = "";
            nota = "";
            precioId = "";
            precio = 0m;
            contenido = 0;
            tasaFactorCambio = 0m;
        }

    }

}
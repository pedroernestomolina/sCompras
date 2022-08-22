using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Documento.Cargar.Factura
{
    
    public class FichaPrecio
    {

        public string autoEmp { get; set; }
        public int contenido { get; set; }
        public decimal utilidad { get; set; }
        public decimal precioNeto { get; set; }
        public decimal precioFullDivisa { get; set; }


        public FichaPrecio()
        {
            autoEmp = "";
            contenido = 0;
            utilidad = 0.0m;
            precioNeto = 0m;
            precioFullDivisa = 0m;
        }

    }

}
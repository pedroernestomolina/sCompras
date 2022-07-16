﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Documento.Cargar.Factura
{
    
    public class FichaPrdPrecio
    {

        public string autoPrd { get; set; }
        public decimal pDivisaFull_1 { get; set; }
        public decimal pDivisaFull_2 { get; set; }
        public decimal pDivisaFull_3 { get; set; }
        public decimal pDivisaFull_4 { get; set; }
        public decimal pDivisaFull_5 { get; set; }
        public decimal precioNeto_1 { get; set; }
        public decimal precioNeto_2 { get; set; }
        public decimal precioNeto_3 { get; set; }
        public decimal precioNeto_4 { get; set; }
        public decimal precioNeto_5 { get; set; }
        //
        public decimal pDivisaFull_may_1 { get; set; }
        public decimal pDivisaFull_may_2 { get; set; }
        public decimal precioNeto_may_1 { get; set; }
        public decimal precioNeto_may_2 { get; set; }


        public FichaPrdPrecio() 
        {
            autoPrd = "";
            pDivisaFull_1 = 0.0m;
            pDivisaFull_2 = 0.0m;
            pDivisaFull_3 = 0.0m;
            pDivisaFull_4 = 0.0m;
            pDivisaFull_5 = 0.0m;
            precioNeto_1 = 0.0m;
            precioNeto_2 = 0.0m;
            precioNeto_3 = 0.0m;
            precioNeto_4 = 0.0m;
            precioNeto_5 = 0.0m;
            //
            pDivisaFull_may_1 = 0.0m;
            pDivisaFull_may_2 = 0.0m;
            precioNeto_may_1 = 0.0m;
            precioNeto_may_2 = 0.0m;
        }

    }

}
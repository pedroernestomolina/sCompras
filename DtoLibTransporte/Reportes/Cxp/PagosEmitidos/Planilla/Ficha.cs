﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Planilla
{
    public class Ficha
    {
        public string reciboNro { get; set; }
        public DateTime fechaMov { get; set; }
        public decimal importeDiv { get; set; }
        public decimal montoRecDiv { get; set; }
        public decimal tasaCambio { get; set; }
        public string notasMov { get; set; }
        public string nombreProv { get; set; }
        public string ciRifProv { get; set; }
        public string dirProv { get; set; }
        public string estatusMov { get; set; }
        //
        public List<Documento> doc { get; set; }
        public List<MetodoPago> metPago { get; set; }
        public List<Caja> caja { get; set; }
        //
        public decimal anticipoComoMedioPago { get; set; }
        public decimal guardarComoAnticipo { get; set; }
    }
}
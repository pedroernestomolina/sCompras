﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Cxp.PagosEmitidos.Planilla
{
    public class MetodoPago
    {
        public string descMet { get; set; }
        public string codMet { get; set; }
        public string opLote { get; set; }
        public string opRef { get; set; }
        public string opBanco { get; set; }
        public string opNroCta { get; set; }
        public string opNroTransf { get; set; }
        public DateTime opFecha { get; set; }
        public string opDetalle { get; set; }
        public decimal opMonto { get; set; }
        public decimal opTasa { get; set; }
        public string opAplicaConversion { get; set; }
    }
}
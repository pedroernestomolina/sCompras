﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.CxpDoc.Pago.Agregar
{
    public class DataCaja
    {
        public int idCaja { get; set; }
        public string codCaja { get; set; }
        public string descCaja { get; set; }
        public decimal monto { get; set; }
        public CajaMov cajaMov { get; set; }
    }
}
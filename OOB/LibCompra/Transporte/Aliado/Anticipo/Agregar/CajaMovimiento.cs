﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Aliado.Anticipo.Agregar
{
    public class CajaMovimiento
    {
        public DateTime fechaMov { get; set; }
        public string descMov { get; set; }
        public decimal montoMovMonAct{ get; set; }
        public decimal montoMovMonDiv { get; set; }
        public decimal factorCambio { get; set; }
        public bool movFueDivisa { get; set; }
    }
}
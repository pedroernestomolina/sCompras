﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Aliado.PagoServ.Lista
{
    public class Filtro
    {
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public int IdAliado { get; set; }
        public string Estatus { get; set; }
    }
}
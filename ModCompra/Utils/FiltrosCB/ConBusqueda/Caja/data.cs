﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.FiltrosCB.ConBusqueda.Caja
{
    public class data: Idata
    {
        public object Ficha { get; set; }
        public string codigo { get; set; }
        public string desc { get; set; }
        public string id { get; set; }


        public data(OOB.LibCompra.Transporte.Caja.Lista.Ficha rg)
        {
            Ficha = rg;
            id = rg.id.ToString().Trim().ToUpper();
            codigo = rg.codigo;
            desc = rg.descripcion;
        }
    }
}
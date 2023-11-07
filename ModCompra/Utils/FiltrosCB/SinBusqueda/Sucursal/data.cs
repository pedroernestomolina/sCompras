using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.FiltrosCB.SinBusqueda.Sucursal
{
    public class data: Idata
    {
        public object Ficha { get; set; }
        public string codigo { get; set; }
        public string desc { get; set; }
        public string id { get; set; }


        public data(OOB.LibCompra.Sucursal.Data.Ficha rg)
        {
            Ficha = rg;
            codigo = rg.codigo;
            desc = rg.nombre;
            id = rg.auto;
        }
    }
}
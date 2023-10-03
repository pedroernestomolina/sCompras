using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.FiltrosCB.ConBusqueda.Proveedor
{
    public class data: Idata
    {
        private OOB.LibCompra.Proveedor.Data.Ficha rg;


        public object Ficha { get; set; }
        public string codigo { get; set; }
        public string desc { get; set; }
        public string id { get; set; }


        public data(OOB.LibCompra.Proveedor.Data.Ficha rg)
        {
            Ficha = rg;
            id = rg.autoId;
            codigo = rg.codigo;
            desc = rg.nombreRazonSocial;
        }
    }
}
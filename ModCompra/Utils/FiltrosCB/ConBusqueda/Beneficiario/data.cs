using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.FiltrosCB.ConBusqueda.Beneficiario
{
    public class data: Idata
    {
        private OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha rg;


        public object Ficha { get; set; }
        public string codigo { get; set; }
        public string desc { get; set; }
        public string id { get; set; }


        public data(OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha rg)
        {
            Ficha = rg;
            id = rg.id.ToString().Trim().ToUpper();
            codigo = rg.cirif;
            desc = rg.nombreRazonSocial;
        }
    }
}
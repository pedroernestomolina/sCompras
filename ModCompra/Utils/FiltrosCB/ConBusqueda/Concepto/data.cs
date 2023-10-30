using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.FiltrosCB.ConBusqueda.Concepto
{
    public class data: Idata
    {
        private OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha rg;


        public object Ficha { get; set; }
        public string codigo { get; set; }
        public string desc { get; set; }
        public string id { get; set; }


        public data(OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha rg)
        {
            Ficha = rg;
            id = rg.id.ToString().Trim().ToUpper();
            codigo = rg.codigo;
            desc = rg.descripcion;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CompraGasto.Handlres.Generar
{
    public class dataTipoDocumento: LibUtilitis.Opcion.IData
    {
        public string codigo { get; set; }
        public string desc { get; set; }
        public string id { get; set; }
    }
}
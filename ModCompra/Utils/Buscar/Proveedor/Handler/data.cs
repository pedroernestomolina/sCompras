using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Buscar.Proveedor.Handler
{
    public class data
    {
        private OOB.LibCompra.Proveedor.Data.Ficha _ficha;


        public OOB.LibCompra.Proveedor.Data.Ficha Ficha { get { return _ficha; } }
        public string id { get { return _ficha.autoId; } }
        public string ciRif { get { return _ficha.ciRif; } }
        public string codigo { get { return _ficha.codigo; } }
        public string nombre { get { return _ficha.nombreRazonSocial; } }
        public string dirFiscal { get { return _ficha.direccionFiscal; } }
        public data(OOB.LibCompra.Proveedor.Data.Ficha  ficha)
        {
            _ficha = ficha;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Caja.Maestro
{
    public class data: Utils.Maestro.Idata
    {
        private OOB.LibCompra.Transporte.Caja.Lista.Ficha _ficha;


        public OOB.LibCompra.Transporte.Caja.Lista.Ficha Ficha { get { return _ficha; } }
        public string descripcion {get;set;}
        public string codigo {get;set;}


        public data(OOB.LibCompra.Transporte.Caja.Lista.Ficha ficha)
        {
            _ficha = ficha;
            codigo = ficha.codigo;
            descripcion = ficha.descripcion;
        }
    }
}
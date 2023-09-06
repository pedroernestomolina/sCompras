using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Concepto.Maestro
{
    public class data: Utils.Maestro.Idata
    {
        private OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha _ficha;


        public OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha Ficha { get { return _ficha; } }
        public string descripcion {get;set;}
        public string codigo {get;set;}


        public data(OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha ficha)
        {
            _ficha = ficha;
            codigo = ficha.codigo;
            descripcion = ficha.descripcion;
        }
    }
}
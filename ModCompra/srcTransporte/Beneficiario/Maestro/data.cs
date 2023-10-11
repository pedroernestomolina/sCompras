using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Beneficiario.Maestro
{
    public class data: Utils.Maestro.Idata
    {
        private OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha _ficha;


        public OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha Ficha { get { return _ficha; } }
        public string descripcion {get;set;}
        public string codigo {get;set;}


        public data(OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha rg)
        {
            _ficha = rg;
            codigo = rg.cirif;
            descripcion = rg.nombreRazonSocial;
        }
    }
}
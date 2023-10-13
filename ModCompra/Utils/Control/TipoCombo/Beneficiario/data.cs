using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Control.TipoCombo.Beneficiario
{
    public class data: Idata
    {
        private OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha _ficha;


        public string codigo {get;set;}
        public string desc {get;set;}
        public string id {get;set;}
        public OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha Ficha { get { return _ficha; } }


        public data(OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha ficha)
        {
            _ficha = ficha;
            codigo = "";
            desc = ficha.nombreRazonSocial;
            id = ficha.id.ToString().Trim();
        }
    }
}
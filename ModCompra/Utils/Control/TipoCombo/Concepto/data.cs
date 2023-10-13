using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Control.TipoCombo.Concepto
{
    public class data: Idata
    {
        private OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha _ficha;


        public string codigo {get;set;}
        public string desc {get;set;}
        public string id {get;set;}
        public OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha Ficha { get { return _ficha; } }


        public data(OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha ficha)
        {
            _ficha = ficha;
            codigo = "";
            desc = ficha.descripcion;
            id = ficha.id.ToString().Trim();
        }
    }
}
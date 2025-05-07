using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.usesCase.CargarMediosPago
{
    public class data : Utils.FiltrosCB.Idata 
    {
        public object Ficha { get; set; }
        public string codigo { get; set; }
        public string desc { get; set; }
        public string id { get; set; }
        //
        public data(object rg)
        {
            var _ficha = (OOB.LibCompra.Transporte.MedioPago.Lista.Ficha)rg;
            codigo = _ficha.codigo;
            desc = _ficha.nombre;
            id = _ficha.id;
            Ficha = _ficha;
        }
    }
}
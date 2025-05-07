using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.usesCase.CargarMediosPago
{
    public class UC: IUC 
    {
        public IEnumerable<Utils.FiltrosCB.Idata> Execute()
        {
            var _rt = new List<Utils.FiltrosCB.Idata>();
            var r01 = Sistema.MyData.Transporte_MedioPago_GetLista();
            var _lt = r01.Lista.OrderBy(o => o.nombre).ToList();
            foreach (var rg in _lt)
            {
                _rt.Add(new data(rg));
            }
            return _rt;
        }
    }
}

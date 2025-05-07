using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.usesCase.CargarMediosPago
{
    public interface IUC
    {
        IEnumerable<Utils.FiltrosCB.Idata> Execute();
    }
}

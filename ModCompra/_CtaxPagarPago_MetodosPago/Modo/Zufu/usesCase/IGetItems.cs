using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.Modo.Zufu.usesCase
{
    public interface IGetItems
    {
        void setLista(IEnumerable<object> enumerable);
        IEnumerable<_CtaxPagarPago_MetodosPago.Interfaces.IItem> Execute();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.Modo.Zufu.usesCase
{
    public class UC_GetItems: IGetItems
    {
        private IEnumerable<object> _lista;
        //
        public void setLista(IEnumerable<object> lista)
        {
            _lista = lista;
        }
        public IEnumerable<_CtaxPagarPago_MetodosPago.Interfaces.IItem> Execute()
        {
            return Convertidores.convertToItem(_lista);
        }
    }
}

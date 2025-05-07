using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.Interfaces
{
    public interface IListaItems: _CtaxPagar.Interfaces.ILista
    {
        void EliminarItem(object item);
        void AgregarItem(object item);
    }
}
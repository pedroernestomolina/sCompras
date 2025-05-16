using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Interfaces.PanelMetPagoListar
{
    public interface ILista<T>: 
        ModCompra.__.Interfaces.ILista<T>
    {
        void EliminarItem(T item);
        void AgregarItem(T item);
    }
}

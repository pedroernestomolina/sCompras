using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.__.Interfaces
{
    public interface ILista<T>
    {
        object GetDataSource { get; }
        IEnumerable<T> Items { get; }
        T ItemActual { get; }
        int GetCntItems { get; }
        //
        void Inicializa();
        void CargarItems(IEnumerable<T> items);
    }
}
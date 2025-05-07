using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Interfaces
{
    public interface ILista
    {
        int GetCntItems { get; }
        object ItemActual { get; }
        IEnumerable<object> GetItems { get; }
        object GetDataSource { get; }
        //
        void Inicializa();
        void CargarData(IEnumerable<object> lst);
    }
}
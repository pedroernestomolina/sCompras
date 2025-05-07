using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.reportes
{
    public interface IRepLista: IRep
    {
        void setFiltrosBusq(string filtros);
        void setDataCargar(IEnumerable<object> lst);
    }
}
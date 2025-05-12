using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Reportes
{
    public interface IRepLista<T>: IRep
    {
        void setFiltrosBusq(string filtros);
        void setDataCargar(IEnumerable<T> lst);
    }
}
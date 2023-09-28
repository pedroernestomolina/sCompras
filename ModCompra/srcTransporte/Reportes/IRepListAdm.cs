using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes
{
    public interface IRepListAdm: IRep
    {
        void setFiltrosBusq(string filtros);
        void setDataCargar(IEnumerable<object> lst);
    }
}
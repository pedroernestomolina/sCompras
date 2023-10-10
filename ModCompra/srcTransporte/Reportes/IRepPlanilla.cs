using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes
{
    public interface IRepPlanilla: IRep
    {
        void setIdDoc(object idDoc);
    }
}
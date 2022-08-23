using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes
{
    
    public interface IReporte
    {

        void setData(IEnumerable<object> lst);
        void Generar();

    }

}
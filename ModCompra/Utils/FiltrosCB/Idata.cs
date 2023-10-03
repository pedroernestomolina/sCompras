using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.FiltrosCB
{
    public interface Idata: LibUtilitis.Opcion.IData
    {
        object  Ficha { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Configuracion.Modulo
{
    
    public interface IConf: HlpGestion.IGestion, HlpGestion.IAbandonar, HlpGestion.IProcesar
    {

        void setCambiarPrecioVenta(bool cnf);
        bool GetCambiarPrecioVenta { get; }

    }

}

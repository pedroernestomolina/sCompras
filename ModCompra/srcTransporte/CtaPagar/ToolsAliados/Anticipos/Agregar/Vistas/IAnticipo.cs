using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Anticipos.Agregar.Vistas
{
    public interface IAnticipo: HlpGestion.IGestion, HlpGestion.IProcesar, HlpGestion.IAbandonar
    {
        Idata data { get;  }
        Icaja caja { get; }

        void setAliadoCargar(int id);
        void ActualizarSaldoCaja();
    }
}
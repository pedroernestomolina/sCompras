using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Vistas
{
    public interface IPagServ: HlpGestion.IGestion, HlpGestion.IAbandonar, HlpGestion.IProcesar
    {
        IEnt data { get; }
        void setServiciosAliado(int idAliado);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Anular.Vista
{
    public interface IAnular: HlpGestion.IGestion , HlpGestion.IProcesar, HlpGestion.IAbandonar
    {
        string Get_Motivo { get; }
        void setMotivo(string desc);
    }
}
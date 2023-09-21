using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Componente.Monto.Vistas
{
    public interface IMonto: HlpGestion.IGestion, HlpGestion.IProcesar, HlpGestion.IAbandonar
    {
        decimal Get_Monto { get; }

        void setMonto(decimal _monto);
    }
}
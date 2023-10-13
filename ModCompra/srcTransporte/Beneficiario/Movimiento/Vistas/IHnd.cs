using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Beneficiario.Movimiento.Vistas
{
    public interface IHnd: HlpGestion.IGestion, HlpGestion.IAbandonar, HlpGestion.IProcesar
    {
        IHndMov Mov { get; }
        Utils.Componente.CajaMonto.Vista.IHnd caja { get; }

        void ActualizarSaldoCaja();
    }
}

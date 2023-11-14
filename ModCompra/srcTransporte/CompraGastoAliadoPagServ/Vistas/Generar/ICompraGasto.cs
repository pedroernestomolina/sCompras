using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CompraGastoAliadoPagServ.Vistas.Generar
{
    public interface ICompraGasto : HlpGestion.IGestion, HlpGestion.IAbandonar, HlpGestion.IProcesar
    {
        IHndData HndData { get; }
        void BuscarPagoServAliadoSinProcesar();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.PagoDoc.Vista
{
    public interface IPagoDoc : HlpGestion.IGestion, HlpGestion.IAbandonar, HlpGestion.IProcesar
    {
        IHndData HndData { get; }
        Utils.Componente.CajaMonto.Vista.IHnd HndCaja { get; }
        MetodosPago.Principal.Vista.IMetPag HndMetPag { get; }

        void setDocumentoPagar(object doc);
        void ActualizarSaldoCaja();
    }
}

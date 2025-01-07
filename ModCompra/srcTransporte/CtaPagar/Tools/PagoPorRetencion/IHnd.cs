using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.PagoPorRetencion
{
    public interface IHnd: HlpGestion.IGestion
    {
        Utils.Control.Boton.Abandonar.IAbandonar BtAbandonar { get; }
        Utils.Control.Boton.Procesar.IProcesar BtProcesar { get; }
        //
        void setDocCompraAplicarPagoPorRet(string idDocCompra);
    }
}
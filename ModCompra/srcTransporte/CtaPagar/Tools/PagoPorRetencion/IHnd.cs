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
        bool PagoPorRetencionIsOK { get; }
        bool GetAplicarRetIva { get; }
        bool GetAplicarRetIslr { get; }
        //
        void setDocCompraAplicarPagoPorRet(string idDocCompra);
        void ProcesarPagoPorRetencion();
        void setRetIva();
        void setRetIslr();
        void setTasaRetIva(decimal tasa);
        void setTasaRetIslr(decimal tasa);
        void setSustraendo(decimal monto);
    }
}
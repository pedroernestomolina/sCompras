using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Retencion.Corrector.Vista
{
    public interface IVista: HlpGestion.IGestion
    {
        Utils.Control.Boton.Abandonar.IAbandonar BtAbandonar { get; }
        Utils.Control.Boton.Procesar.IProcesar  BtProcesar { get; }
        IVistaDoc Doc { get; }
        bool ProcesarIsOK { get; }
        //
        void setIdDocumento(string idDoc);
        void Procesar();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Interfaces.PanelAbonarPago
{
    public interface IPanel: HlpGestion.IGestion
    {
        bool MontoAbonarIsOk { get; }
        decimal GetMontoPendiente { get; }
        decimal GetMontoAbonar { get; }
        string GetDetalle { get; }
        //
        void setDetalle(string p);
        void setMontoAbonar(decimal rt);
        void setItemCargar(Modelos.GestionPagoDocumentos.IItemDesplegar item);
        void setMontoPorMetPagoRecibido(decimal monto);
        //
        bool ProcesarIsOK { get; }
        bool AbandonarIsOK { get; }
        void ProcesarFicha();
        void AbandonarFicha();
    }
}
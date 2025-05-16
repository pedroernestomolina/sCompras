using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Interfaces.PanelAbonarPago
{
    public interface IPanel: HlpGestion.IGestion
    {
        string GetTituloPanel { get; }
        //
        bool MontoAbonarIsOk { get; }
        decimal GetMontoPendiente { get; }
        decimal GetMontoAbonar { get; }
        string GetDetalle { get; }
        //
        void setDetalle(string p);
        void setMontoAbonar(decimal rt);
        //
        bool ProcesarIsOK { get; }
        bool AbandonarIsOK { get; }
        void ProcesarFicha();
        void AbandonarFicha();
    }
}
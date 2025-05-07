using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago.Interfaces
{
    public interface IPanelPrincipal: HlpGestion.IGestion
    {
        string GetInfoEntidad { get; }
        string GetTituloFrm { get; }
        bool IsPagoExitoso { get; }
        bool AbandonarFichaIsOk { get; }
        // PANEL METODOS/PAGO
        int GetCntMetRecibido { get; }
        decimal GetMontoRecibido { get; }
        //
        void setEntidadInfo(string info);
        void setEntidadId(string id);
        void AbandonarFicha();
    }
}
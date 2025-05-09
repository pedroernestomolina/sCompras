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
        //
        void setEntidadInfo(string info);
        void setEntidadId(string id);
        void AbandonarFicha();
        // PANEL METODOS/PAGO
        int GetCntMetRecibido { get; }
        decimal GetMontoRecibido { get; }
        void AgregarMetPago();
        void ListarMetPago();
        // PANEL DOCUMENTOS PENDIENTES
        int Get_DocSeleccionadosAPagar_Cnt { get; }
        decimal Get_DocSeleccionadosAPagar_Monto { get; }
        decimal Get_DocPendPorPagar_DeudaTotal { get; }
    }
}
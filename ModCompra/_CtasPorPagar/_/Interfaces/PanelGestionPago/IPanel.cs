using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Interfaces.PanelGestionPago
{
    public interface IPanel: HlpGestion.IGestion
    {
        string GetTituloFrm { get; }
        string GetInfoEntidad { get; }
        bool IsPagoExitoso { get; }
        bool AbandonarFichaIsOk { get; }
        //
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

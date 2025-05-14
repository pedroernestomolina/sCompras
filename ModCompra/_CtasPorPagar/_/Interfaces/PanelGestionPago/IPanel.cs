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

        //PANEL ANTICIPOS
        decimal Get_Anticipos_MontoAUsar { get; }
        decimal Get_Anticipos_MontoDisponible { get; }
        // PANEL METODOS/PAGO
        int GetCntMetRecibido { get; }
        decimal GetMontoRecibido { get; }
        void AgregarMetPago();
        void ListarMetPago();
        // PANEL POR DEUDA
        int  Get_DocSeleccionadosAPagar_PorDeuda_Cnt { get; }
        decimal Get_DocSeleccionadosAPagar_PorDeuda_Monto { get; }
        decimal Get_DocPorDeuda_MontoTotal { get; }
        // PANEL POR NC 
        int Get_DocSeleccionadosAPagar_PorNC_Cnt { get; }
        decimal Get_DocSeleccionadosAPagar_PorNC_Monto { get; }
        decimal Get_DocNC_MontoDisponible { get; }

        //
        void setItemCargar(__.Modelos.PanelPrincipal.IItemDesplegar GetItemActual);
        void ListarDocPend();
        void ListarNtCred();
        void AbandonarFicha();
    }
}
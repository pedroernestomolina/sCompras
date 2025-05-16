using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago
{
    abstract public class basePanel: __.Interfaces.PanelGestionPago.IPanel
    {
        private Utils.Control.Boton.Abandonar.IAbandonar _abandonar;
        //
        abstract public string GetInfoEntidad { get; }
        abstract public string GetTituloFrm { get; }
        abstract public bool IsPagoExitoso { get; }
        public bool AbandonarFichaIsOk { get { return _abandonar.OpcionIsOK; } }
        abstract public string Get_IdReciboPago_Procesado { get; }

        // PANEL ANTICIPOS
        abstract public decimal Get_Anticipos_MontoAUsar { get; }
        abstract public decimal Get_Anticipos_MontoDisponible { get; }

        // PANEL MET/PAGO
        abstract public int GetCntMetRecibido { get; }
        abstract public decimal GetMontoRecibido { get; }
        abstract public void AgregarMetPago();
        abstract public void ListarMetPago();

        //PANEL POR DEUDA
        abstract public int Get_DocSeleccionadosAPagar_PorDeuda_Cnt { get; }
        abstract public decimal Get_DocSeleccionadosAPagar_PorDeuda_Monto { get; }
        abstract public decimal Get_DocPorDeuda_MontoTotal { get; }

        //PANEL POR NC
        abstract public int Get_DocSeleccionadosAPagar_PorNC_Cnt { get; }
        abstract public decimal Get_DocSeleccionadosAPagar_PorNC_Monto { get; }
        abstract public decimal Get_DocNC_MontoDisponible { get; }

        //
        public basePanel()
        {
            _abandonar = new Utils.Control.Boton.Abandonar.Imp();
        }
        virtual public void Inicializa()
        {
            _abandonar.Inicializa();
        }
        abstract public void Inicia();
        abstract public void setItemCargar(__.Modelos.PanelPrincipal.IItemDesplegar GetItemActual);
        public void AbandonarFicha()
        {
            _abandonar.Opcion();
        }

        //
        abstract public void ListarDocPend();
        abstract public void ListarNtCred();
        abstract public void ProcesarPago();
    }
}
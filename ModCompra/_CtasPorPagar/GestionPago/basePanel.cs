using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago
{
    abstract public class basePanel: __.Interfaces.PanelGestionPago.IPanel
    {
        private string _idEntidad;
        private Utils.Control.Boton.Abandonar.IAbandonar _abandonar;
        private bool _isPagoExitoso;
        //
        abstract public string GetInfoEntidad { get; }
        abstract public string GetTituloFrm { get; }
        public bool IsPagoExitoso { get { return _isPagoExitoso; } }
        public bool AbandonarFichaIsOk { get { return _abandonar.OpcionIsOK; } }
        //
        public basePanel()
        {
            _isPagoExitoso = false;
            _abandonar = new Utils.Control.Boton.Abandonar.Imp();
        }
        virtual public void Inicializa()
        {
            _isPagoExitoso = false;
            _abandonar.Inicializa();
        }
        abstract public void Inicia();
        public void setEntidadId(string id)
        {
            _idEntidad = id;
        }
        public void AbandonarFicha()
        {
            _abandonar.Opcion();
        }

        // PANEL MET/PAGO
        abstract public int GetCntMetRecibido { get; }
        abstract public decimal GetMontoRecibido { get; }
        abstract public void AgregarMetPago();
        abstract public void ListarMetPago();

        // PANEL DOCUMENTOS PENDIENTES
        abstract public int Get_DocSeleccionadosAPagar_Cnt { get; }
        abstract public decimal Get_DocSeleccionadosAPagar_Monto { get; }
        abstract public decimal Get_DocPendPorPagar_DeudaTotal { get; }
    }
}
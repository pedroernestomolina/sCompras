using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.handlers
{
    public class hndPanel: basePanel, interfaces.IPanel
    {
        private __.Modelos.PanelPrincipal.IItemDesplegar _itemEntidad;
        private __.Modelos.GestionPago.IModelo _gPago;
        private __.Interfaces.PanelGestionPagoDocumentos.IPanel _panelDocDeuda;
        private __.Interfaces.PanelGestionPagoDocumentos.IPanel _panelDocNC;
        private __.Interfaces.PanelMetPagoAgregar.IPanelAgregarEditar _panelMetPagoAgregar;
        //
        private __.UsesCase.GestionPago.ICargarInfoEntidad _ucCargarInfoEntidad;
        private __.UsesCase.GestionPago.ICargarFactorCambio _ucFactorCambio;
        private __.UsesCase.GestionPago.ICargarMediosPago _ucCargarMediosPago;
        //

        public __.Modelos.GestionPago.IModelo GPago { get { return _gPago; } }
        public override string GetInfoEntidad { get { return _gPago.GetInfoEntidad; } }
        public override string GetTituloFrm { get { return "Gestión (Pago/Deuda):"; } }

        // PANEL ANTICIPOS
        public override decimal Get_Anticipos_MontoAUsar { get { return GPago.Get_Anticipos_MontoAUsar; } }
        public override decimal Get_Anticipos_MontoDisponible { get { return GPago.Get_Anticipos_MontoDisponible; } }

        // PANEL METODOS DE PAGO
        public override int GetCntMetRecibido { get { return GPago.GetCntMetRecibido; } }
        public override decimal GetMontoRecibido { get { return GPago.GetMontoRecibido; } }

        //PANEL POR DEUDA
        public override int Get_DocSeleccionadosAPagar_PorDeuda_Cnt { get { return GPago.Get_DocSeleccionadosAPagar_PorDeuda_Cnt; } }
        public override decimal Get_DocSeleccionadosAPagar_PorDeuda_Monto { get { return GPago.Get_DocSeleccionadosAPagar_PorDeuda_Monto; } }
        public override decimal Get_DocPorDeuda_MontoTotal { get { return GPago.Get_DocPorDeuda_MontoTotal; } }

        //PANEL POR NC
        public override int Get_DocSeleccionadosAPagar_PorNC_Cnt { get { return GPago.Get_DocSeleccionadosAPagar_PorNC_Cnt ; } }
        public override decimal Get_DocSeleccionadosAPagar_PorNC_Monto { get { return GPago.Get_DocSeleccionadosAPagar_PorNC_Monto; } }
        public override decimal Get_DocNC_MontoDisponible { get { return GPago.Get_DocNC_MontoDisponible; } }

        //
        public hndPanel()
            : base()
        {
            _itemEntidad = null;
            _gPago = new modelos.Modelo();
            _panelDocDeuda = new GestionPagoDocumentos.handlers.HndPanel();
            _panelDocNC = new GestionPagoDocumentos.handlers.HndPanel();
            _panelMetPagoAgregar = new PanelMetPagoAgregar.handlers.hndPanelAgregar();
            //
            _ucCargarInfoEntidad = new usesCase.uc_CargarInfoEntidad();
            _ucCargarMediosPago = new usesCase.uc_CargarMediosPago();
            _ucFactorCambio = new usesCase.uc_CargarFactorCambio();
        }
        public override void Inicializa()
        {
            _itemEntidad = null;
            _gPago.Inicializa();
            _panelDocDeuda.Inicializa();
            _panelDocNC.Inicializa();
            _panelMetPagoAgregar.Inicializa();
        }
        public override void setItemCargar(__.Modelos.PanelPrincipal.IItemDesplegar itemEntidad)
        {
            _itemEntidad = itemEntidad;
            //var it = (PanelPrincipal._Inicio.modelos.ItemDesplegar)itemEntidad;
            //_cargarEntidad.setIdEntidad(it.IdEntidad);
            //_gPago.setCargarEntidad(_cargarEntidad.Execute());
            ////
            //_panelDocDeuda.Inicializa();
            //_panelDocDeuda.setTituloPanel("Documentos Con Deudas Pendientes x Pagar");
            //_panelDocDeuda.setDataCargar(_gPago.GetInfoEntidad, _gPago.DocDeuda);
            ////
            //_panelDocNC.Inicializa();
            //_panelDocNC.setTituloPanel("Documentos Con Notas de Credito Pendientes x Usar");
            //_panelDocNC.setDataCargar(_gPago.GetInfoEntidad, _gPago.DocNC);
        }
        vistas.Frm frm;
        public override void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null) 
                {
                    frm = new vistas.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        //
        private bool cargarData()
        {
            try
            {
                var it = (PanelPrincipal._Inicio.modelos.ItemDesplegar)_itemEntidad;
                _gPago.setCargarEntidad(_ucCargarInfoEntidad.Execute(it.IdEntidad));
                _gPago.setFactorCambio(_ucFactorCambio.Execute());
                _gPago.setMediosPago(_ucCargarMediosPago.Execute());
                //
                _panelDocDeuda.Inicializa();
                _panelDocDeuda.setTituloPanel("Documentos Con Deudas Pendientes x Pagar");
                _panelDocDeuda.setDataCargar(_gPago.GetInfoEntidad, _gPago.DocDeuda);
                //
                _panelDocNC.Inicializa();
                _panelDocNC.setTituloPanel("Documentos Con Notas de Credito Pendientes x Usar");
                _panelDocNC.setDataCargar(_gPago.GetInfoEntidad, _gPago.DocNC);
                //
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        //
        public override void ListarDocPend()
        {
            _panelDocDeuda.Inicia();
            GPago.setCntDocDeudaAbonado(_panelDocDeuda.GetCntDocAbonado);
            GPago.setMontoDocDeudaAbonar(_panelDocDeuda.GetMontoAbonado);
        }
        public override void ListarNtCred()
        {
            _panelDocNC.Inicia();
            GPago.setCntDocNCAbonado(_panelDocNC.GetCntDocAbonado);
            GPago.setMontoDocNCAbonar(_panelDocNC.GetMontoAbonado);
        }
        public override void AgregarMetPago()
        {
            _panelMetPagoAgregar.Inicializa();
            _panelMetPagoAgregar.CargarFactorCambio(_gPago.GetFactorCambio);
            _panelMetPagoAgregar.CargarMediosPago(_gPago.GetMediosPago);
            _panelMetPagoAgregar.Inicia();
        }
        public override void ListarMetPago()
        {
        }
    }
}
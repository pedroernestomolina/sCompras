using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.handlers
{
    public class hndPanel: basePanel, interfaces.IPanel
    {
        private bool _esPagoExitoso;
        private __.Modelos.PanelPrincipal.IItemDesplegar _itemEntidad;
        private __.Modelos.GestionPago.IModelo _gPago;
        private __.Interfaces.PanelGestionPagoDocumentos.IPanel _panelDocDeuda;
        private __.Interfaces.PanelGestionPagoDocumentos.IPanel _panelDocNC;
        private _CtasPorPagar.PanelAbonarPago.interfaces.IPanelPorMonto _panelPagoPorMonto;
        private _CtasPorPagar.PanelMetPagoAgregar.interfaces.IPanelAgregar _panelMetPagoAgregar;
        private _CtasPorPagar.PanelMetPagoAgregar.interfaces.IPanelEditar _panelMetPagoEditar;
        private _CtasPorPagar.PanelMetPagoLista.interfaces.IPanel _panelMetPagoListar;
        private Utils.Control.Boton.Procesar.IProcesar _procesar;
        private string _idReciboPagoProcesado;
        //
        private __.UsesCase.GestionPago.ICargarInfoEntidad _ucCargarInfoEntidad;
        private __.UsesCase.GestionPago.ICargarFactorCambio _ucFactorCambio;
        private __.UsesCase.GestionPago.ICargarMediosPago _ucCargarMediosPago;
        private __.UsesCase.GestionPago.IProcesarPago _ucProcesarPago;
        private __.UsesCase.GestionPago.IVisualizarReciboPago _ucVisualizarReciboPago;
        //
        private __.ReglasNegocio.GestionPago.IVerifica_SaldoPendienteMayorAMontoEstablecido _rgVerificarSaldoMayorAMontoEstablecido;
        private __.ReglasNegocio.GestionPago.IVerificaPago_ConNotasCredito _rgVerificaPago_ConNotasCredito;
        private __.ReglasNegocio.GestionPago.IVerificaPago_ConMetodosPago _rgVerificaPago_ConMetodosPago;
        private __.ReglasNegocio.GestionPago.IVerificaPago_ConAnticipos _rgVerificaPago_ConAnticipos;
        //

        public override bool IsPagoExitoso { get { return _esPagoExitoso; } }
        public __.Modelos.GestionPago.IModelo GPago { get { return _gPago; } }
        public override string GetInfoEntidad { get { return _gPago.GetInfoEntidad; } }
        public override string GetTituloFrm { get { return "Gestión (Pago/Deuda):"; } }
        public override string Get_IdReciboPago_Procesado { get { return _idReciboPagoProcesado; } }

        // PANEL ANTICIPOS
        public override decimal Get_Anticipos_MontoAUsar { get { return GPago.Get_Anticipos_MontoAUsar; } }
        public override decimal Get_Anticipos_MontoDisponible { get { return GPago.Get_Anticipos_MontoDisponible; } }

        // PANEL METODOS DE PAGO
        public override int GetCntMetRecibido { get { return GPago.GetCntMetPagoRecibido; } }
        public override decimal GetMontoRecibido { get { return GPago.GetMontoPorMetPagoRecibido; } }

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
            _idReciboPagoProcesado = "";
            _esPagoExitoso = false;
            _itemEntidad = null;
            _gPago = new modelos.Modelo();
            _panelDocDeuda = new GestionPagoDocumentos.handlers.HndPanel();
            _panelDocNC = new GestionPagoDocumentos.handlers.HndPanel();
            _panelMetPagoAgregar = new PanelMetPagoAgregar.handlers.hndPanelAgregar();
            _panelMetPagoEditar = new PanelMetPagoAgregar.handlers.hndPanelEditar();
            _panelMetPagoListar = new PanelMetPagoLista.handlers.hndPanel();
            _panelPagoPorMonto = new PanelAbonarPago.handlers.hndPanelPorMonto();
            _procesar = new Utils.Control.Boton.Procesar.Imp();
            //
            _ucCargarInfoEntidad = new usesCase.uc_CargarInfoEntidad();
            _ucCargarMediosPago = new usesCase.uc_CargarMediosPago();
            _ucFactorCambio = new usesCase.uc_CargarFactorCambio();
            _ucProcesarPago = new usesCase.uc_ProcesarPago();
            _ucVisualizarReciboPago = new usesCase.uc_VisualizarReciboPago();
            //
            _rgVerificarSaldoMayorAMontoEstablecido = new reglasNegocio.rg_VerificarSaldoPendienteMayorAMontoEstablecido();
            _rgVerificaPago_ConNotasCredito = new reglasNegocio.rg_VerificaPago_ConNotasCredito();
            _rgVerificaPago_ConMetodosPago = new reglasNegocio.rg_VerificaPago_ConMetodosPago();
            _rgVerificaPago_ConAnticipos = new reglasNegocio.rg_VerificaPagoConAnticipos();
        }
        public override void Inicializa()
        {
            base.Inicializa();
            _idReciboPagoProcesado = "";
            _esPagoExitoso = false;
            _itemEntidad = null;
            _gPago.Inicializa();
            _panelDocDeuda.Inicializa();
            _panelDocNC.Inicializa();
            _panelMetPagoAgregar.Inicializa();
            _panelMetPagoAgregar.Inicializa();
            _panelMetPagoEditar.Inicializa();
            _panelMetPagoListar.Inicializa();
            _panelPagoPorMonto.Inicializa();
            _procesar.Inicializa();
        }
        public override void setItemCargar(__.Modelos.PanelPrincipal.IItemDesplegar itemEntidad)
        {
            _itemEntidad = itemEntidad;
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
                _panelMetPagoAgregar.Inicializa();
                _panelMetPagoEditar.Inicializa();
                _panelMetPagoEditar.CargarMediosPago(_gPago.GetMediosPago);
                _panelMetPagoListar.Inicializa();
                //
                _panelMetPagoListar.setHndEditarMetodoPago(_panelMetPagoEditar);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        //
        public override void AgregarAnticipo()
        {
            _panelPagoPorMonto.Inicializa();
            _panelPagoPorMonto.setMontoDisponible(_gPago.Get_Anticipos_MontoDisponible);
            _panelPagoPorMonto.setMontoAbonar(_gPago.Get_Anticipos_MontoAUsar);
            _panelPagoPorMonto.Inicia();
            if (_panelPagoPorMonto.ProcesarIsOK) 
            {
                _gPago.setMontoUsarPorAnticipo(_panelPagoPorMonto.GetMontoAbonar);
            }
        }
        public override void ListarDocPend()
        {
            var monto = _gPago.GetMontoPorMetPagoRecibido +
                _gPago.Get_DocSeleccionadosAPagar_PorNC_Monto +
                _gPago.Get_Anticipos_MontoAUsar;
            _panelDocDeuda.setMontoAbonadoPorMetPago(Math.Round(monto, 3, MidpointRounding.AwayFromZero));
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
            if (_panelMetPagoAgregar.ProcesarIsOK)
            {
                var rt = _panelMetPagoAgregar.ItemAgregar;
                _gPago.AgregarMetodoPago(rt);
            }
        }
        public override void ListarMetPago()
        {
            _panelMetPagoListar.Inicializa();
            _panelMetPagoListar.CargarMetodosPagoRegistrados(_gPago.MetodosPago);
            _panelMetPagoListar.Inicia();
            _gPago.CargarMetodosPago(_panelMetPagoListar.GetListaItems);
        }
        public override void ProcesarPago()
        {
            _esPagoExitoso = false;
            try
            {
                //VALIDAR 
                if (!_rgVerificaPago_ConAnticipos.Execute(_gPago))
                {
                    throw new Exception(_rgVerificaPago_ConAnticipos.MensajeAlerta);
                }
                if (!_rgVerificaPago_ConMetodosPago.Execute(_gPago))
                {
                    throw new Exception(_rgVerificaPago_ConMetodosPago.MensajeAlerta);
                }
                if (!_rgVerificaPago_ConNotasCredito.Execute(_gPago))
                {
                    throw new Exception(_rgVerificaPago_ConNotasCredito.MensajeAlerta);
                }
                _rgVerificarSaldoMayorAMontoEstablecido.setMontoEstablecido(0.001m);
                if (!_rgVerificarSaldoMayorAMontoEstablecido.Execute(_gPago))
                {
                    throw new Exception(_rgVerificarSaldoMayorAMontoEstablecido.MensajeAlerta);
                }

                //PROCESAR PAGO
                _procesar.Opcion();
                if (_procesar.OpcionIsOK)
                {
                    _idReciboPagoProcesado = _ucProcesarPago.Execute(
                        GPago,
                        _panelDocDeuda.Get_DocSeleccionadosConPago,
                        _panelDocNC.Get_DocSeleccionadosConPago
                        );
                    _esPagoExitoso = true;
                    //
                    _ucVisualizarReciboPago.Execute(_idReciboPagoProcesado);
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Alerta(e.Message);
                return;
            }
        }
    }
}
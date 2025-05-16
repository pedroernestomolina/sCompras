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
            _procesar = new Utils.Control.Boton.Procesar.Imp();
            //
            _ucCargarInfoEntidad = new usesCase.uc_CargarInfoEntidad();
            _ucCargarMediosPago = new usesCase.uc_CargarMediosPago();
            _ucFactorCambio = new usesCase.uc_CargarFactorCambio();
            _ucProcesarPago = new usesCase.uc_ProcesarPago();
            _ucVisualizarReciboPago = new usesCase.uc_VisualizarReciboPago();
            //
            _rgVerificarSaldoMayorAMontoEstablecido = new reglasNegocio.rg_VerificarSaldoPendienteMayorAMontoEstablecido();
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
                _rgVerificarSaldoMayorAMontoEstablecido.setMontoEstablecido(0.001m);
                if (_rgVerificarSaldoMayorAMontoEstablecido.Execute(_gPago))
                {
                    throw new Exception(_rgVerificarSaldoMayorAMontoEstablecido.MensajeAlerta);
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Alerta(e.Message);
                return;
            }


            if (GPago.SaldoFinal < 0m) 
            {
                Helpers.Msg.Alerta("HAY UN FALTANTE, Verifique Por Favor");
                return;
            }
            //if (GPago.Get_DocSeleccionadosAPagar_PorNC_Monto >0m )
            //{
            //    if (GPago.Get_DocSeleccionadosAPagar_PorDeuda_Monto > 0m)
            //    {
            //        Helpers.Msg.Alerta("DEBES SELECCIONAR UN DOCUMENTO");
            //        return;
            //    }
            //    if (
            //        (GPago.Get_Anticipos_MontoAUsar + GPago.GetMontoPorMetPagoRecibido)
            //        >= GPago.Get_DocSeleccionadosAPagar_PorDeuda_Monto
            //       )
            //    {
            //        Helpers.Msg.Alerta("MONTO POR NOTAS DE CREDITO SIN USO");
            //        return;
            //    }
            //    if (
            //        GPago.Get_DocSeleccionadosAPagar_PorNC_Monto 
            //        > GPago.Get_DocSeleccionadosAPagar_PorDeuda_Monto
            //       )
            //    {
            //        Helpers.Msg.Alerta("MONTO POR NOTAS DE CREDITO SIN USO");
            //        return;
            //    }
            //}
            _procesar.Opcion();
            if (_procesar.OpcionIsOK)
            {
                _esPagoExitoso = false;
                try
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
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
    }
}
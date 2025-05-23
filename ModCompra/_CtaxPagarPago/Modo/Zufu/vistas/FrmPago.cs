﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtaxPagarPago.Modo.Zufu.vistas
{
    public partial class FrmPago : Form
    {
        private Interfaces.IZufuPanelPrincipal _controlador;
        //
        public FrmPago()
        {
            InitializeComponent();
        }
        private void FrmPago_Load(object sender, EventArgs e)
        {
            L_TITULO.Text = _controlador.GetTituloFrm;
            L_ENTIDAD.Text =_controlador.GetInfoEntidad;
            //L_CLIENTE.Text = _controlador.GetCliente;
            //ActualizarPanelAnticipo();
            ActualizarPanelMet();
            ActualizarPanelDocPend();
            //ActualizarPanelNtCred();
            //ActualizarPanelResumen();
        }
        private void FrmPago_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarFichaIsOk || _controlador.IsPagoExitoso)
            {
                //_controlador.LimpiarData();
                e.Cancel = false;
            }
        }
        public void setControlador(Interfaces.IZufuPanelPrincipal ctr)
        {
            _controlador = ctr;
        }
        //PANEL: METODOS 
        private void BT_AGREGAR_Click(object sender, EventArgs e)
        {
            AgregarMetPago();
        }
        private void BT_LISTAR_Click(object sender, EventArgs e)
        {
            ListarMetPago();
        }
        //PANEL: CTAS 
        private void BT_LISTAR_CTAS_PAGAR_Click(object sender, EventArgs e)
        {
            ListarCtasPagar();
        }
        //PANEL: NOTAS/CREDITO 
        private void BT_LISTAR_NT_CRED_Click(object sender, EventArgs e)
        {
            ListarNtCred();
        }
        //PANEL: ANTICIPO
        private void BT_ANTICIPO_Click(object sender, EventArgs e)
        {
            AgregarAnticipo();
        }
        //
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            BtProcesar();
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            BtAbandonar();
        }
        //
        private void AgregarMetPago()
        {
            _controlador.AgregarMetPago();
            ActualizarPanelMet();
        }
        private void ListarMetPago()
        {
            _controlador.ListarMetPago();
            ActualizarPanelMet();
        }
        private void ListarCtasPagar()
        {
            //_controlador.ListarCtasPagar();
            //ActualizarPanelCtas();
        }
        private void ListarNtCred()
        {
            //_controlador.ListarNtCred();
            //ActualizarPanelNtCred();
        }
        private void AgregarAnticipo()
        {
            //_controlador.AgregarAnticipo();
            //ActualizarPanelAnticipo();
        }
        private void BtProcesar()
        {
            //_controlador.ProcesarPago();
            //if (_controlador.IsPagoExitoso) 
            //{
            //    var _autoRecibo =_controlador.GetAutoReciboGenerar;
            //    _controlador.GenerarRecibo(_autoRecibo);
            //    salir();
            //}
        }
        private void BtAbandonar()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarFichaIsOk)
            {
                salir();
            }
        }
        //
        private void salir()
        {
            Close();
        }
        private void ActualizarPanelAnticipo() 
        {
            //L_MONTO_ANTICIPO.Text = _controlador.GetMontoAnticipo.ToString("n2");
            //L_ANTICIPO_DISPONIBLE.Text = _controlador.GetMontoAnticipoDisponible.ToString("n2");
            //ActualizarPanelResumen();
        }
        private void ActualizarPanelMet()
        {
            L_MET_CNT.Text = _controlador.GetCntMetRecibido.ToString("n0");
            L_MONTO_RECIBIDO.Text = _controlador.GetMontoRecibido.ToString("n2");
            //ActualizarPanelResumen();
        }
        private void ActualizarPanelDocPend()
        {
            L_CNT_CTAS_PAGAR.Text = _controlador.Get_DocSeleccionadosAPagar_Cnt.ToString();
            L_MONTO_PAGAR.Text = _controlador.Get_DocSeleccionadosAPagar_Monto.ToString("n2");
            L_SALDO_PEND_PAGAR.Text = _controlador.Get_DocPendPorPagar_DeudaTotal.ToString("n2");
            //ActualizarPanelResumen();
        }
        private void ActualizarPanelNtCred()
        {
            //L_CNT_NT_CRED.Text = _controlador.GetCntNtCred.ToString();
            //L_MONTO_NT_CRED.Text = _controlador.GetMontoNtCred.ToString("n2");
            //L_NTCRED_DISPONIBLE.Text = _controlador.GetMontoNtCredDisponible.ToString("n2");
            //ActualizarPanelResumen();
        }
        private void ActualizarPanelResumen()
        {
            //L_RESUMEN_ANTICIPO.Text = _controlador.GetResumenMontoAnticipo.ToString("n2");
            //L_RESUMEN_MET_PAGO.Text = _controlador.GetResumenMontoMetPago.ToString("n2");
            //L_RESUMEN_NT_CRED.Text = _controlador.GetResumenMontoNtCredito.ToString("n2");
            //L_RESUMEN_ABONO.Text = _controlador.GetResumenMontoAbono.ToString("n2");
            //L_RESUMEN_CTAS.Text = _controlador.GetResumenMontoCtasPend.ToString("n2");
            //L_RESUMEN_SALDO.Text = Math.Abs(_controlador.GetResumenSaldo).ToString("n2");
            //L_RESUMEN_DES_SALDO.Text = _controlador.GetResumenSaldoDesc;
        }
    }
}

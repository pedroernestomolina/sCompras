using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.Tools.MetodosPago.CompAgregarEditarMet.Vista
{
    public partial class Frm : Form
    {
        private IAgregarEditar _controlador;


        private void InicializaCombo()
        {
            CB_METODO_PAGO.ValueMember = "id";
            CB_METODO_PAGO.DisplayMember = "desc";
        }
        public Frm()
        {
            InitializeComponent();
            InicializaCombo();
        }
        public void setControlador(IAgregarEditar ctr)
        {
            _controlador = ctr;
        }
        private bool _modoInicializa;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            L_TITULO.Text = _controlador.Get_TituloFicha;
            L_RESTA.Text = _controlador.HndData.Get_MontoResta.ToString("n2");
            CB_METODO_PAGO.DataSource = _controlador.HndData.MedioPago.GetSource ;
            CB_METODO_PAGO.SelectedValue = _controlador.HndData.MedioPago.GetId;
            TB_MONTO.Text = _controlador.HndData.Get_Monto.ToString();
            CHB_APLICA_FACTOR.Checked = _controlador.HndData.Get_AplicaFactor;
            TB_FACTOR_CAMBIO.Text = _controlador.HndData.Get_Factor.ToString();
            TB_BANCO.Text = _controlador.HndData.Get_Banco;
            TB_NUM_CTA.Text = _controlador.HndData.Get_NroCta;
            TB_NUM_CGEQ_REF.Text = _controlador.HndData.Get_CheqRefTrans;
            DTP_FECHA_OPERACION.Value = _controlador.HndData.Get_FechaOp;
            TB_DETALLE_OPERACION.Text = _controlador.HndData.Get_DetalleOp;
            TB_REF.Text = _controlador.HndData.Get_Referencia;
            TB_LOTE.Text = _controlador.HndData.Get_Lote;
            CHB_APLICA_MOV_CAJA.Checked = _controlador.HndData.Get_AplicaMovCaja;
            _modoInicializa = false;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK || _controlador.ProcesarIsOK)
            {
                e.Cancel = false;
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void CB_METODO_PAGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            _controlador.HndData.MedioPago.setFichaById ("");
            if (CB_METODO_PAGO.SelectedIndex != -1)
            {
                _controlador.HndData.MedioPago.setFichaById(CB_METODO_PAGO.SelectedValue.ToString());
            }
        }
        private void TB_MONTO_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_MONTO.Text);
            _controlador.HndData.setMonto(_monto);
        }
        private void TB_MONTO_Validating(object sender, CancelEventArgs e)
        {
        }
        private void TB_FACTOR_CAMBIO_Leave(object sender, EventArgs e)
        {
            var _factor = decimal.Parse(TB_FACTOR_CAMBIO.Text);
            _controlador.HndData.setFactor(_factor);
        }
        private void TB_FACTOR_CAMBIO_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.HndData.Get_Factor <= 0m;
        }
        private void TB_BANCO_Leave(object sender, EventArgs e)
        {
            _controlador.HndData.setBanco(TB_BANCO.Text.Trim().ToUpper());
        }
        private void TB_NUM_CTA_Leave(object sender, EventArgs e)
        {
            _controlador.HndData.setCtaNro(TB_NUM_CTA.Text.Trim().ToUpper());
        }
        private void TB_NUM_CGEQ_REF_Leave(object sender, EventArgs e)
        {
            _controlador.HndData.setChequeRefTranf(TB_NUM_CGEQ_REF.Text.Trim().ToUpper());
        }
        private void TB_LOTE_Leave(object sender, EventArgs e)
        {
            _controlador.HndData.setLote(TB_LOTE.Text.Trim().ToUpper());
        }
        private void TB_REF_Leave(object sender, EventArgs e)
        {
            _controlador.HndData.setReferencia(TB_REF.Text.Trim().ToUpper());
        }
        private void DTP_FECHA_OPERACION_Leave(object sender, EventArgs e)
        {
            _controlador.HndData.setFechaOperacion(DTP_FECHA_OPERACION.Value);
        }
        private void DTP_FECHA_OPERACION_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.HndData.Get_FechaOp > _controlador.Get_FechaServidor;
        }
        private void TB_DETALLE_OPERACION_Leave(object sender, EventArgs e)
        {
            _controlador.HndData.setDetalleOperacion(TB_DETALLE_OPERACION.Text);
        }
        private void CHB_APLICA_FACTOR_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.HndData.setAplicaFactor(CHB_APLICA_FACTOR.Checked);
        }
        private void CHB_APLICA_MOV_CAJA_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.HndData.setAplicaMovCaja(CHB_APLICA_MOV_CAJA.Checked);
        }


        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }


        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOK)
            {
                Salir();
            }
        }
        private void Abandonar()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOK)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
    }
}
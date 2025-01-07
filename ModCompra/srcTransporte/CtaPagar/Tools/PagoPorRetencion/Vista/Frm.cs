using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModCompra.srcTransporte.CtaPagar.Tools.PagoPorRetencion.Vista
{
    public partial class Frm : Form
    {
        private PagoPorRetencion.IHnd _controlador;
        //
        public Frm()
        {
            InitializeComponent();
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            CHB_RET_IVA.Focus();
            CHB_RET_IVA.Checked = _controlador.GetAplicarRetIva;
            CHB_RET_ISLR.Checked = _controlador.GetAplicarRetIslr;
            TB_SUSTRAENDO.Text = "0";
            TB_TASA_RET_IVA.Text = "0";
            TB_TASA_RET_ISLR.Text = "0";
            TB_TASA_RET_IVA.Enabled = _controlador.GetAplicarRetIva;
            TB_TASA_RET_ISLR.Enabled = _controlador.GetAplicarRetIslr;
            TB_SUSTRAENDO.Enabled = _controlador.GetAplicarRetIslr;
            this.Refresh();
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.BtAbandonar.OpcionIsOK || _controlador.PagoPorRetencionIsOK) 
            {
                e.Cancel = false;
            }
        }
        public void setControlador(ImpHnd ctr)
        {
            _controlador = ctr;
        }
        private void CHB_RET_IVA_Leave(object sender, EventArgs e)
        {
            TB_TASA_RET_IVA.Enabled = _controlador.GetAplicarRetIva;
            this.Refresh();
        }
        private void CHB_RET_IVA_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setRetIva();
            TB_TASA_RET_IVA.Enabled = _controlador.GetAplicarRetIva;
            this.Refresh();
        }
        private void TB_TASA_RET_IVA_Leave(object sender, EventArgs e)
        {
            var _tasa = decimal.Parse(TB_TASA_RET_IVA.Text);
            _controlador.setTasaRetIva(_tasa);
        }
        private void CHB_RET_ISLR_Leave(object sender, EventArgs e)
        {
            TB_TASA_RET_ISLR.Enabled = _controlador.GetAplicarRetIslr;
            TB_SUSTRAENDO.Enabled = _controlador.GetAplicarRetIslr;
            this.Refresh();
        }
        private void CHB_RET_ISLR_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setRetIslr();
            TB_TASA_RET_ISLR.Enabled = _controlador.GetAplicarRetIslr;
            TB_SUSTRAENDO.Enabled = _controlador.GetAplicarRetIslr;
            this.Refresh();
        }
        private void TB_TASA_RET_ISLR_Leave(object sender, EventArgs e)
        {
            var _tasa = decimal.Parse(TB_TASA_RET_ISLR.Text);
            _controlador.setTasaRetIslr(_tasa);
        }
        private void TB_SUSTRAENDO_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_SUSTRAENDO.Text);
            _controlador.setSustraendo(_monto);
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            CHB_RET_IVA.Focus();
            Abandonar();
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            CHB_RET_IVA.Focus();
            Procesar();
        }
        //
        private void Abandonar()
        {
            _controlador.BtAbandonar.Opcion();
            if (_controlador.BtAbandonar.OpcionIsOK) 
            {
                salida();
            }
        }
        private void Procesar()
        {
            _controlador.ProcesarPagoPorRetencion();
            if (_controlador.BtProcesar.OpcionIsOK)
            {
                salida();
            }
        }
        private void salida()
        {
            this.Close();
        }

        private void Ctrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TB_TASA_RET_IVA_Validating(object sender, CancelEventArgs e)
        {
            var _tasa = decimal.Parse(TB_TASA_RET_IVA.Text);
            if (_tasa > 100)
                e.Cancel = true;
        }
        private void TB_TASA_RET_ISLR_Validating(object sender, CancelEventArgs e)
        {
            var _tasa = decimal.Parse(TB_TASA_RET_ISLR.Text);
            if (_tasa > 100)
                e.Cancel = true;
        }
    }
}

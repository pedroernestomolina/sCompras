using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.Caja.Movimiento.Agregar.Vistas
{
    public partial class Frm : Form
    {
        private Vistas.IMov _controlador;
        private CultureInfo _cult;


        public Frm()
        {
            InitializeComponent();
            InicializaCB();
            _cult= CultureInfo.CurrentCulture;
        }
        private void InicializaCB()
        {
            CB_CAJA.DisplayMember = "desc";
            CB_CAJA.ValueMember = "id";
            CB_TIPO_MOV.DisplayMember = "desc";
            CB_TIPO_MOV.ValueMember = "id";
            CB_CONCEPTO.DisplayMember = "desc";
            CB_CONCEPTO.ValueMember = "id";
        }

        private bool _modoInicializa;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            var _bsCaja = _controlador.Hnd.Get_Caja_Source;
            CB_CAJA.DataSource = _bsCaja;
            _bsCaja.CurrentChanged += _bsCaja_CurrentChanged;
            CB_CAJA.SelectedValue= _controlador.Hnd.Get_CajaID;
            CB_TIPO_MOV.DataSource = _controlador.Hnd.Get_TipoMov_Source;
            CB_TIPO_MOV.SelectedValue= _controlador.Hnd.Get_TipoMovId;
            CB_CONCEPTO.DataSource = _controlador.Hnd.Concepto.GetSource;
            CB_CONCEPTO.SelectedValue = _controlador.Hnd.Concepto.GetId;
            DTP_FECHA_MOV.Value = _controlador.Hnd.Get_FechaServidor;
            TB_MONTO_MOV.Text = _controlador.Hnd.Get_MontoMov.ToString("n2",_cult);
            TB_FACTOR_CAMBIO.Text = _controlador.Hnd.Get_FactorCambio.ToString("n2", _cult);
            TB_NOTAS.Text = _controlador.Hnd.Get_Notas;
            L_CAJA_ACTUAL_INFO.Text = _controlador.Hnd.Get_CajaInfo;
            _modoInicializa = false;
            CB_CAJA.SelectedIndex = -1;
        }
        private void _bsCaja_CurrentChanged(object sender, EventArgs e)
        {
            L_CAJA_ACTUAL_INFO.Text = _controlador.Hnd.Get_CajaInfo;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK || _controlador.ProcesarIsOK)
            {
                e.Cancel = false;
            }
        }
        private void CTRL_KEYDOWN(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        public void setControlador(Vistas.IMov ctr)
        {
            _controlador = ctr;
        }


        private void CB_CAJA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.Hnd.setCajaById("");
            if (CB_CAJA.SelectedIndex != -1)
            {
                _controlador.Hnd.setCajaById(CB_CAJA.SelectedValue.ToString());
            }
        }
        private void CB_TIPO_MOV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.Hnd.setTipoMovById("");
            if (CB_CAJA.SelectedIndex != -1)
            {
                _controlador.Hnd.setTipoMovById(CB_TIPO_MOV.SelectedValue.ToString());
            }
        }
        private void CB_CONCEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.Hnd.Concepto.setFichaById("");
            if (CB_CAJA.SelectedIndex != -1)
            {
                _controlador.Hnd.Concepto.setFichaById(CB_CONCEPTO.SelectedValue.ToString());
            }
        }
        private void TB_MONTO_MOV_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_MONTO_MOV.Text);
            _controlador.Hnd.setMontoMov(_monto);
            TB_MONTO_MOV.Text = _controlador.Hnd.Get_MontoMov.ToString("n2", _cult);
        }
        private void TB_FACTOR_CAMBIO_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_FACTOR_CAMBIO.Text);
            _controlador.Hnd.setFactorCambio(_monto);
            TB_FACTOR_CAMBIO.Text = _controlador.Hnd.Get_FactorCambio.ToString("n2", _cult);
        }
        private void TB_NOTAS_Leave(object sender, EventArgs e)
        {
            _controlador.Hnd.setNotas(TB_NOTAS.Text.Trim().ToUpper());
            TB_NOTAS.Text = _controlador.Hnd.Get_Notas;
        }
        private void TB_CONCEPTO_BUSCAR_TextChanged(object sender, EventArgs e)
        {
            _controlador.Hnd.Concepto.setTextoBuscar(TB_CONCEPTO_BUSCAR.Text);
            CB_CONCEPTO.Refresh();
        }
        private void TB_FACTOR_CAMBIO_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.Hnd.Get_FactorCambio <= 0m;
        }
        private void TB_MONTO_MOV_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.Hnd.Get_MontoMov <= 0m;
        }


        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            ProcesarFicha();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void ProcesarFicha()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOK)
            {
                salir();
            }
        }
        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOK)
            {
                salir();
            }
        }
        private void salir()
        {
            this.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModCompra.srcTransporte.Reportes.RepFiltro.Vista
{
    public partial class Frm : Form
    {
        private Vista.IHnd _controlador;


        private void InicializaCB()
        {
            CB_TIPO_MOV_CAJA.DisplayMember = "desc";
            CB_TIPO_MOV_CAJA.ValueMember = "id";
            CB_ESTATUS.DisplayMember = "desc";
            CB_ESTATUS.ValueMember = "id";
            CB_ALIADO.DisplayMember = "desc";
            CB_ALIADO.ValueMember = "id";
            CB_PROVEEDOR.DisplayMember = "desc";
            CB_PROVEEDOR.ValueMember = "id";
            CB_CAJA.DisplayMember = "desc";
            CB_CAJA.ValueMember = "id";
            CB_CONCEPTO.DisplayMember = "desc";
            CB_CONCEPTO.ValueMember = "id";
            CB_BENEFICIARIO.DisplayMember = "desc";
            CB_BENEFICIARIO.ValueMember = "id";
        }
        public Frm()
        {
            InitializeComponent();
            InicializaCB();
        }
        private bool _modoInicializar = false;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;

            //
            CB_TIPO_MOV_CAJA.DataSource = _controlador.TipoMovCaja.GetSource;
            CB_ESTATUS.DataSource = _controlador.Estatus.GetSource;
            CB_ALIADO.DataSource = _controlador.Aliado.GetSource ;
            CB_PROVEEDOR.DataSource = _controlador.Proveedor.GetSource;
            CB_CAJA.DataSource = _controlador.Caja.GetSource;
            CB_CONCEPTO.DataSource = _controlador.Concepto.GetSource;
            CB_BENEFICIARIO.DataSource = _controlador.Beneficiario.GetSource;

            //
            TB_ALIADO.Text = _controlador.Aliado.Get_TextoBuscar;
            TB_PROVEEDOR.Text = _controlador.Proveedor.Get_TextoBuscar;
            TB_CAJA.Text = _controlador.Caja.Get_TextoBuscar;
            TB_CONCEPTO.Text = _controlador.Concepto.Get_TextoBuscar;
            TB_BENEFICIARIO.Text = _controlador.Beneficiario.Get_TextoBuscar;

            //
            CB_TIPO_MOV_CAJA.SelectedValue = _controlador.TipoMovCaja.GetId;
            CB_ESTATUS.SelectedValue = _controlador.Estatus.GetId;
            CB_ALIADO.SelectedValue = _controlador.Aliado.GetId;
            CB_PROVEEDOR.SelectedValue = _controlador.Proveedor.GetId;
            CB_CAJA.SelectedValue = _controlador.Caja.GetId;
            CB_CONCEPTO.SelectedValue = _controlador.Concepto.GetId;
            CB_BENEFICIARIO.SelectedValue = _controlador.Beneficiario.GetId;

            //
            CB_TIPO_MOV_CAJA.Enabled = _controlador.FiltroActivar.TipoMovCaja;
            CB_ESTATUS.Enabled = _controlador.FiltroActivar.Estatus;

            //
            TB_ALIADO.Enabled = _controlador.FiltroActivar.Aliado;
            TB_PROVEEDOR.Enabled = _controlador.FiltroActivar.Proveedor;
            TB_CAJA.Enabled = _controlador.FiltroActivar.Caja;
            TB_CONCEPTO.Enabled = _controlador.FiltroActivar.Concepto;
            TB_BENEFICIARIO.Enabled = _controlador.FiltroActivar.Beneficiario;

            //
            CB_ALIADO.Enabled = _controlador.FiltroActivar.Aliado;
            CB_PROVEEDOR.Enabled = _controlador.FiltroActivar.Proveedor;
            CB_CAJA.Enabled = _controlador.FiltroActivar.Caja;
            CB_CONCEPTO.Enabled = _controlador.FiltroActivar.Concepto;
            CB_BENEFICIARIO.Enabled = _controlador.FiltroActivar.Beneficiario;

            //
            DTP_DESDE.Value = _controlador.Desde.Fecha;
            DTP_HASTA.Value = _controlador.Hasta.Fecha;
            DTP_DESDE.ShowCheckBox = _controlador.Desde.Get_ActivarCheck;
            DTP_HASTA.ShowCheckBox = _controlador.Hasta.Get_ActivarCheck;

            _modoInicializar = false;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK || _controlador.ProcesarIsOK) 
            {
                e.Cancel = false;
            }
        }
        private void CTR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        public void setControlador(Vista.IHnd ctr)
        {
            _controlador = ctr;
        }


        private void TB_ALIADO_Leave(object sender, EventArgs e)
        {
            _controlador.Aliado.setTextoBuscar(TB_ALIADO.Text.Trim().ToUpper());
        }
        private void TB_PROVEEDOR_Leave(object sender, EventArgs e)
        {
            _controlador.Proveedor.setTextoBuscar(TB_PROVEEDOR.Text.Trim().ToUpper());
        }
        private void TB_CAJA_Leave(object sender, EventArgs e)
        {
            _controlador.Caja.setTextoBuscar(TB_CAJA.Text.Trim().ToUpper());
        }
        private void TB_CONCEPTO_Leave(object sender, EventArgs e)
        {
            _controlador.Concepto.setTextoBuscar(TB_CONCEPTO.Text.Trim().ToUpper());
        }
        private void TB_BENEFICIARIO_Leave(object sender, EventArgs e)
        {
            _controlador.Beneficiario.setTextoBuscar(TB_BENEFICIARIO.Text.Trim().ToUpper());
        }


        private void CB_TIPO_MOV_CAJA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.TipoMovCaja.setFichaById("");
            if (CB_TIPO_MOV_CAJA.SelectedIndex != -1)
            {
                _controlador.TipoMovCaja.setFichaById(CB_TIPO_MOV_CAJA.SelectedValue.ToString());
            }
        }
        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Estatus.setFichaById("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.Estatus.setFichaById(CB_ESTATUS.SelectedValue.ToString());
            }
        }
        private void CB_ALIADO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Aliado.setFichaById("");
            if (CB_ALIADO.SelectedIndex != -1)
            {
                _controlador.Aliado.setFichaById(CB_ALIADO.SelectedValue.ToString());
            }
        }
        private void CB_PROVEEDOR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Proveedor.setFichaById("");
            if (CB_PROVEEDOR.SelectedIndex != -1)
            {
                _controlador.Proveedor.setFichaById(CB_PROVEEDOR.SelectedValue.ToString());
            }
        }
        private void CB_CAJA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Caja.setFichaById("");
            if (CB_CAJA.SelectedIndex != -1)
            {
                _controlador.Caja.setFichaById(CB_CAJA.SelectedValue.ToString());
            }
        }
        private void CB_CONCEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Concepto.setFichaById("");
            if (CB_CONCEPTO.SelectedIndex != -1)
            {
                _controlador.Concepto.setFichaById(CB_CONCEPTO.SelectedValue.ToString());
            }
        }
        private void CB_BENEFICIARIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Beneficiario.setFichaById("");
            if (CB_BENEFICIARIO.SelectedIndex != -1)
            {
                _controlador.Beneficiario.setFichaById(CB_BENEFICIARIO.SelectedValue.ToString());
            }
        }
        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            if (DTP_DESDE.Checked)
            {
                _controlador.Desde.setFecha(DTP_DESDE.Value);
                _controlador.Desde.setActivar(true);
            }
            else
            {
                _controlador.Desde.setActivar(false);
            }
        }
        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            if (DTP_HASTA.Checked)
            {
                _controlador.Hasta.setFecha(DTP_HASTA.Value);
                _controlador.Hasta.setActivar (true);
            }
            else
            {
                _controlador.Hasta.setActivar(false);
            }
        }


        private void L_TIPO_MOV_CAJA_Click(object sender, EventArgs e)
        {
            CB_TIPO_MOV_CAJA.SelectedIndex = -1;
        }
        private void L_ESTATUS_DOC_Click(object sender, EventArgs e)
        {
            CB_ESTATUS.SelectedIndex = -1;
        }
        private void L_ALIADO_Click(object sender, EventArgs e)
        {
            CB_ALIADO.SelectedIndex = -1;
            TB_ALIADO.Text = _controlador.Aliado.Get_TextoBuscar;
        }
        private void L_PROVEEDOR_Click(object sender, EventArgs e)
        {
            CB_PROVEEDOR.SelectedIndex = -1;
            TB_PROVEEDOR.Text = _controlador.Proveedor.Get_TextoBuscar;
        }
        private void L_CAJA_Click(object sender, EventArgs e)
        {
            CB_CAJA.SelectedIndex = -1;
            TB_CAJA.Text = _controlador.Caja.Get_TextoBuscar;
        }
        private void L_CONCEPTO_Click(object sender, EventArgs e)
        {
            CB_CONCEPTO.SelectedIndex = -1;
            TB_CONCEPTO.Text = _controlador.Concepto.Get_TextoBuscar;
        }
        private void L_BENEFICIARIO_Click(object sender, EventArgs e)
        {
            CB_BENEFICIARIO.SelectedIndex = -1;
            TB_BENEFICIARIO.Text = _controlador.Beneficiario.Get_TextoBuscar;
        }
        private void L_FECHA_Click(object sender, EventArgs e)
        {
            _controlador.Desde.Limpiar();
            _controlador.Hasta.Limpiar();
            DTP_DESDE.Value = _controlador.Desde.Fecha;
            DTP_HASTA.Value = _controlador.Hasta.Fecha;
        }


        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            ProcesarFiltros();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void ProcesarFiltros()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOK)
            {
                Salir();
            }
        }
        private void AbandonarFicha()
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
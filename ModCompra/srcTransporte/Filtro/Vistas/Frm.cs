using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.Filtro.Vistas
{
    public partial class Frm : Form
    {
        private IFiltro _controlador;


        private void InicializaCB() 
        {
            CB_ESTATUS.DisplayMember = "desc";
            CB_ESTATUS.ValueMember = "id";
            CB_TIPO_MOV_CAJA.DisplayMember = "desc";
            CB_TIPO_MOV_CAJA.ValueMember = "id";
            CB_CAJA.DisplayMember = "desc";
            CB_CAJA.ValueMember = "id";
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
            CB_ESTATUS.DataSource = _controlador.HndFiltro.Get_EstatusSource;
            CB_TIPO_MOV_CAJA.DataSource = _controlador.HndFiltro.Get_TipoMovCajaSource;
            CB_CAJA.DataSource = _controlador.HndFiltro.Get_CajaSource;
            TB_CAJA.Text = _controlador.HndFiltro.GetCaja_TextoBuscar;
            //
            CB_ESTATUS.SelectedValue = _controlador.HndFiltro.Get_EstatusById;
            CB_TIPO_MOV_CAJA.SelectedValue = _controlador.HndFiltro.Get_TipoMovCajaById;
            CB_CAJA.SelectedValue = _controlador.HndFiltro.Get_CajaById;

            _modoInicializar = false;
        }
        private void CTR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        public void setControlador(Vistas.IFiltro ctr)
        {
            _controlador = ctr;
        }


        private void TB_CAJA_Leave(object sender, EventArgs e)
        {
            _controlador.HndFiltro.setCajaBuscar(TB_CAJA.Text.Trim().ToUpper());
        }
        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.HndFiltro.setEstatusById("");
            if (CB_ESTATUS.SelectedIndex != -1) 
            {
                _controlador.HndFiltro.setEstatusById(CB_ESTATUS.SelectedValue.ToString());
            }
        }
        private void CB_TIPO_MOV_CAJA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.HndFiltro.setTipoMovCajaById("");
            if (CB_TIPO_MOV_CAJA.SelectedIndex != -1)
            {
                _controlador.HndFiltro.setTipoMovCajaById(CB_TIPO_MOV_CAJA.SelectedValue.ToString());
            }
        }
        private void CB_CAJA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.HndFiltro.setCajaById("");
            if (CB_CAJA.SelectedIndex != -1)
            {
                _controlador.HndFiltro.setCajaById(CB_CAJA.SelectedValue.ToString());
            }
        }
        private void L_ESTATUS_DOC_Click(object sender, EventArgs e)
        {
            CB_ESTATUS.SelectedIndex = -1;
        }
        private void L_TIPO_MOV_CAJA_Click(object sender, EventArgs e)
        {
            CB_TIPO_MOV_CAJA.SelectedIndex = -1;
        }
        private void L_CAJA_Click(object sender, EventArgs e)
        {
            CB_CAJA.SelectedIndex = -1;
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
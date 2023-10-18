using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.Filtro.Beneficiario
{
    public partial class Frm : Form
    {
        private Vistas.IFiltro _controlador;


        private void InicializaCB() 
        {
            CB_ESTATUS.DisplayMember = "desc";
            CB_ESTATUS.ValueMember = "id";
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
            CB_ESTATUS.DataSource = _controlador.HndFiltro.Get_EstatusSource;
            CB_BENEFICIARIO.DataSource = _controlador.HndFiltro.Get_BeneficiarioSource;
            TB_BENEFICIARIO.Text = _controlador.HndFiltro.GetAliado_TextoBuscar;
            CB_ESTATUS.SelectedValue = _controlador.HndFiltro.Get_EstatusById;
            CB_BENEFICIARIO.SelectedValue = _controlador.HndFiltro.Get_BeneficiarioById;
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


        private void TB_BENEFICIARIO_Leave(object sender, EventArgs e)
        {
            _controlador.HndFiltro.setBeneficiarioBuscar(TB_BENEFICIARIO.Text.Trim().ToUpper());
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
        private void CB_BENEFICIARIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.HndFiltro.setBeneficiarioById("");
            if (CB_BENEFICIARIO.SelectedIndex != -1)
            {
                _controlador.HndFiltro.setBeneficiarioById(CB_BENEFICIARIO.SelectedValue.ToString());
            }
        }
        private void L_ESTATUS_DOC_Click(object sender, EventArgs e)
        {
            CB_ESTATUS.SelectedIndex = -1;
        }
        private void L_ALIADO_Click(object sender, EventArgs e)
        {
            CB_BENEFICIARIO.SelectedIndex = -1;
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
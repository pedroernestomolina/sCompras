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
            CB_ESTATUS.DisplayMember = "desc";
            CB_ESTATUS.ValueMember = "id";
            CB_ALIADO.DisplayMember = "desc";
            CB_ALIADO.ValueMember = "id";
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
            CB_ESTATUS.DataSource = _controlador.Estatus.GetSource;
            CB_ALIADO.DataSource = _controlador.Aliado.GetSource ;
            TB_ALIADO.Text = _controlador.Aliado.Get_TextoBuscar;
            CB_ESTATUS.SelectedValue = _controlador.Estatus.GetId;
            CB_ALIADO.SelectedValue = _controlador.Aliado.GetId;
            //
            CB_ESTATUS.Enabled = _controlador.FiltroActivar.Estatus;
            TB_ALIADO.Enabled = _controlador.FiltroActivar.Aliado;
            CB_ALIADO.Enabled = _controlador.FiltroActivar.Aliado;
            _modoInicializar = false;
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
        private void L_ESTATUS_DOC_Click(object sender, EventArgs e)
        {
            CB_ESTATUS.SelectedIndex = -1;
        }
        private void L_ALIADO_Click(object sender, EventArgs e)
        {
            CB_ALIADO.SelectedIndex = -1;
            TB_ALIADO.Text = _controlador.Aliado.Get_TextoBuscar;
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.ReporteProveedor.Filtro
{

    public partial class FiltroFrm : Form
    {

        private Gestion _controlador;


        public FiltroFrm()
        {
            InitializeComponent();
            InicializaControles();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void InicializaControles()
        {
            CB_GRUPO.ValueMember = "Id";
            CB_GRUPO.DisplayMember = "Descripcion";
            CB_ESTADO.ValueMember = "Id";
            CB_ESTADO.DisplayMember = "Descripcion";
            CB_ESTATUS.ValueMember = "Id";
            CB_ESTATUS.DisplayMember = "Descripcion";
        }

        private bool _modoInicializar;
        private void FiltrosFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CB_GRUPO.DataSource = _controlador.SourceGrupo;
            CB_ESTADO.DataSource = _controlador.SourceEstado;
            CB_ESTATUS.DataSource = _controlador.SourceEstatus;

            L_GRUPO.Enabled = _controlador.ActivarGrupo;
            CB_GRUPO.Enabled = _controlador.ActivarGrupo;
            L_ESTADO.Enabled = _controlador.ActivarEstado;
            CB_ESTADO.Enabled = _controlador.ActivarEstado;
            L_ESTATUS.Enabled = _controlador.ActivarEstatus;
            CB_ESTATUS.Enabled= _controlador.ActivarEstatus;
            _modoInicializar = false;

            LimpiarFiltros();
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            LimpiarGrupo();
            LimpiarEstado();
            LimpiarEstatus();
        }

         private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            _controlador.Salir();
            this.Close();
        }

        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            _controlador.Filtrar();
            if (_controlador.IsOk)
            {
                Salir();
            }
        }

        private void FiltroFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_controlador.IsOk)
            {
                e.Cancel = true;
            }
        }

        private void L_GRUPO_Click(object sender, EventArgs e)
        {
            LimpiarGrupo();
        }

        private void LimpiarGrupo()
        {
            CB_GRUPO.SelectedIndex = -1;
        }

        private void L_ESTADO_Click(object sender, EventArgs e)
        {
            LimpiarEstado();
        }

        private void LimpiarEstado()
        {
            CB_ESTADO.SelectedIndex = -1;
        }

        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            LimpiarEstatus();
        }

        private void LimpiarEstatus()
        {
            CB_ESTATUS.SelectedIndex = -1;
        }


        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;
            _controlador.setGrupo("");
            if (CB_GRUPO.SelectedIndex != -1) 
            {
                _controlador.setGrupo(CB_GRUPO.SelectedValue.ToString());
            }
        }

        private void CB_ESTADO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;
            _controlador.setEstado("");
            if (CB_ESTADO.SelectedIndex != -1)
            {
                _controlador.setEstado(CB_ESTADO.SelectedValue.ToString());
            }
        }

        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;
            _controlador.setEstatus("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.setEstatus(CB_ESTATUS.SelectedValue.ToString());
            }
        }
    
    }

}
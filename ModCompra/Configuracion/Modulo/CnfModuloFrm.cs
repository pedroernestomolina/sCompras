using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Configuracion.Modulo
{

    public partial class CnfModuloFrm : Form
    {

        private IConf _controlador;


        public CnfModuloFrm()
        {
            InitializeComponent();
            Inicializa();
        }

        private void Inicializa()
        {
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void Abandonar()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOK) 
            {
                Salir();
            }
        }
        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOK)
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }

        private void CnfModuloFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK || _controlador.ProcesarIsOK)
            {
                e.Cancel = false;
            }
        }

        bool _modoInicializar;
        private void CnfModuloFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CHP_CAMBIAR_PRECIO_VENTA.Checked = _controlador.GetCambiarPrecioVenta;
            _modoInicializar = false;
        }

        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        public void setControlador(IConf ctr)
        {
            _controlador = ctr;
        }

        private void CHP_CAMBIAR_PRECIO_VENTA_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setCambiarPrecioVenta(CHP_CAMBIAR_PRECIO_VENTA.Checked);
        }

    }

}
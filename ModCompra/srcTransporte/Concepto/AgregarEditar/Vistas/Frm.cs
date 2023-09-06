using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.Concepto.AgregarEditar.Vistas
{
    public partial class Frm : Form
    {
        private IAgregarEditar _controlador;


        public Frm()
        {
            InitializeComponent();
        }
        
        private void Frm_Load(object sender, EventArgs e)
        {
            IrFoco_Identificacion();
            TB_CODIGO.Text =  _controlador.data.Get_Codigo;
            TB_DESCRIPCION.Text = _controlador.data.Get_Descripcion;
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOK || _controlador.AbandonarIsOK)
            {
                e.Cancel = false;
            }
        }
        public void setControlador(IAgregarEditar ctr)
        {
            _controlador = ctr;
        }


        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            _controlador.data.SetCodigo(TB_CODIGO.Text.Trim().ToUpper());
            TB_CODIGO.Text = _controlador.data.Get_Codigo;
        }
        private void TB_DESCRIPCION_Leave(object sender, EventArgs e)
        {
            _controlador.data.SetDescripcion(TB_DESCRIPCION.Text.Trim().ToUpper());
            TB_DESCRIPCION.Text = _controlador.data.Get_Descripcion;
        }


        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            IrFoco_Identificacion();
            ProcesarFicha();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            IrFoco_Identificacion();
            AbandonarFicha();
        }


        private void ProcesarFicha()
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
        private void IrFoco_Identificacion()
        {
            GB_IDENTIFICACION.Focus();
            TB_CODIGO.Focus();
        }
    }
}
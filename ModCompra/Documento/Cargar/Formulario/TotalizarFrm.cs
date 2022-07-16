using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Formulario
{

    public partial class TotalizarFrm : Form
    {


        Controlador.IGestionTotalizar  _controlador; 


        public TotalizarFrm()
        {
            InitializeComponent();
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            _controlador.Guardar();
        }

        public void setControlador(Controlador.IGestionTotalizar ctr)
        {
            _controlador = ctr;
        }

        private void TotalizarFrm_Load(object sender, EventArgs e)
        {
            L_MONTO.Text = _controlador.Monto.ToString("n2");
            TB_NOTAS.Text = _controlador.Notas;
            TB_DSCTO_1.Text = _controlador.Dscto.ToString();
            TB_CARGO_1.Text = _controlador.Cargo.ToString();
            L_TOTAL.Text = _controlador.Total.ToString("n2");
            TB_DSCTO_1.Enabled = _controlador.HabilitarDscto;
            TB_CARGO_1.Enabled = _controlador.HabilitarCargo;
        }

        private void TB_DSCTO_1_Leave(object sender, EventArgs e)
        {
            _controlador.setDscto(decimal.Parse(TB_DSCTO_1.Text));
            L_TOTAL.Text = _controlador.Total.ToString("n2");
        }

        private void TB_CARGO_1_Leave(object sender, EventArgs e)
        {
            _controlador.setCargo(decimal.Parse(TB_CARGO_1.Text));
            L_TOTAL.Text = _controlador.Total.ToString("n2");
        }

        private void Ctrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_NOTAS_Leave(object sender, EventArgs e)
        {
            _controlador.SetNotas(TB_NOTAS.Text.Trim().ToUpper());
        }

    }

}
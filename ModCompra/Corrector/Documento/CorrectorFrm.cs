using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Corrector.Documento
{

    public partial class CorrectorFrm : Form
    {


        private Gestion _controlador;
        private bool salirIsOk;


        public CorrectorFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void CorrectorFrm_Load(object sender, EventArgs e)
        {
            TB_DOCUMENTO_NRO.Text = _controlador.getDocumento;
            TB_CONTROL_NRO.Text = _controlador.getControl;
            TB_NOTAS.Text = _controlador.getNotas;
            TB_CIRIF.Text = _controlador.getCiRif;
            TB_RAZON_SOCIAL.Text = _controlador.getRazonSocial;
            TB_DIR_FISCAL.Text = _controlador.getDirFiscal;
            DTP_FECHA_EIMSION.Value = _controlador.getFechaEmision;
        }

        private void TB_DOCUMENTO_NRO_Leave(object sender, EventArgs e)
        {
            _controlador.setDocumento(TB_DOCUMENTO_NRO.Text);
        }

        private void DTP_FECHA_EIMSION_Leave(object sender, EventArgs e)
        {
            _controlador.setFechaEmision(DTP_FECHA_EIMSION.Value );
        }

        private void TB_CONTROL_NRO_Leave(object sender, EventArgs e)
        {
            _controlador.setControl(TB_CONTROL_NRO.Text);
        }

        private void TB_CIRIF_Leave(object sender, EventArgs e)
        {
            _controlador.setCiRif(TB_CIRIF.Text);
        }

        private void TB_RAZON_SOCIAL_Leave(object sender, EventArgs e)
        {
            _controlador.setRazonSocial(TB_RAZON_SOCIAL.Text);
        }

        private void TB_DIR_FISCAL_Leave(object sender, EventArgs e)
        {
            _controlador.setDirFiscal(TB_DIR_FISCAL.Text);
        }

        private void TB_NOTAS_Leave(object sender, EventArgs e)
        {
            _controlador.setNotas(TB_NOTAS.Text);
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            AceptarGuardar();
        }

        private void AceptarGuardar()
        {
            salirIsOk = false;
            _controlador.AceptarGuardar();
            if (_controlador.GuardarIsOK) 
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            salirIsOk = false;
            var msg = MessageBox.Show("Abandonar Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                salirIsOk = true;
                Salir();
            }
        }

        private void CorrectorFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_controlador.GuardarIsOK || salirIsOk)
                e.Cancel = false;
            else
            {
                e.Cancel = true;
            }
        }

    }

}
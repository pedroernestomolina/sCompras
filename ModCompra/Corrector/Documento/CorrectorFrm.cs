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
        private IGestion _controlador;
        //
        public CorrectorFrm()
        {
            InitializeComponent();
        }
        private bool _modoInicial;
        private void CorrectorFrm_Load(object sender, EventArgs e)
        {
            _modoInicial = true;
            TB_DOCUMENTO_NRO.Text = _controlador.GetDocumento;
            TB_CONTROL_NRO.Text = _controlador.GetControl;
            TB_NOTAS.Text = _controlador.GetNotas;
            TB_CIRIF.Text = _controlador.GetCiRif;
            TB_RAZON_SOCIAL.Text = _controlador.GetRazonSocial;
            TB_DIR_FISCAL.Text = _controlador.GetDirFiscal;
            DTP_FECHA_EIMSION.Value = _controlador.GetFechaEmision;
            EXENTO.Text = _controlador.GetMontoExento;
            BASE_1.Text = _controlador.GetMontoBase1;
            BASE_2.Text = _controlador.GetMontoBase2;
            BASE_3.Text = _controlador.GetMontoBase3;
            IVA_1.Text = _controlador.GetMontoIva1;
            IVA_2.Text = _controlador.GetMontoIva2;
            IVA_3.Text = _controlador.GetMontoIva3;
            TASA_1.Text = _controlador.GetTasa1;
            TASA_2.Text = _controlador.GetTasa2;
            TASA_3.Text = _controlador.GetTasa3;
            MBASE.Text = _controlador.GetMontoBase;
            MIVA.Text = _controlador.GetMontoIva;
            MTOTAL.Text = _controlador.GetMontoTotal;
            _modoInicial = false;
        }
        public void setControlador(IGestion ctr)
        {
            _controlador = ctr;
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
        private void EXENTO_Leave(object sender, EventArgs e)
        {
            var _monto= decimal.Parse(EXENTO.Text);
            _controlador.setMontoExento(_monto);
            actualizarTotales();
        }
        private void BASE_1_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(BASE_1.Text);
            _controlador.setMontoBase1(_monto);
            actualizarTotales();
        }
        private void IVA_1_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(IVA_1.Text);
            _controlador.setMontoIva1(_monto);
            actualizarTotales();
        }
        private void BASE_2_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(BASE_2.Text);
            _controlador.setMontoBase2(_monto);
            actualizarTotales();
        }
        private void IVA_2_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(IVA_2.Text);
            _controlador.setMontoIva2(_monto);
            actualizarTotales();
        }
        private void BASE_3_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(BASE_3.Text);
            _controlador.setMontoBase3(_monto);
            actualizarTotales();
        }
        private void IVA_3_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(IVA_3.Text);
            _controlador.setMontoIva3(_monto);
            actualizarTotales();
        }
        private void MBASE_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(MBASE.Text);
            _controlador.setMontoBase(_monto);
        }
        private void MIVA_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(MIVA.Text);
            _controlador.setMontoIva(_monto);
        }
        private void MTOTAL_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(MTOTAL.Text);
            _controlador.setMontoTotal(_monto);
        }
        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        //
        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        //
        private void Abandonar()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarFichaIsOk) 
            {
                Salir();
            }
        }
        private void Procesar()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarFichaIsOk) 
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
        private void CorrectorFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarFichaIsOk || _controlador.AbandonarFichaIsOk)
                e.Cancel = false;
        }
        //
        private void actualizarTotales()
        {
            MBASE.Text = _controlador.GetMontoBase;
            MIVA.Text = _controlador.GetMontoIva;
            MTOTAL.Text = _controlador.GetMontoTotal;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModCompra.srcTransporte.Retencion.Corrector.Vista
{
    public partial class Frm : Form
    {
        private IVista _controlador;
        //
        public Frm()
        {
            InitializeComponent();
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            TB_CIRIF.Text = _controlador.Doc.Get_PrvCiRif;
            TB_NOMBRE.Text = _controlador.Doc.Get_PrvNombre;
            TB_DIR_FISCAL.Text = _controlador.Doc.Get_PrvDirFiscal;
            DTP_FECHA_EMISION.Value = _controlador.Doc.Get_FechaEmision;
            TB_FACTURA_NRO.Text = _controlador.Doc.Get_FacturaNro;
            TB_CONTROL_NRO.Text = _controlador.Doc.Get_ControlNro;
            TB_COD_XML.Text = _controlador.Doc.Get_CodXml;
            TB_CONCEPTO_DESC.Text = _controlador.Doc.Get_ConceptoDesc;
            TB_EXENTO.Text = _controlador.Doc.Get_MontoExento.ToString("n2").Replace(".","");
            TB_BASE_1.Text = _controlador.Doc.Get_Base_1.ToString("n2").Replace(".", "");
            TB_BASE_2.Text = _controlador.Doc.Get_Base_2.ToString("n2").Replace(".", "");
            TB_BASE_3.Text = _controlador.Doc.Get_Base_3.ToString("n2").Replace(".", "");
            TB_IMP_1.Text = _controlador.Doc.Get_Imp_1.ToString("n2").Replace(".", "");
            TB_IMP_2.Text = _controlador.Doc.Get_Imp_2.ToString("n2").Replace(".", "");
            TB_IMP_3.Text = _controlador.Doc.Get_Imp_3.ToString("n2").Replace(".", "");
            TB_TASA_RET.Text = _controlador.Doc.Get_TasaRet.ToString("n2").Replace(".", "");
            TB_SUSTRAENDO.Text = _controlador.Doc.Get_Sustraendo.ToString("n2").Replace(".", "");
            TB_RET.Text = _controlador.Doc.Get_MontoRet.ToString("n2").Replace(".", "");
            TB_SUBT_BASE.Text = _controlador.Doc.Get_SubtBase.ToString("n2").Replace(".", "");
            TB_SUBT_IMP.Text = _controlador.Doc.Get_SubtImp.ToString("n2").Replace(".", "");
            TB_TOTAL.Text = _controlador.Doc.Get_Total.ToString("n2").Replace(".", "");
            L_TASA_1.Text = _controlador.Doc.Get_Tasa_1;
            L_TASA_2.Text = _controlador.Doc.Get_Tasa_2;
            L_TASA_3.Text = _controlador.Doc.Get_Tasa_3;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.BtAbandonar.OpcionIsOK || _controlador.ProcesarIsOK) 
            {
                e.Cancel = false;
            }
        }
        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        public void setControlador(IVista ctr)
        {
            _controlador = ctr;
        }

        private void TB_CIRIF_Leave(object sender, EventArgs e)
        {
            _controlador.Doc.setCiRif(TB_CIRIF.Text.Trim().ToUpper());
        }
        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.Doc.setNombre(TB_NOMBRE.Text.Trim().ToUpper());
        }
        private void TB_DIR_FISCAL_Leave(object sender, EventArgs e)
        {
            _controlador.Doc.setDirFiscal(TB_DIR_FISCAL.Text.Trim());
        }
        private void DTP_FECHA_EMISION_Leave(object sender, EventArgs e)
        {
            _controlador.Doc.setFechaEmisionDoc(DTP_FECHA_EMISION.Value);
        }
        private void TB_FACTURA_NRO_Leave(object sender, EventArgs e)
        {
            _controlador.Doc.setFacturaNro(TB_FACTURA_NRO.Text.Trim());
        }
        private void TB_CONTROL_NRO_Leave(object sender, EventArgs e)
        {
            _controlador.Doc.setControlNro(TB_CONTROL_NRO.Text.Trim());
        }
        private void TB_COD_XML_Leave(object sender, EventArgs e)
        {
            _controlador.Doc.setCodigoXML(TB_COD_XML.Text.Trim());
        }
        private void TB_CONCEPTO_DESC_Leave(object sender, EventArgs e)
        {
            _controlador.Doc.setDescXML(TB_CONCEPTO_DESC.Text.Trim());
        }
        private void TB_EXENTO_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_EXENTO.Text);
            _controlador.Doc.setExento(monto);
        }
        private void TB_BASE_1_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_BASE_1.Text);
            _controlador.Doc.setBase1(monto);
        }
        private void TB_BASE_2_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_BASE_2.Text);
            _controlador.Doc.setBase2(monto);
        }
        private void TB_BASE_3_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_BASE_3.Text);
            _controlador.Doc.setBase3(monto);
        }
        private void TB_IMP_1_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_IMP_1.Text);
            _controlador.Doc.setImp1(monto);
        }
        private void TB_IMP_2_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_IMP_2.Text);
            _controlador.Doc.setImp2(monto);
        }
        private void TB_IMP_3_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_IMP_3.Text);
            _controlador.Doc.setImp3(monto);
        }
        private void TB_SUBT_BASE_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_SUBT_BASE.Text);
            _controlador.Doc.setSubtBase(monto);
        }
        private void TB_SUBT_IMP_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_SUBT_IMP.Text);
            _controlador.Doc.setSubtImp(monto);
        }
        private void TB_TOTAL_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_TOTAL.Text);
            _controlador.Doc.setTotal(monto);
        }
        private void TB_TASA_RET_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_TASA_RET.Text);
            _controlador.Doc.setTasaRet(monto);
        }
        private void TB_SUSTRAENDO_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_SUSTRAENDO.Text);
            _controlador.Doc.setSustraendo(monto);
        }
        private void TB_RET_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_RET.Text);
            _controlador.Doc.setRetencion(monto);
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOK)
            {
                salir();
            }
        }
        private void AbandonarFicha()
        {
            _controlador.BtAbandonar.Opcion();
            if (_controlador.BtAbandonar.OpcionIsOK)
            {
                salir();
            }
        }
        private void salir()
        {
            this.Close();
        }
    }
}
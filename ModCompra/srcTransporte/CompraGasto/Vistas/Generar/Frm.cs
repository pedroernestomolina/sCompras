using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CompraGasto.Vistas.Generar
{
    public partial class Frm : Form
    {
        private ICompraGasto _controlador;
        private CultureInfo _cult;


        public Frm()
        {
            InitializeComponent();
            InicializaCB();
            _cult = CultureInfo.CurrentCulture;
        }
        private void InicializaCB()
        {
            CB_TIPO_DOC.DisplayMember = "desc";
            CB_TIPO_DOC.ValueMember = "id";
            CB_CONDICION_PAGO.DisplayMember = "desc";
            CB_CONDICION_PAGO.ValueMember = "id";
            CB_CONCEPTO.DisplayMember = "desc";
            CB_CONCEPTO.ValueMember = "id";
            CB_SUCURSAL.DisplayMember = "desc";
            CB_SUCURSAL.ValueMember = "id";
            CB_APLICA_TIPO_DOC.DisplayMember = "desc";
            CB_APLICA_TIPO_DOC.ValueMember = "id";
        }
        public void setControlador(ICompraGasto ctr)
        {
            _controlador = ctr;
        }

        private bool _modoInicializa;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializa=true;
            //
            CB_TIPO_DOC.DataSource = _controlador.data.Get_TipoDocumento_Source;
            CB_CONDICION_PAGO.DataSource = _controlador.data.Get_CondicionPago_Source;
            TB_NUMERO_DOC.Text = _controlador.data.Get_NumeroDoc;
            TB_CONTROL_DOC.Text = _controlador.data.Get_NumeroControlDoc;
            TB_MAQ_FISCAL.Text = _controlador.data.Get_MaquinaFiscal;
            TB_DIAS_CREDITO.Text = _controlador.data.Get_DiasCreditoDoc.ToString("n0");
            DTP_FECHA_EMISION_DOC.Value = _controlador.data.Get_FechaEmisionDoc;
            L_FECHA_VENCIMIENTO_DOC.Text = _controlador.data.Get_FechaVenceDoc.ToShortDateString();
            CB_TIPO_DOC.SelectedValue = _controlador.data.Get_TipoDocumento_ID;
            CB_CONDICION_PAGO.SelectedValue= _controlador.data.Get_CondicionPago_ID;
            //
            CB_SUCURSAL.DataSource = _controlador.data.Get_Sucursal_Source;
            CB_CONCEPTO.DataSource = _controlador.data.Get_Concepto_Source;
            CB_SUCURSAL.SelectedValue = _controlador.data.Get_Sucursal_ID;
            CB_CONCEPTO.SelectedValue = _controlador.data.Get_Concepto_ID;
            CHB_INCLUIR_LIBRO_COMPRA.Checked = _controlador.data.Get_IncluirLibroCompras;
            TB_NOTAS.Text = _controlador.data.Get_Notas;
            //
            L_PROVEEDOR.Text = _controlador.data.Proveedor.Get_Inf;
            TB_PROVEEDOR.Text = _controlador.data.Proveedor.Get_Buscar;
            //
            CB_APLICA_TIPO_DOC.DataSource = _controlador.data.Get_AplicaTipoDocumento_Source;
            CB_APLICA_TIPO_DOC.SelectedValue = _controlador.data.Get_AplicaTipoDocumento_ID;
            CB_APLICA_TIPO_DOC.Enabled = _controlador.data.AplicaActivo;
            TB_APLICA_NUMERO_DOC.Enabled = _controlador.data.AplicaActivo;
            DTP_APLICA_FECHA_DOC.Enabled = _controlador.data.AplicaActivo;
            TB_APLICA_NUMERO_DOC.Text = _controlador.data.Get_Aplica_NumeroDoc;
            DTP_APLICA_FECHA_DOC.Value = _controlador.data.Get_Aplica_FechaDoc;
            //
            TB_FACTOR_CAMBIO.Text = _controlador.data.Get_FactorCambio.ToString("n2", _cult);
            TB_TASA_EX_BASE.Text = _controlador.data.TasaEx.Get_Base.ToString("n2", _cult);
            L_TASA1.Text = _controlador.data.Tasa1.Get_Tasa.ToString("n2", _cult);
            TB_TASA1_BASE.Text = _controlador.data.Tasa1.Get_Base.ToString("n2", _cult);
            TB_TASA1_IMP.Text = _controlador.data.Tasa1.Get_Imp.ToString("n2", _cult);
            L_TASA2.Text = _controlador.data.Tasa2.Get_Tasa.ToString("n2", _cult);
            TB_TASA2_BASE.Text = _controlador.data.Tasa2.Get_Base.ToString("n2", _cult);
            TB_TASA2_IMP.Text = _controlador.data.Tasa2.Get_Imp.ToString("n2", _cult);
            L_TASA3.Text = _controlador.data.Tasa3.Get_Tasa.ToString("n2", _cult);
            TB_TASA3_BASE.Text = _controlador.data.Tasa3.Get_Base.ToString("n2", _cult);
            TB_TASA3_IMP.Text = _controlador.data.Tasa3.Get_Imp.ToString("n2", _cult);
            L_SUBT_BASE.Text = _controlador.data.Get_SubtotalBase.ToString("n2", _cult);
            L_SUBT_IMP.Text = _controlador.data.Get_SubtotalImp.ToString("n2", _cult);
            L_MONTO.Text = _controlador.data.Get_Monto.ToString("n2", _cult);
            L_MONTO_MON_ACT.Text = _controlador.data.Get_MontoMonAct.ToString("n2", _cult);
            L_MONTO_MON_DIVISA.Text = _controlador.data.Get_MontoMonDivisa.ToString("n2", _cult);
            TB_IGTF_MONTO.Text = _controlador.data.Get_MontoIGTF.ToString("n2", _cult);
            //
            L_BASE_RET_IVA.Text = _controlador.data.Get_SubtotalImp.ToString("n2", _cult);
            L_BASE_RET_ISLR.Text = _controlador.data.Get_SubtotalNeto.ToString("n2", _cult);
            TB_RET_IVA_PORC.Text = _controlador.data.Get_TasaRetIva.ToString("n2", _cult);
            L_MONTO_RET_IVA.Text = _controlador.data.Get_MontoRetIva.ToString("n2", _cult);
            TB_RET_ISLR_PORC.Text = _controlador.data.Get_TasaRetISLR.ToString("n2", _cult);
            TB_RET_ISLR_MONTO.Text = _controlador.data.Get_MontoRetISLR.ToString("n2", _cult);
            TB_SUSTRAENDO_ISLR.Text = _controlador.data.Get_SustraendoISLR.ToString("n2", _cult);
            //
            RETENCIONES.Enabled = _controlador.data.Get_IncluirLibroCompras;
            //
            _modoInicializa = false;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK || _controlador.ProcesarIsOK) 
            {
                e.Cancel = false;
            }
        }
        private void CTRL_KEYDOWN(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void CB_TIPO_DOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.data.SetTipoDocumentoById("");
            if (CB_TIPO_DOC.SelectedIndex != -1) 
            {
                _controlador.data.SetTipoDocumentoById(CB_TIPO_DOC.SelectedValue.ToString());
            }
            ActualizAplica();
        }
        private void CB_CONDICION_PAGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.data.SetCondicionPagoById("");
            if (CB_CONDICION_PAGO.SelectedIndex != -1)
            {
                _controlador.data.SetCondicionPagoById(CB_CONDICION_PAGO.SelectedValue.ToString());
            }
        }
        private void TB_NUMERO_DOC_Leave(object sender, EventArgs e)
        {
            _controlador.data.SetNumeroDoc(TB_NUMERO_DOC.Text.Trim().ToUpper());
            TB_NUMERO_DOC.Text = _controlador.data.Get_NumeroDoc;
        }
        private void TB_CONTROL_DOC_Leave(object sender, EventArgs e)
        {
            _controlador.data.SetNumeroControlDoc(TB_CONTROL_DOC.Text.Trim().ToUpper());
            TB_CONTROL_DOC.Text = _controlador.data.Get_NumeroControlDoc;
        }
        private void TB_MAQ_FISCAL_Leave(object sender, EventArgs e)
        {
            _controlador.data.SetMaquinaFiscal(TB_MAQ_FISCAL.Text.Trim().ToUpper());
            TB_MAQ_FISCAL.Text = _controlador.data.Get_MaquinaFiscal;
        }
        private void DTP_FECHA_EMISION_DOC_ValueChanged(object sender, EventArgs e)
        {
            _controlador.data.SetFechaEmisionDoc(DTP_FECHA_EMISION_DOC.Value);
            ActualizarFechaVencimiento();
        }
        private void DTP_FECHA_EMISION_DOC_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.data.Get_FechaEmisionDocIsOk;
        }
        private void TB_DIAS_CREDITO_Leave(object sender, EventArgs e)
        {
            var _dias = int.Parse(TB_DIAS_CREDITO.Text);
            _controlador.data.SetDiasCreditoDoc(_dias);
            ActualizarFechaVencimiento();
        }
        

        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.data.SetSucursalById("");
            if (CB_SUCURSAL.SelectedIndex != -1)
            {
                _controlador.data.SetSucursalById(CB_SUCURSAL.SelectedValue.ToString());
            }
        }
        private void CB_CONCEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.data.SetConceptoById("");
            if (CB_CONCEPTO.SelectedIndex != -1)
            {
                _controlador.data.SetConceptoById(CB_CONCEPTO.SelectedValue.ToString());
            }
        }
        private void CHB_INCLUIR_LIBRO_COMPRA_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.data.SetIncluirLibroCompras();
            RETENCIONES.Enabled = _controlador.data.Get_IncluirLibroCompras;
            ActualizaTotal();
        }
        private void TB_NOTAS_Leave(object sender, EventArgs e)
        {
            _controlador.data.SetNotasDoc(TB_NOTAS.Text.Trim());
        }


        private void TB_PROVEEDOR_Leave(object sender, EventArgs e)
        {
            _controlador.data.Proveedor.SetBuscar(TB_PROVEEDOR.Text.Trim());
        }
        private void BT_PROVEEDOR_BUSCAR_Click(object sender, EventArgs e)
        {
            _controlador.data.BuscarProveedor();
            ActualizarProveedor();
            TB_RET_IVA_PORC.Text = _controlador.data.Get_TasaRetIva.ToString("n2", _cult);
            ActualizaTotal();
        }


        private void CB_APLICA_TIPO_DOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.data.SetAplicaTipoDocumentoById("");
            if (CB_APLICA_TIPO_DOC.SelectedIndex != -1)
            {
                _controlador.data.SetAplicaTipoDocumentoById(CB_APLICA_TIPO_DOC.SelectedValue.ToString());
            }
        }
        private void TB_APLICA_NUMERO_DOC_Leave(object sender, EventArgs e)
        {
            _controlador.data.SetAplicaNumeroDoc(TB_APLICA_NUMERO_DOC.Text.Trim());
        }
        private void DTP_APLICA_FECHA_DOC_ValueChanged(object sender, EventArgs e)
        {
            _controlador.data.SetAplicaFechaDoc(DTP_APLICA_FECHA_DOC.Value);
        }
        private void DTP_APLICA_FECHA_DOC_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.data.Get_FechaAplicaDocIsOk;
        }
        

        private void TB_FACTOR_CAMBIO_Leave(object sender, EventArgs e)
        {
            var _factor = decimal.Parse(TB_FACTOR_CAMBIO.Text);
            _controlador.data.SetFactorCambio(_factor);
            TB_FACTOR_CAMBIO.Text = _controlador.data.Get_FactorCambio.ToString("n2", _cult);
            ActualizaTotal();
        }
        private void TB_FACTOR_CAMBIO_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.data.Get_FactorCambio<=0m;
        }
        private void TB_TASA_EX_BASE_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_TASA_EX_BASE.Text);
            _controlador.data.TasaEx.SetBase(_monto);
            _controlador.data.ActualizarRetencion_Iva_ISLR();
            TB_TASA_EX_BASE.Text = _controlador.data.TasaEx.Get_Base.ToString("n2");
            ActualizaTotal();
        }
        private void TB_TASA1_BASE_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_TASA1_BASE.Text);
            _controlador.data.Tasa1.SetBase(_monto);
            _controlador.data.ActualizarRetencion_Iva_ISLR();
            TB_TASA1_BASE.Text = _controlador.data.Tasa1.Get_Base.ToString("n2");
            TB_TASA1_IMP.Text = _controlador.data.Tasa1.Get_Imp.ToString("n2");
            ActualizaTotal();
        }
        private void TB_TASA2_BASE_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_TASA2_BASE.Text);
            _controlador.data.Tasa2.SetBase(_monto);
            _controlador.data.ActualizarRetencion_Iva_ISLR();
            TB_TASA2_BASE.Text = _controlador.data.Tasa2.Get_Base.ToString("n2");
            TB_TASA2_IMP.Text = _controlador.data.Tasa2.Get_Imp.ToString("n2");
            ActualizaTotal();
        }
        private void TB_TASA3_BASE_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_TASA3_BASE.Text);
            _controlador.data.Tasa3.SetBase(_monto);
            _controlador.data.ActualizarRetencion_Iva_ISLR();
            TB_TASA3_BASE.Text = _controlador.data.Tasa3.Get_Base.ToString("n2");
            TB_TASA3_IMP.Text = _controlador.data.Tasa3.Get_Imp.ToString("n2");
            ActualizaTotal();
        }
        private void TB_IGTF_MONTO_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_IGTF_MONTO.Text);
            _controlador.data.SetMontoIGTF(_monto);
            TB_IGTF_MONTO.Text = _controlador.data.Get_MontoIGTF.ToString("n2");
            ActualizaTotal();
        }


        private void TB_RET_IVA_PORC_Leave(object sender, EventArgs e)
        {
            var _tasa= decimal.Parse(TB_RET_IVA_PORC.Text);
            _controlador.data.SetTasaRetIva(_tasa);
            TB_RET_IVA_PORC.Text = _controlador.data.Get_TasaRetIva.ToString("n2", _cult);
            ActualizaTotal();
        }
        private void TB_RET_IVA_PORC_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.data.Get_TasaRetIva > 100;
        }
        private void TB_RET_ISLR_PORC_Leave(object sender, EventArgs e)
        {
            var _tasa = decimal.Parse(TB_RET_ISLR_PORC.Text);
            _controlador.data.SetTasaRetISLR(_tasa);
            TB_RET_ISLR_PORC.Text = _controlador.data.Get_TasaRetISLR.ToString("n2", _cult);
            ActualizaTotal();
        }
        private void TB_RET_ISLR_PORC_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.data.Get_TasaRetISLR > 100;
        }
        private void TB_RET_ISLR_MONTO_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_RET_ISLR_MONTO.Text);
            _controlador.data.SetMontoRetISLR(_monto);
            TB_RET_ISLR_MONTO.Text = _controlador.data.Get_MontoRetISLR.ToString("n2", _cult);
            ActualizaTotal();
        }
        private void TB_SUSTRAENDO_ISLR_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_SUSTRAENDO_ISLR.Text);
            _controlador.data.SetMontoSustraendoISLR(_monto);
            TB_SUSTRAENDO_ISLR.Text = _controlador.data.Get_SustraendoISLR.ToString("n2", _cult);
            ActualizaTotal();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            ProcesarFicha();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void ProcesarFicha()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOK)
            {
                salir();
            }
        }
        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOK) 
            {
                salir();
            }
        }
        private void salir()
        {
            this.Close();
        }

        
        private void ActualizAplica()
        {
            CB_APLICA_TIPO_DOC.Enabled = _controlador.data.AplicaActivo;
            TB_APLICA_NUMERO_DOC.Enabled = _controlador.data.AplicaActivo;
            DTP_APLICA_FECHA_DOC.Enabled = _controlador.data.AplicaActivo;
            TB_APLICA_NUMERO_DOC.Text = _controlador.data.Get_Aplica_NumeroDoc;
            DTP_APLICA_FECHA_DOC.Value = _controlador.data.Get_Aplica_FechaDoc;
        }
        private void ActualizarProveedor()
        {
            L_PROVEEDOR.Text = _controlador.data.Proveedor.Get_Inf;
            TB_PROVEEDOR.Text = _controlador.data.Proveedor.Get_Buscar;
        }
        private void ActualizarFechaVencimiento()
        {
            L_FECHA_VENCIMIENTO_DOC.Text = _controlador.data.Get_FechaVenceDoc.ToShortDateString();
        }
        private void ActualizaTotal()
        {
            L_SUBT_BASE.Text = _controlador.data.Get_SubtotalBase.ToString("n2", _cult);
            L_SUBT_IMP.Text = _controlador.data.Get_SubtotalImp.ToString("n2", _cult);
            L_MONTO.Text = _controlador.data.Get_Monto.ToString("n2", _cult);
            L_MONTO_MON_ACT.Text = _controlador.data.Get_MontoMonAct.ToString("n2", _cult);
            L_MONTO_MON_DIVISA.Text = _controlador.data.Get_MontoMonDivisa.ToString("n2", _cult);
            TB_IGTF_MONTO.Text = _controlador.data.Get_MontoIGTF.ToString();
            //
            L_BASE_RET_IVA.Text = _controlador.data.Get_SubtotalImp.ToString("n2", _cult);
            L_BASE_RET_ISLR.Text = _controlador.data.Get_SubtotalNeto.ToString("n2", _cult);
            TB_RET_IVA_PORC.Text = _controlador.data.Get_TasaRetIva.ToString();
            L_MONTO_RET_IVA.Text = _controlador.data.Get_MontoRetIva.ToString("n2", _cult);
            TB_RET_ISLR_PORC.Text = _controlador.data.Get_TasaRetISLR.ToString();
            TB_RET_ISLR_MONTO.Text = _controlador.data.Get_MontoRetISLR.ToString();
            TB_SUSTRAENDO_ISLR.Text = _controlador.data.Get_SustraendoISLR.ToString();
        }

        private void TB_CONCEPTO_TextChanged(object sender, EventArgs e)
        {
            _controlador.data.FiltrarConcepto(TB_CONCEPTO.Text);
            CB_CONCEPTO.Refresh();
        }
    }
}
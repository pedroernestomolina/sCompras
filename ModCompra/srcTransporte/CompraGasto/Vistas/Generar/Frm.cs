using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CompraGasto.Vistas.Generar
{
    public partial class Frm : Form
    {
        private ICompraGasto _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializaCB();
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
            CB_APLICA_TIPO_DOC.Enabled = _controlador.data.AplicaActivo;
            TB_APLICA_NUMERO_DOC.Enabled = _controlador.data.AplicaActivo;
            DTP_APLICA_FECHA_DOC.Enabled = _controlador.data.AplicaActivo;
            TB_APLICA_NUMERO_DOC.Text = _controlador.data.Get_Aplica_NumeroDoc;
            DTP_APLICA_FECHA_DOC.Value = _controlador.data.Get_Aplica_FechaDoc;
            //
            _modoInicializa = false;
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
            _controlador.data.SetNumeroDoc(TB_NUMERO_DOC.Text.Trim());
        }
        private void TB_CONTROL_DOC_Leave(object sender, EventArgs e)
        {
            _controlador.data.SetNumeroControlDoc(TB_CONTROL_DOC.Text.Trim());
        }
        private void DTP_FECHA_EMISION_DOC_ValueChanged(object sender, EventArgs e)
        {
            _controlador.data.SetFechaEmisionDoc(DTP_FECHA_EMISION_DOC.Value);
            ActualizarFechaVencimiento();
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
            _controlador.data.Proveedor.Buscar();
            ActualizarProveedor();
        }


        private void TB_APLICA_NUMERO_DOC_Leave(object sender, EventArgs e)
        {
            _controlador.data.SetAplicaNumeroDoc(TB_APLICA_NUMERO_DOC.Text.Trim());
        }
        private void DTP_APLICA_FECHA_DOC_ValueChanged(object sender, EventArgs e)
        {
            _controlador.data.SetAplicaFechaDoc(DTP_APLICA_FECHA_DOC.Value);
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


        private void DTP_FECHA_EMISION_DOC_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.data.Get_FechaEmisionDocIsOk;
        }
        private void DTP_APLICA_FECHA_DOC_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.data.Get_FechaAplicaDocIsOk;
        }
    }
}
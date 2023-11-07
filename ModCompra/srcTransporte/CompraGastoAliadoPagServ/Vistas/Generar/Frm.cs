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


namespace ModCompra.srcTransporte.CompraGastoAliadoPagServ.Vistas.Generar
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
            TB_NUMERO_DOC.Text = _controlador.HndData.Get_NumeroDoc;
            TB_CONTROL_DOC.Text = _controlador.HndData.Get_NumeroControlDoc;
            DTP_FECHA_EMISION_DOC.Value = _controlador.HndData.Get_FechaEmisionDoc;
            //
            CB_SUCURSAL.DataSource = _controlador.HndData.Sucursal.GetSource ;
            CB_CONCEPTO.DataSource = _controlador.HndData.Concepto.GetSource ;
            CB_SUCURSAL.SelectedValue = _controlador.HndData.Sucursal.GetId ;
            CB_CONCEPTO.SelectedValue = _controlador.HndData.Concepto.GetId ;
            TB_NOTAS.Text = _controlador.HndData.Get_Notas;
            //
            L_PROVEEDOR.Text = _controlador.HndData.Proveedor.Get_Inf;
            TB_PROVEEDOR.Text = _controlador.HndData.Proveedor.Get_Buscar;
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


        private void TB_NUMERO_DOC_Leave(object sender, EventArgs e)
        {
            _controlador.HndData.SetNumeroDoc(TB_NUMERO_DOC.Text.Trim().ToUpper());
            TB_NUMERO_DOC.Text = _controlador.HndData.Get_NumeroDoc;
        }
        private void TB_CONTROL_DOC_Leave(object sender, EventArgs e)
        {
            _controlador.HndData.SetNumeroControlDoc(TB_CONTROL_DOC.Text.Trim().ToUpper());
            TB_CONTROL_DOC.Text = _controlador.HndData.Get_NumeroControlDoc;
        }
        private void DTP_FECHA_EMISION_DOC_ValueChanged(object sender, EventArgs e)
        {
            _controlador.HndData.SetFechaEmisionDoc(DTP_FECHA_EMISION_DOC.Value);
        }
        private void DTP_FECHA_EMISION_DOC_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.HndData.Get_FechaEmisionDocIsOk;
        }
        

        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.HndData.Sucursal.setFichaById("");
            if (CB_SUCURSAL.SelectedIndex != -1)
            {
                _controlador.HndData.Sucursal.setFichaById(CB_SUCURSAL.SelectedValue.ToString());
            }
        }
        private void TB_CONCEPTO_TextChanged(object sender, EventArgs e)
        {
            _controlador.HndData.Concepto.setTextoBuscar(TB_CONCEPTO.Text);
            CB_CONCEPTO.Refresh();
        }
        private void CB_CONCEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.HndData.Concepto.setFichaById("");
            if (CB_CONCEPTO.SelectedIndex != -1)
            {
                _controlador.HndData.Concepto.setFichaById(CB_CONCEPTO.SelectedValue.ToString());
            }
        }
        private void TB_NOTAS_Leave(object sender, EventArgs e)
        {
            _controlador.HndData.SetNotasDoc(TB_NOTAS.Text.Trim());
        }


        private void TB_PROVEEDOR_Leave(object sender, EventArgs e)
        {
            _controlador.HndData.Proveedor.SetBuscar(TB_PROVEEDOR.Text.Trim());
        }
        private void BT_PROVEEDOR_BUSCAR_Click(object sender, EventArgs e)
        {
            _controlador.HndData.BuscarProveedor();
            ActualizarProveedor();
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

        
        private void ActualizarProveedor()
        {
            L_PROVEEDOR.Text = _controlador.HndData.Proveedor.Get_Inf;
            TB_PROVEEDOR.Text = _controlador.HndData.Proveedor.Get_Buscar;
        }
    }
}
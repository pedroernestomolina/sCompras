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

    public partial class DatosDocumentoFrm : Form
    {

        private Controlador.GestionDocumento _controlador;


        public DatosDocumentoFrm()
        {
            InitializeComponent();
            InicializarComboBox();

        }

        private void InicializarComboBox()
        {
            CB_SUCURSAL.ValueMember = "auto";
            CB_SUCURSAL.DisplayMember = "nombre";

            CB_DEPOSITO.ValueMember = "auto";
            CB_DEPOSITO.DisplayMember = "nombre";
        }

        public void setControlador(Controlador.GestionDocumento ctr)
        {
            _controlador = ctr;
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            salirIsOk = false;
            _controlador.Aceptar();
            if (_controlador.IsAceptarOk)
                Salir();
        }

        private void TB_DOCUMENTO_NRO_Leave(object sender, EventArgs e)
        {
            _controlador.DocumentoNro = TB_DOCUMENTO_NRO.Text.Trim().ToUpper();
        }

        private void DTP_FECHA_EIMSION_ValueChanged(object sender, EventArgs e)
        {
            _controlador.FechaEmision = DTP_FECHA_EIMSION.Value.Date;
            ActualizarFechaVencimiento();
        }

        private void ActualizarFechaVencimiento()
        {
            L_FECHA_VENCIMIENTO.Text = _controlador.FechaVencimiento.ToShortDateString();
        }

        private void TB_DIAS_CREDITO_ValueChanged(object sender, EventArgs e)
        {
            _controlador.DiasCredito = (int) TB_DIAS_CREDITO.Value;
            ActualizarFechaVencimiento();
        }

        private void TB_NOTAS_Leave(object sender, EventArgs e)
        {
            _controlador.Notas = TB_NOTAS.Text.Trim();
        }

        private void TB_CONTROL_NRO_Leave(object sender, EventArgs e)
        {
            _controlador.ControlNro = TB_CONTROL_NRO.Text.Trim().ToUpper(); 
        }

        private void TB_ORDEN_COMPRA_Leave(object sender, EventArgs e)
        {
            _controlador.OrdenCompraNro = TB_ORDEN_COMPRA.Text.Trim().ToUpper();
        }

        private void TB_FACTOR_DIVISA_Leave(object sender, EventArgs e)
        {
            _controlador.FactorDivisa = decimal.Parse(TB_FACTOR_DIVISA.Text);
        }

        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) 
                return;

            _controlador.setSucursal("");
            if (CB_SUCURSAL.SelectedIndex != -1) 
            {
                _controlador.setSucursal(CB_SUCURSAL.SelectedValue.ToString());
                CB_DEPOSITO.SelectedIndex = -1;
            }
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setDeposito("");
            if (CB_DEPOSITO.SelectedIndex != -1)
                _controlador.setDeposito(CB_DEPOSITO.SelectedValue.ToString());
        }

        private bool _modoInicializar;
        private void DatosDocumentoFrm_Load(object sender, EventArgs e)
        {
            TB_BUSCAR.Focus();
            RefrescarData();
            BT_BUSCAR_PROVEEDOR.Enabled = true;

            if (_controlador.IsAceptarOk)
            {
                CB_SUCURSAL.DataSource = _controlador.SucursalSource;
                CB_DEPOSITO.DataSource = _controlador.DepositoSource;
                CB_SUCURSAL.Enabled = !_controlador.HayItemsCargados;
                CB_DEPOSITO.Enabled = !_controlador.HayItemsCargados;
                TB_FACTOR_DIVISA.Enabled = !_controlador.HayItemsCargados;
                CB_SUCURSAL.SelectedValue  = _controlador.IdSucursal;
                CB_DEPOSITO.SelectedValue = _controlador.IdDeposito;
                BT_BUSCAR_PROVEEDOR.Enabled = !_controlador.HayItemsCargados;
            }
            else 
            {
                _modoInicializar = true;
                CB_SUCURSAL.DataSource = _controlador.SucursalSource;
                CB_DEPOSITO.DataSource = _controlador.DepositoSource;
                CB_SUCURSAL.SelectedIndex = -1;
                CB_DEPOSITO.SelectedIndex = -1;
                _modoInicializar = false;
            }
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        bool salirIsOk;
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            salirIsOk = false;
            var msg = MessageBox.Show("Abandonar Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                _controlador.LimpiarDatos();
                salirIsOk=true;
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }

        private void DatosDocumentoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_controlador.IsAceptarOk || salirIsOk)
                e.Cancel = false;
            else 
            {
                e.Cancel = true;
            }
        }

        private void BT_BUSCAR_PROVEEDOR_Click(object sender, EventArgs e)
        {
            BuscarProveedor();
        }

        private void BuscarProveedor()
        {
            _controlador.BuscarProveedor();
            TB_BUSCAR.Text = "";
            if (_controlador.ProveedorIsOk)
            {
                L_RIF.Text = _controlador.RifProveedor;
                L_RAZON_SOCIAL.Text = _controlador.RazonSocialProveedor;
                L_DIRECCION_FISCAL.Text = _controlador.DireccionProveedor;
                TB_DOCUMENTO_NRO.Focus();
            }
            else
                TB_BUSCAR.Focus();
        }

        private void TB_BUSCAR_Leave(object sender, EventArgs e)
        {
            _controlador.CadenaBuscar = TB_BUSCAR.Text.Trim().ToUpper();
        }

        private void RB_BUSCAR_POR_CODIGO_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setMetodoBusqueda(Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda.Codigo);
        }

        private void RB_BUSCAR_POR_RIF_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setMetodoBusqueda(Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda.CiRif);
        }

        private void RB_BUSCAR_POR_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setMetodoBusqueda(Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda.Nombre);
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            _controlador.LimpiarDatos();
            if (_controlador.LimpiarDatosIsOk) 
            {
                RefrescarData();
                CB_SUCURSAL.SelectedIndex = -1;
                CB_DEPOSITO.SelectedIndex = -1;
                TB_BUSCAR.Focus();
            }
        }

        private void RefrescarData()
        {
            L_RIF.Text = _controlador.RifProveedor;
            L_RAZON_SOCIAL.Text = _controlador.RazonSocialProveedor;
            L_DIRECCION_FISCAL.Text = _controlador.DireccionProveedor;

            L_REMISION.Text = "";
            L_REMISION_TIPO_DOCUMENTO.Text = "";
            L_REMISION_DOCUMENTO.Text = "";
            L_REMISION_FECHA.Text = "";
            L_REMISION_CONTROL.Text = ""; 

            DTP_FECHA_EIMSION.Value = _controlador.FechaEmision;
            TB_DOCUMENTO_NRO.Text = _controlador.DocumentoNro;
            TB_CONTROL_NRO.Text = _controlador.ControlNro;
            TB_DIAS_CREDITO.Value = _controlador.DiasCredito;
            TB_ORDEN_COMPRA.Text = _controlador.OrdenCompraNro;
            TB_FACTOR_DIVISA.Text = _controlador.FactorDivisa.ToString();
            TB_NOTAS.Text = _controlador.Notas;
            L_FECHA_VENCIMIENTO.Text = _controlador.FechaVencimiento.ToShortDateString();
            L_ANO_RELACION.Text = _controlador.AnoRelacion;
            L_MES_RELACION.Text = _controlador.MesRelacion;

            switch (_controlador.PreferenciaBusquedaProveedor)
            {
                case Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda.Codigo:
                    RB_BUSCAR_POR_CODIGO.Checked = true;
                    break;
                case Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda.CiRif:
                    RB_BUSCAR_POR_RIF.Checked = true;
                    break;
                case Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda.Nombre:
                    RB_BUSCAR_POR_NOMBRE.Checked = true;
                    break;
            }

            TB_DIAS_CREDITO.Enabled = true;
            TB_ORDEN_COMPRA.Enabled = true;
            TB_FACTOR_DIVISA.Enabled = true;
            CB_DEPOSITO.Enabled = true;
            CB_SUCURSAL.Enabled = true;
        }

        public void setActualizarDataRemision()
        {
            L_REMISION.Text = _controlador.Remision;
            L_REMISION_TIPO_DOCUMENTO.Text = _controlador.Remision_TipoDocumento;
            L_REMISION_DOCUMENTO.Text = _controlador.Remision_Documento;
            L_REMISION_FECHA.Text = _controlador.Remision_Fecha;
            L_REMISION_CONTROL.Text = _controlador.Remision_Control;
            TB_DIAS_CREDITO.Value = _controlador.DiasCredito;
            TB_FACTOR_DIVISA.Text = _controlador.FactorDivisa.ToString("n2").Replace(".", "");
            TB_ORDEN_COMPRA.Text = _controlador.OrdenCompraNro;
            TB_DIAS_CREDITO.Enabled = false;
            TB_ORDEN_COMPRA.Enabled = false;
            TB_FACTOR_DIVISA.Enabled = false;
            CB_DEPOSITO.Enabled = false;
            CB_SUCURSAL.Enabled = false;

            _modoInicializar = true;
            CB_SUCURSAL.SelectedValue=_controlador.IdSucursal ;
            CB_DEPOSITO.SelectedValue = _controlador.IdDeposito;
            _modoInicializar=false;
        }

        public void setSucursal(string p)
        {
            CB_SUCURSAL.SelectedValue = p;
        }

        public void setDeposito(string p)
        {
            CB_DEPOSITO.SelectedValue = p;
        }

    }

}
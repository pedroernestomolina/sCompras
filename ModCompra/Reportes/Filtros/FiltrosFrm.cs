using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Reportes.Filtros
{

    public partial class FiltrosFrm : Form
    {

        private IFiltrar _controlador;


        public FiltrosFrm()
        {
            InitializeComponent();
            InicializaControles();
        }

        private void InicializaControles()
        {
            CB_SUCURSAL.DisplayMember = "desc";
            CB_SUCURSAL.ValueMember = "id";
            CB_ESTATUS.DisplayMember = "desc";
            CB_ESTATUS.ValueMember = "id";
        }

        private bool _modoInicializar;
        private void FiltrosFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CB_SUCURSAL.DataSource = _controlador.GetSucursalData;
            CB_ESTATUS.DataSource = _controlador.GetEstatusData;
            CB_SUCURSAL.SelectedValue = _controlador.GetSurucrsalId;
            CB_ESTATUS.SelectedValue = _controlador.GetEstatusId;
            DTP_DESDE.Value = _controlador.GetFechaDesde;
            DTP_HASTA.Value = _controlador.GetFechaHasta;
            TB_MES_RELACION.Value = _controlador.GetMesRelacion;
            TB_ANO_RELACION.Value = _controlador.GetAnoRelacion;
            TB_PROVEEDOR.Text = _controlador.GetProveedorDesc;

            CB_ESTATUS.Enabled = _controlador.GetEstatusActivo;
            CB_SUCURSAL.Enabled = _controlador.GetSucursalActivo;
            P_MES_ANO_RELACION.Enabled = _controlador.GetMesAnoRelacionActivo;
            DTP_DESDE.Enabled= _controlador.GetFechaDesdeActivo;
            DTP_HASTA.Enabled = _controlador.GetFechaHastaActivo;
            P_PROVEEDOR.Enabled = _controlador.GetProveedorActivo;
            _modoInicializar = false;
        }

        public void setControlador(IFiltrar ctr)
        {
            _controlador = ctr;
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }
        private void LimpiarFiltros()
        {
            LImpiarEstatus();
            LimpiarFechaDesde();
            LimpiarFechaHasta();
            LimpiarSucursal();
            LimpiarMesAnoRelacion();
            LimpiarProveedor();
        }

        private void L_PROVEEDOR_Click(object sender, EventArgs e)
        {
            LimpiarProveedor();
        }
        private void LimpiarProveedor()
        {
            P_PROVEEDOR.Enabled = true;
            TB_PROVEEDOR.Text = "";
            _controlador.setProvBuscar("");
            _controlador.LimpiarProveedor();
        }
        private void L_SUCURSAL_Click(object sender, EventArgs e)
        {
            LimpiarSucursal();
        }
        private void LimpiarSucursal()
        {
            CB_SUCURSAL.SelectedIndex = -1;
        }
        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            LImpiarEstatus();
        }
        private void LImpiarEstatus()
        {
            CB_ESTATUS.SelectedIndex = -1;
        }
        private void L_DESDE_Click(object sender, EventArgs e)
        {
            LimpiarFechaDesde();
        }
        private void LimpiarFechaDesde()
        {
            DTP_DESDE.Value = _controlador.GetFechaDesde;
        }
        private void L_HASTA_Click(object sender, EventArgs e)
        {
            LimpiarFechaHasta();
        }
        private void LimpiarFechaHasta()
        {
            DTP_HASTA.Value = _controlador.GetFechaHasta;
        }
        private void L_MES_ANO_RELACION_Click(object sender, EventArgs e)
        {
            LimpiarMesAnoRelacion();
        }
        private void LimpiarMesAnoRelacion()
        {
            TB_MES_RELACION.Value = DateTime.Now.Month;
            TB_ANO_RELACION.Value = DateTime.Now.Year;
            //_controlador.LimpiarMesAnoRelacion();
        }

        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setSucursal("");
            if (CB_SUCURSAL.SelectedIndex != -1)
            {
                _controlador.setSucursal(CB_SUCURSAL.SelectedValue.ToString());
            }
        }
        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setEstatus("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.setEstatus(CB_ESTATUS.SelectedValue.ToString());
            }
        }
        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setFechaDesde(DTP_DESDE.Value);
        }
        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setFechaHasta(DTP_HASTA.Value);
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            _controlador.Salir();
            if (_controlador.SalidaIsOk)
            {
                Salir();
            }
        }
        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            _controlador.Filtrar();
            if (_controlador.FiltrarIsOk)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }

        private void TB_MES_RELACION_ValueChanged(object sender, EventArgs e)
        {
            //_controlador.setMesAnoRelacion(TB_MES_RELACION.Value, TB_ANO_RELACION.Value);
        }

        private void TB_ANO_RELACION_ValueChanged(object sender, EventArgs e)
        {
            //_controlador.setMesAnoRelacion(TB_MES_RELACION.Value, TB_ANO_RELACION.Value);
        }

        private void FiltrosFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.FiltrarIsOk || _controlador.SalidaIsOk) 
            {
                e.Cancel = false;
            }
        }

        private void TB_PROVEEDOR_Leave(object sender, EventArgs e)
        {
            _controlador.setProvBuscar(TB_PROVEEDOR.Text.Trim().ToUpper());
        }
        private void BT_PROVEEDOR_BUSCAR_Click(object sender, EventArgs e)
        {
            _controlador.BuscarProv();
            if (_controlador.BuscarProvIsOk) 
            {
                TB_PROVEEDOR.Text = _controlador.GetProveedorDesc;
                P_PROVEEDOR.Enabled = false;
            }
        }

        private void Ctrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        
    }

}
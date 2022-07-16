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

        private Gestion _controlador;


        public FiltrosFrm()
        {
            InitializeComponent();
            InicializaControles();
        }


        private void InicializaControles()
        {
            CB_SUCURSAL.DisplayMember = "Nombre";
            CB_SUCURSAL.ValueMember = "Auto";
            CB_ESTATUS.DisplayMember = "Descripcion";
            CB_ESTATUS.ValueMember = "Id";
        }

        private void FiltrosFrm_Load(object sender, EventArgs e)
        {
            CB_SUCURSAL.DataSource = _controlador.SourceSucursal;
            CB_ESTATUS.DataSource = _controlador.SourceEstatus;

            CB_ESTATUS.Enabled = _controlador.ActivarEstatus;
            CB_SUCURSAL.Enabled = _controlador.ActivarSucursal;
            TB_MES_RELACION.Enabled = _controlador.ActivarMesAnoRElacion;
            TB_ANO_RELACION.Enabled = _controlador.ActivarMesAnoRElacion;
            DTP_DESDE.Enabled= _controlador.ActivarDesde;
            DTP_HASTA.Enabled = _controlador.ActivarHasta;
            TB_PROVEEDOR.Enabled = _controlador.ActivarProveedor;
            BT_PROVEEDOR_BUSCAR.Enabled = _controlador.ActivarProveedor;
            LimpiarMesAnoRelacion();
        }

        public void setControlador(Gestion ctr)
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
            DTP_DESDE.Value = DateTime.Now.Date;
        }

        private void L_HASTA_Click(object sender, EventArgs e)
        {
            LimpiarFechaHasta();
        }

        private void LimpiarFechaHasta()
        {
            DTP_HASTA.Value = DateTime.Now.Date;
        }

        private void L_MES_ANO_RELACION_Click(object sender, EventArgs e)
        {
            LimpiarMesAnoRelacion();
        }

        private void LimpiarMesAnoRelacion()
        {
            TB_MES_RELACION.Value = DateTime.Now.Month;
            TB_ANO_RELACION.Value = DateTime.Now.Year;
            _controlador.LimpiarMesAnoRelacion();
        }

        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.setSucursal("");
            if (CB_SUCURSAL.SelectedIndex != -1)
            {
                _controlador.setSucursal(CB_SUCURSAL.SelectedValue.ToString());
            }
        }

        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.setEstatus("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.setEstatus(CB_ESTATUS.SelectedValue.ToString());
            }
        }

        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setFechaDesde(DTP_DESDE.Value);
        }

        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setFechaHasta(DTP_HASTA.Value);
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            _controlador.Filtrar();
            Salir();
        }

        private void TB_MES_RELACION_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setMesAnoRelacion(TB_MES_RELACION.Value, TB_ANO_RELACION.Value);
        }

        private void TB_ANO_RELACION_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setMesAnoRelacion(TB_MES_RELACION.Value, TB_ANO_RELACION.Value);
        }

        private void BT_PROVEEDOR_BUSCAR_Click(object sender, EventArgs e)
        {

        }
        
    }

}
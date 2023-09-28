using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Anticipos.Administrador.Vistas
{
    public partial class Frm : Form
    {
        private Vistas.IAdmAnticipo _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializarGrid();
        }
        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            var f2 = new Font("Serif", 10, FontStyle.Bold);

            DGV.Columns.Clear();
            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;

            var c0 = new DataGridViewTextBoxColumn();
            c0.DataPropertyName = "ReciboNro";
            c0.HeaderText = "Recibo Nro";
            c0.Visible = true;
            c0.Width = 80;
            c0.HeaderCell.Style.Font = f;
            c0.DefaultCellStyle.Font = f1;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "FechaMov";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "AliadoNombre";
            c2.HeaderText = "Aliado";
            c2.Visible = true;
            c2.MinimumWidth = 200;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "AliadoCiRif";
            c3.HeaderText = "CiRif";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Monto";
            c4.HeaderText = "Monto $";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.Width = 100;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Estatus";
            c5.HeaderText= "Estatus";
            c5.Name = "Estatus";
            c5.Visible = true;
            c5.Width = 80;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c0);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
        }
        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["Estatus"].Value.ToString().Trim() !="")
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex != -1 && e.RowIndex != -1)
            //{
            //    SeleccionarItem();
            //}
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            L_TITULO.Text = _controlador.Get_TituloAdm;
            DGV.DataSource = _controlador.data.Get_Source;
            DGV.Refresh();

            DTP_DESDE.Checked = _controlador.filtros.Get_IsActivoDesde;
            DTP_HASTA.Checked = _controlador.filtros.Get_IsActivoHasta;
            DTP_DESDE.Value = _controlador.filtros.Get_Desde;
            DTP_HASTA.Value = _controlador.filtros.Get_Hasta;
            Actualizar();

            //CB_SUCURSAL.DataSource = _controlador.SucursalSource;
            //CB_SUCURSAL.SelectedIndex = -1;
            //CB_TIPO_DOC.DataSource = _controlador.TipoDocSource;
            //CB_TIPO_DOC.SelectedIndex = -1;
        }
        public void setControlador(Vistas.IAdmAnticipo ctr)
        {
            _controlador = ctr;
        }


        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            if (DTP_DESDE.Checked)
            {
                _controlador.filtros.setDesde(DTP_DESDE.Value);
                _controlador.filtros.ActivarDesde(true);
            }
            else 
            {
                _controlador.filtros.ActivarDesde(false);
            }
        }
        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            if (DTP_HASTA.Checked)
            {
                _controlador.filtros.setHasta(DTP_HASTA.Value);
                _controlador.filtros.ActivarHasta(true);
            }
            else 
            {
                _controlador.filtros.ActivarHasta(false);
            }
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }


        private void BT_LIMPIAR_FILTROS_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }
        private void BT_LIMPIAR_DATA_Click(object sender, EventArgs e)
        {
            LimpiarData();
        }
        private void BT_VISUALIZAR_ANU_Click(object sender, EventArgs e)
        {
            VisualizarAnulacion();
        }
        private void BT_VISUALIZAR_Click(object sender, EventArgs e)
        {
            VisualizarDocumento();
        }
        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            Imprimir();
        }
        private void BT_ANULAR_Click(object sender, EventArgs e)
        {
            AnularItem();
        }


        private void LimpiarFiltros()
        {
            _controlador.filtros.Limpiar();
            ActualizarPant();
            //DTP_DESDE.Value = DateTime.Now;
            //DTP_HASTA.Value = DateTime.Now;
            //CB_SUCURSAL.SelectedIndex = -1;
            //CB_TIPO_DOC.SelectedIndex = -1;
            //TB_CADENA_BUS_PROV.Text = "";
            //LimpiarProveedor();
        }
        private void LimpiarData()
        {
            _controlador.data.LimpiarData();
            Actualizar();
        }
        private void Buscar()
        {
            _controlador.Buscar();
            Actualizar();
        }
        private void SeleccionarItem()
        {
            //_controlador.SeleccionarItem();
        }
        private void VisualizarDocumento()
        {
            _controlador.VisualizarDocumento();
        }
        private void Imprimir()
        {
            _controlador.Imprimir();
        }
        private void VisualizarAnulacion()
        {
            //_controlador.VisualizarAnulacion();
        }
        private void AnularItem()
        {
            _controlador.AnularItem();
            DGV.Refresh();
        }
        private void Salir()
        {
            this.Close();
        }
        private void Actualizar()
        {
            L_ITEMS.Text = "Items Encontrados: " + _controlador.Get_CntItem.ToString(); ;
        }
        private void ActualizarPant()
        {
            DTP_DESDE.Checked = _controlador.filtros.Get_IsActivoDesde;
            DTP_HASTA.Checked = _controlador.filtros.Get_IsActivoHasta;
            DTP_DESDE.Value = _controlador.filtros.Get_Desde;
            DTP_HASTA.Value = _controlador.filtros.Get_Hasta;
        }
    }
}



//private void BT_BUSCAR_PROVEEDOR_Click(object sender, EventArgs e)
//{
//    BuscarProveedor();
//}
//private void BuscarProveedor()
//{
//    _controlador.BuscarProveedor();
//    TB_CADENA_BUS_PROV.Text = _controlador.Proveedor;
//}

//private void TB_CADENA_BUS_PROV_Leave(object sender, EventArgs e)
//{
//    _controlador.setCadenaBusProv(TB_CADENA_BUS_PROV.Text.Trim().ToUpper());
//}

//private void L_PROVEEDOR_Click(object sender, EventArgs e)
//{
//    LimpiarProveedor();
//}

//private void LimpiarProveedor()
//{
//    TB_CADENA_BUS_PROV.Text = "";
//    _controlador.setCadenaBusProv("");
//    _controlador.LimpiarProveedor();
//}


//private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
//{
//    _controlador.setFechaDesde(DTP_DESDE.Value);
//}

//private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
//{
//    _controlador.setFechaHasta(DTP_HASTA.Value);
//}

//private void CB_TIPO_DOC_SelectedIndexChanged(object sender, EventArgs e)
//{
//    _controlador.setTipoDoc("");
//    if (CB_TIPO_DOC.SelectedIndex!=-1)
//    {
//        _controlador.setTipoDoc(CB_TIPO_DOC.SelectedValue.ToString());
//    }
//}

//private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
//{
//    _controlador.setSucursal("");
//    if (CB_SUCURSAL.SelectedIndex != -1)
//    {
//        _controlador.setSucursal(CB_SUCURSAL.SelectedValue.ToString());
//    }
//}

//private void L_TIPO_DOC_Click(object sender, EventArgs e)
//{
//    CB_TIPO_DOC.SelectedIndex = -1;
//}

//private void L_SUCURSAL_Click(object sender, EventArgs e)
//{
//    CB_SUCURSAL.SelectedIndex = -1;
//}
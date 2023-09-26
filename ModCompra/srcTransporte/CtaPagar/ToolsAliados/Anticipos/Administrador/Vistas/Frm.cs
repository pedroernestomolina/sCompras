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
            InicializarCombos();
        }
        private void InicializarCombos()
        {
            CB_SUCURSAL.DisplayMember = "Nombre";
            CB_SUCURSAL.ValueMember = "Auto";
            CB_TIPO_DOC.DisplayMember = "Descripcion";
            CB_TIPO_DOC.ValueMember = "Id";
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

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Fecha";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "NombreDoc";
            c2.HeaderText = "Tipo";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Documento";
            c3.HeaderText = "Documento";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c3B = new DataGridViewTextBoxColumn();
            c3B.DataPropertyName = "Control";
            c3B.HeaderText = "Control";
            c3B.Visible = true;
            c3B.Width = 100;
            c3B.HeaderCell.Style.Font = f;
            c3B.DefaultCellStyle.Font = f1;

            var cA = new DataGridViewTextBoxColumn();
            cA.DataPropertyName = "Aplica";
            cA.HeaderText = "Aplica";
            cA.Visible = true;
            cA.Width = 100;
            cA.HeaderCell.Style.Font = f;
            cA.DefaultCellStyle.Font = f1;

            var c3A = new DataGridViewTextBoxColumn();
            c3A.DataPropertyName = "FechaReg";
            c3A.HeaderText = "Fecha/Reg";
            c3A.Visible = true;
            c3A.Width = 80;
            c3A.HeaderCell.Style.Font = f;
            c3A.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Sucursal";
            c4.HeaderText = "Sucursal";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c4.Width = 180;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "ProvNombre";
            c5.HeaderText = "Proveedor";
            c5.Visible = true;
            c5.MinimumWidth = 220;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c5A = new DataGridViewTextBoxColumn();
            c5A.DataPropertyName = "ProvCiRif";
            c5A.HeaderText = "Ci/Rif";
            c5A.Visible = true;
            c5A.Width = 90;
            c5A.HeaderCell.Style.Font = f;
            c5A.DefaultCellStyle.Font = f1;
            
            var c9 = new DataGridViewTextBoxColumn();
            c9.DataPropertyName = "Signo";
            c9.HeaderText = "+/-";
            c9.Visible = true;
            c9.Width = 40;
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f2;
            c9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c5B = new DataGridViewTextBoxColumn();
            c5B.DataPropertyName = "Importe";
            c5B.HeaderText = "Importe";
            c5B.Visible = true;
            c5B.Width = 120;
            c5B.HeaderCell.Style.Font = f;
            c5B.DefaultCellStyle.Font = f1;
            c5B.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5B.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "ImporteDivisa";
            c6.HeaderText = "Importe $";
            c6.Visible = true;
            c6.Width = 90;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "Situacion";
            c7.Name = "Situacion";
            c7.HeaderText = "Situación";
            c7.Visible = true;
            c7.Width = 80;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "IsAnulado";
            c8.Name = "IsAnulado";
            c8.Visible = false;
            c8.Width = 0;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;

            var c8A = new DataGridViewTextBoxColumn();
            c8A.DataPropertyName = "Estatus";
            c8A.HeaderText= "Estatus";
            c8A.Name = "Anulado";
            c8A.Visible = true;
            c8A.Width = 80;
            c8A.HeaderCell.Style.Font = f;
            c8A.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c3B);
            DGV.Columns.Add(cA);
            DGV.Columns.Add(c3A);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c5A);
            DGV.Columns.Add(c9);
            DGV.Columns.Add(c5B);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c8);
            DGV.Columns.Add(c8A);
        }
        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if ((bool)row.Cells["IsAnulado"].Value == true)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                SeleccionarItem();
            }
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            L_TITULO.Text = _controlador.Get_TituloAdm;
            DGV.DataSource = _controlador.data.Get_Source;
            DGV.Refresh();
            Actualizar();

            //DTP_DESDE.Value = _controlador.FechaDesde;
            //DTP_HASTA.Value = _controlador.FechaHasta;
            //TB_CADENA_BUS_PROV.Text = _controlador.Proveedor;

            //CB_SUCURSAL.DataSource = _controlador.SucursalSource;
            //CB_SUCURSAL.SelectedIndex = -1;
            //CB_TIPO_DOC.DataSource = _controlador.TipoDocSource;
            //CB_TIPO_DOC.SelectedIndex = -1;

            //switch (_controlador.TipoAdministrador)
            //{
            //    case enumerados.EnumTipoAdministrador.AdmDocumentos:
            //        InicializarGrid_1();
            //        break;
            //}

            //DGV.Columns[0].Frozen = true;
            //DGV.Columns[1].Frozen = true;
            //DGV.Columns[2].Frozen = true;
            //DGV.Columns[3].Frozen = true;
        }
        public void setControlador(Vistas.IAdmAnticipo ctr)
        {
            _controlador = ctr;
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
        private void BT_CORRECTOR_Click(object sender, EventArgs e)
        {
            CorrectorDocumentos();
        }
        private void BT_ANULAR_Click(object sender, EventArgs e)
        {
            AnularItem();
        }


        private void CorrectorDocumentos()
        {
            //_controlador.CorrectorDocumentos();
        }
        private void LimpiarFiltros()
        {
            //_controlador.LimpiarFiltros();
            //DTP_DESDE.Value = DateTime.Now;
            //DTP_HASTA.Value = DateTime.Now;
            //CB_SUCURSAL.SelectedIndex = -1;
            //CB_TIPO_DOC.SelectedIndex = -1;
            //TB_CADENA_BUS_PROV.Text = "";
            //LimpiarProveedor();
        }
        private void LimpiarData()
        {
            //_controlador.LimpiarData();
            //Actualizar();
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
            //_controlador.VisualizarDocumento();
        }
        private void Imprimir()
        {
            //_controlador.Imprimir();
        }
        private void VisualizarAnulacion()
        {
            //_controlador.VisualizarAnulacion();
        }
        private void AnularItem()
        {
            //_controlador.AnularItem();
        }
        private void Salir()
        {
            this.Close();
        }
        private void Actualizar()
        {
            L_ITEMS.Text = "Items Encontrados: " + _controlador.Get_CntItem.ToString(); ;
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
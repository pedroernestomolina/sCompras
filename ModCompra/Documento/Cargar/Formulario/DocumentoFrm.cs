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

    public partial class DocumentoFrm : Form
    {


        private Controlador.Gestion _controlador;


        public DocumentoFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

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
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DescripcionPrd";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.MinimumWidth = 180;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Cnt";
            c3.HeaderText = "Cant/Fact";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c3B = new DataGridViewTextBoxColumn();
            c3B.DataPropertyName = "CntDev";
            c3B.HeaderText = "Cant/Dev";
            c3B.Visible = true;
            c3B.Width = 80;
            c3B.HeaderCell.Style.Font = f;
            c3B.DefaultCellStyle.Font = f1;
            c3B.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "EmpaqueCont";
            c4.HeaderText = "Empaque";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.Width = 100;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "CostoCompra";
            c5.HeaderText = "Costo Bs";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c5b = new DataGridViewTextBoxColumn();
            c5b.DataPropertyName = "CostoDivisaCompra";
            c5b.HeaderText = "Costo $";
            c5b.Visible = true;
            c5b.Width = 80;
            c5b.HeaderCell.Style.Font = f;
            c5b.DefaultCellStyle.Font = f1;
            c5b.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5b.DefaultCellStyle.Format = "n2";

            var c6a = new DataGridViewTextBoxColumn();
            c6a.DataPropertyName = "Dsct_1_p";
            c6a.HeaderText = "Dsc 1";
            c6a.Visible = true;
            c6a.Width = 70;
            c6a.HeaderCell.Style.Font = f;
            c6a.DefaultCellStyle.Font = f1;
            c6a.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6a.DefaultCellStyle.Format = "n2";

            var c6b = new DataGridViewTextBoxColumn();
            c6b.DataPropertyName = "Dsct_2_p";
            c6b.HeaderText = "Dsc 2";
            c6b.Visible = true;
            c6b.Width = 70;
            c6b.HeaderCell.Style.Font = f;
            c6b.DefaultCellStyle.Font = f1;
            c6b.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6b.DefaultCellStyle.Format = "n2";

            var c6c = new DataGridViewTextBoxColumn();
            c6c.DataPropertyName = "Dsct_3_p";
            c6c.HeaderText = "Dsc 3";
            c6c.Visible = true;
            c6c.Width = 70;
            c6c.HeaderCell.Style.Font = f;
            c6c.DefaultCellStyle.Font = f1;
            c6c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6c.DefaultCellStyle.Format = "n2";

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "Importe";
            c7.HeaderText = "Neto";
            c7.Visible = true;
            c7.Width = 120;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n2";

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "TasaIvaPrd";
            c8.HeaderText = "Iva";
            c8.Visible = true;
            c8.Width = 60;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c8.DefaultCellStyle.Format = "n2";

            var c9 = new DataGridViewTextBoxColumn();
            c9.DataPropertyName = "Impuesto";
            c9.HeaderText = "Impuesto";
            c9.Visible = true;
            c9.Width = 120;
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f1;
            c9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c9.DefaultCellStyle.Format = "n2";

            var c10 = new DataGridViewTextBoxColumn();
            c10.DataPropertyName = "Total";
            c10.HeaderText = "Total";
            c10.Visible = true;
            c10.Width = 120;
            c10.HeaderCell.Style.Font = f;
            c10.DefaultCellStyle.Font = f1;
            c10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c10.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c3B);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c5b);
            DGV.Columns.Add(c6a);
            DGV.Columns.Add(c6b);
            DGV.Columns.Add(c6c);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c8);
            DGV.Columns.Add(c9);
            DGV.Columns.Add(c10);
        }

        private void DocumentoFrm_Load(object sender, EventArgs e)
        {
            Inicializar_1();
            DGV.Columns[0].Frozen = true;
            DGV.Columns[1].Frozen = true;
            DGV.Columns[2].Frozen = true;
            DGV.Columns[3].Visible = _controlador.VisualizarColDevolucion;
            DGV.DataSource = _controlador.ItemSource;
            BT_PENDIENTE_DEJAR.Text = "Pendiente " + _controlador.CntPend;
        }

        private void Inicializar_1()
        {
            PANEL_DOCUMENTO.BackColor = _controlador.ColorFondoDocumento;
            L_TITULO_DOCUMENTO.Text = _controlador.TituloDocumento;
            switch (_controlador.MetodoBusquedaProducto) 
            {
                case Controlador.GestionProductoBuscar.metodoBusqueda.Codigo:
                    RB_BUSCAR_POR_CODIGO.Checked = true;
                    ActivarBusquedaProductoPorCodigo();
                    break;
                case Controlador.GestionProductoBuscar.metodoBusqueda.Nombre:
                    RB_BUSCAR_POR_NOMBRE.Checked = true;
                    ActivarBusquedaProductoPorNombre();
                    break;
                case Controlador.GestionProductoBuscar.metodoBusqueda.Referencia:
                    RB_BUSCAR_POR_REFERENCIA.Checked = true;
                    ActivarBusquedaProductoPorReferencia();
                    break;
            }
            ActualizarDatosDocumento();
            ActualizarDatosTotales();
            ActualizarDatosItem();
        }

        public void ActualizarDatosItem()
        {
            L_ITEM_PRODUCTO.Text = _controlador.Item_Producto;
            L_ITEM_IMPORTE.Text = _controlador.Item_Importe.ToString("n2");
            L_ITEM_IMPUESTO.Text = _controlador.Item_Impuesto.ToString("n2");
            L_ITEM_TOTAL.Text = _controlador.Item_Total.ToString("n2");
            L_ITEM_CANTIDAD.Text = _controlador.Item_Cantidad.ToString("n2");
            L_ITEM_CANTIDAD_UND.Text = _controlador.Item_CantidadUnd.ToString("n2");
            L_ITEM_COSTO_MONEDA.Text = _controlador.Item_CostoMoneda.ToString("n2");
            L_ITEM_COSTO_MONEDA_UND.Text = _controlador.Item_CostoMonedaUnd.ToString("n2");
            L_ITEM_COSTO_DIVISA.Text = _controlador.Item_CostoDivisa.ToString("n2");
            L_ITEM_COSTO_DIVISA_UND.Text = _controlador.Item_CostoDivisaUnd.ToString("n2");
            L_ITEM_EMPQ_PRD.Text = _controlador.Item_EmpaqueCont;
            L_ITEM_COD_REF_PRV.Text = _controlador.Item_CodRefPrv;
            L_ITEM_DSCTO.Text = _controlador.Item_Dscto.ToString("n2"); 
        }

        private void ActualizarDatosTotales()
        {
            L_TOTAL.Text = _controlador.Total.ToString("n2");
            L_IVA.Text = _controlador.MontoIva.ToString("n2");
            L_DIVISA.Text = _controlador.MontoDivisa.ToString("n2");
            L_ITEMS.Text = _controlador.Items.ToString("n0");
        }

        public void setControlador(Controlador.Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_NUEVO_Click(object sender, EventArgs e)
        {
            NuevoDocumento();
        }

        private void NuevoDocumento()
        {
            _controlador.NuevoDocumento();
            ActualizarDatosDocumento();
            if (_controlador.DatosDocumentoIsOk)
            {
                ActualizarDatosItem();
                ActualizarDatosTotales();
                IniciarBusqueda();
            }
        }

        private void ActualizarDatosDocumento()
        {
            BT_PENDIENTE_DEJAR.Text = "Pendiente " + _controlador.CntPend;
            L_PROVEEDOR.Text = _controlador.Proveedor;
            L_FECHA_EMISION.Text = _controlador.FechaEmision.ToShortDateString();
            L_DOCUMENTO.Text = _controlador.DocumentoNro;
            L_CONTROL_NRO.Text = _controlador.ControlNro;
            L_FECHA_VENC.Text = _controlador.FechaVencimiento.ToShortDateString();
            L_FACTOR_DIVISA.Text = _controlador.FactorDivisa.ToString("n2");
            L_DEPOSITO.Text = _controlador.Deposito;
            L_SUCURSAL.Text = _controlador.Sucursal;
        }

        private void BT_EDITAR_ITEM_Click(object sender, EventArgs e)
        {
            EditarItem();
        }

        private void EditarItem()
        {
            _controlador.EditarItem();
            ActualizarDatosTotales();
            IniciarBusqueda();
        }

        private void BT_ELIMINAR_ITEM_Click(object sender, EventArgs e)
        {
            EliminarItem();
        }

        private void EliminarItem()
        {
            _controlador.EliminarItem();
            ActualizarDatosTotales();
            IniciarBusqueda();
        }

        private void BT_LIMPIAR_ITEMS_Click(object sender, EventArgs e)
        {
            LimpiarItems();
        }

        private void LimpiarItems()
        {
            _controlador.LimpiarItems();
            ActualizarDatosTotales();
            IniciarBusqueda();
        }

        private void BT_BUSCAR_PRODUCTO_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void BuscarProducto()
        {
            _controlador.BuscarProducto();
            ActualizarDatosTotales();
            IniciarBusqueda();
        }

        private void IniciarBusqueda()
        {
            TB_CADENA_BUSQ.Text = "";
            TB_CADENA_BUSQ.Focus();
        }

        private void RB_BUSCAR_POR_CODIGO_CheckedChanged(object sender, EventArgs e)
        {
            ActivarBusquedaProductoPorCodigo();
        }

        private void ActivarBusquedaProductoPorCodigo()
        {
            _controlador.ActivarBusquedaProductoPorCodigo();
            IniciarBusqueda();
        }

        private void RB_BUSCAR_POR_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            ActivarBusquedaProductoPorNombre();
        }

        private void ActivarBusquedaProductoPorNombre()
        {
            _controlador.ActivarBusquedaProductoPorNombre();
            IniciarBusqueda();
        }

        private void RB_BUSCAR_POR_REFERENCIA_CheckedChanged(object sender, EventArgs e)
        {
            ActivarBusquedaProductoPorReferencia();
        }

        private void ActivarBusquedaProductoPorReferencia()
        {
            _controlador.ActivarBusquedaProductoPorReferencia();
            IniciarBusqueda();
        }

        private void TB_CADENA_BUSQ_Leave(object sender, EventArgs e)
        {
            _controlador.CadenaPrdBuscar=TB_CADENA_BUSQ.Text.Trim().ToUpper();
        }

        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            _controlador.Salir();
        }

        private void DocumentoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.SalidaOk)
            {
                e.Cancel = false;
            }
            else 
                IniciarBusqueda();
        }

        private void BT_LIMPIAR_DOCUMENTO_Click(object sender, EventArgs e)
        {
            LimpiarDocumento();
        }

        private void LimpiarDocumento()
        {
            _controlador.LimpiarDocumento();
            ActualizarDatosDocumento();
            ActualizarDatosTotales();
            DGV.Refresh();
            IniciarBusqueda();
        }

        private void BT_TOTALIZAR_Click(object sender, EventArgs e)
        {
            Totalizar();
        }

        private void Totalizar()
        {
            _controlador.Totalizar();
        }

        private void BT_IMPORTAR_DOC_Click(object sender, EventArgs e)
        {
            ImportarDoc();
        }

        private void ImportarDoc()
        {
            _controlador.ImportarDoc();
            ActualizarDatosTotales();
            DGV.Refresh();
            IniciarBusqueda();
        }

        private void BT_EDITAR_DOC_Click(object sender, EventArgs e)
        {
            EditarDoc();
        }

        private void EditarDoc()
        {
            _controlador.EditarDoc();
            ActualizarDatosDocumento();
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) 
            {
                EliminarItem();
            }
        }

        private void BT_PENDIENTE_DEJAR_Click(object sender, EventArgs e)
        {
            DejarPendiente();
        }

        private void DejarPendiente()
        {
            _controlador.DejarPendiente();
            if (_controlador.DejarPendienteIsOk) 
            {
                ActualizarDatosDocumento();
                ActualizarDatosTotales();
                DGV.Refresh();
                IniciarBusqueda();
            }
        }

        private void BT_PENDIENTE_ABRIR_Click(object sender, EventArgs e)
        {
            AbrirPendiente();
        }

        private void AbrirPendiente()
        {
            _controlador.AbrirPendiente();
            if (_controlador.AbrirPendienteIsOk)
            {
                ActualizarDatosDocumento();
                if (_controlador.DatosDocumentoIsOk)
                {
                    ActualizarDatosItem();
                    ActualizarDatosTotales();
                    IniciarBusqueda();
                }
            }
        }

    }

}
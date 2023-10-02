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
            DGV.RowHeadersVisible = false;
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
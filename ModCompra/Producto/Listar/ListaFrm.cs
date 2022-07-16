using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Producto.Listar
{
    
    public partial class ListaFrm : Form
    {


        Gestion _controlador;

    
        public ListaFrm()
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
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Código";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 120;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Nombre";
            c2.HeaderText = "Descripción";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 280;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "TasaIva";
            c3.HeaderText = "Iva";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.Width = 60;

            var c4 = new DataGridViewTextBoxColumn();
            c4.Name = "VEstatus";
            c4.HeaderText = "*";
            c4.Visible = true;
            c4.Width = 60;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f;
            c4.DefaultCellStyle.BackColor = Color.Green;
            c4.DefaultCellStyle.ForeColor = Color.White;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "isActivo";
            c5.Name = "Estatus";
            c5.Visible = false;
            c5.Width = 0;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void ListaFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            L_ITEMS.Text = _controlador.TItems.ToString("n0");
        }


        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                SeleccionarItem();
            }
        }

        private void SeleccionarItem()
        {
            _controlador.SeleccionarItem();
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                var xcolor = Color.Green;
                var xestatus = "Activo";

                if ((bool)row.Cells["Estatus"].Value== false)
                {
                    xcolor = Color.Red;
                    xestatus = "Inactivo";
                }
                row.Cells["VEstatus"].Style.BackColor = xcolor;
                row.Cells["VEstatus"].Value = xestatus;
            }
        }

    }

}
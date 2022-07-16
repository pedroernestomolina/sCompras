using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.NotaCredito.Remision
{

    public partial class RemisionFrm : Form
    {


        private Gestion _controlador;


        public RemisionFrm()
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
            c1.DataPropertyName = "FechaEmision";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DocNombre";
            c2.HeaderText = "Tipo";
            c2.Visible = true;
            c2.MinimumWidth = 110;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "DocNro";
            c3.HeaderText = "Documento";
            c3.Visible = true;
            c3.MinimumWidth= 110;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Control";
            c4.HeaderText = "Control";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.Width = 110;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Total";
            c5.HeaderText = "Importe";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c5b = new DataGridViewTextBoxColumn();
            c5b.DataPropertyName = "MontoDivisa";
            c5b.HeaderText = "Importe $";
            c5b.Visible = true;
            c5b.Width = 110;
            c5b.HeaderCell.Style.Font = f;
            c5b.DefaultCellStyle.Font = f1;
            c5b.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5b.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c5b);
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void RemisionFrm_Load(object sender, EventArgs e)
        {
            L_ITEMS.Text = _controlador.ItemEncontrados;
            L_PROVEEDOR.Text = _controlador.Proveedor;
            DGV.DataSource = _controlador.Source;
            DGV.Refresh();
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

    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Pendiente
{

    public partial class ListaFrm : Form
    {


        private Gestion _controlador;

    
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
            c1.DataPropertyName = "entidadCiRif";
            c1.HeaderText = "Rif";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 120;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "entidadNombre";
            c2.HeaderText = "Nombre / Razon Social";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 280;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "docNumero";
            c3.HeaderText = "DOC/Nro";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.Width = 110;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "docControl";
            c4.HeaderText = "DOC/Control";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.Width = 110;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "docFecha";
            c5.HeaderText = "De Fecha";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.Width = 110;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "docNombre";
            c6.HeaderText = "DOC/TIPO";
            c6.Visible = true;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.Width = 110;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "montoDivisa";
            c7.HeaderText = "MONTO $";
            c7.Visible = true;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Format="n2";
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.Width = 110;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c7);
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
            if (_controlador.IsItemSeleccionadoOk) 
            {
                this.Close();
            }
        }

    }

}
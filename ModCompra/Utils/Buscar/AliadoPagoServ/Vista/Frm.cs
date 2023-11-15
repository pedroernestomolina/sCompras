using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Utils.Buscar.AliadoPagoServ.Vista
{
    public partial class Frm : Form
    {
        IHnd _controlador;

    
        public Frm()
        {
            InitializeComponent();
            InicializarGrid();
        }
        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

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

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "ERecibo";
            c1.HeaderText = "Recibo Nro";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 90;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "EFecha";
            c2.HeaderText = "Fecha";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.Width = 80;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "EImporte";
            c3.HeaderText = "Importe";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.Width = 100;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "ECntServPag";
            c4.HeaderText = "Cnt/Serv";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.Width = 60;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "EMotivo";
            c5.HeaderText = "Motivo / Descripcion";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.MinimumWidth = 280;
            c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c5);
        }

        
        private void Frm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Get_Data;
            L_ITEMS.Text = _controlador.Get_CntItem.ToString("n0");
        }
        public void setControlador(IHnd ctr)
        {
            _controlador = ctr;
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
            if (_controlador.ItemSeleccionadoIsOk) 
            {
                salir();
            }
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }

        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOK) 
            {
                salir();
            }
        }
        private void salir()
        {
            this.Close();
        }
    }
}
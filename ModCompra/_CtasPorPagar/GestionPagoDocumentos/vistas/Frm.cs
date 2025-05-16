using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtasPorPagar.GestionPagoDocumentos.vistas
{
    public partial class Frm: Form
    {
        private interfaces.IPanel _controlador;
        //
        private void InicializaGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            //
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
            //
            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "docFechaEmision";
            c1.HeaderText = "Fecha/Doc";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 80;
            //
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "docTipo";
            c2.HeaderText = "Tipo/Doc";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "docNumero";
            c3.HeaderText = "Documento";
            c3.Visible = true;
            c3.MinimumWidth = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "docFechaVence";
            c4.HeaderText = "Fecha/Vto";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "diasVencida";
            c5.HeaderText = "Dias/Venc";
            c5.Visible = true;
            c5.Width = 80;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Importe";
            c6.HeaderText = "Importe";
            c6.Visible = true;
            c6.Width = 100;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";
            //
            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "Resta";
            c8.HeaderText = "Resta";
            c8.Visible = true;
            c8.Width = 100;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c8.DefaultCellStyle.Format = "n2";
            //
            var c9 = new DataGridViewTextBoxColumn();
            c9.DataPropertyName = "MontoAAbonar";
            c9.HeaderText = "Abonado";
            c9.Visible = true;
            c9.Width = 100;
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f;
            c9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c9.DefaultCellStyle.Format = "n3";
            //
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c8);
            DGV.Columns.Add(c9);
        }
        public Frm()
        {
            InitializeComponent();
            InicializaGrid();
        }
        public void setControlador(interfaces.IPanel ctr)
        {
            _controlador = ctr;
        }
        private bool _modoInicializar;
        private void Frm_Load(object sender, EventArgs e)
        {
            var _bs = (BindingSource)_controlador.GetDataSource;
            if (_bs != null) 
            {
                _bs.CurrentChanged += _bs_CurrentChanged;
            }
            _modoInicializar = true;
            DGV.DataSource = _bs;
            L_TITULO.Text = _controlador.GetTituloFrm;
            ActualizarDataPanel();
            _modoInicializar = false;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK)
            {
                e.Cancel = false;
            }
        }
        private void _bs_CurrentChanged(object sender, EventArgs e)
        {
            L_NOTAS.Text = _controlador.GetNotasAbono;
        }
        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                AbonarCta();
            }
        }
        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarAbonos();
        }
        private void BT_VISUALIZAR_Click(object sender, EventArgs e)
        {
            VisualizarDocumento();
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void TSM_SALIDA_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        //
        private void ActualizarDataPanel()
        {
            L_ENTIDAD_DATA.Text = _controlador.GetEntidadInfo;
            L_CNT_DOC_PENDIENTE.Text = _controlador.GetCntDocPendiente.ToString("n0");
            L_MONTO_PENDIENTE.Text = _controlador.GetMontoPendiente.ToString("n2");
            L_MONTO_ABONADO.Text = _controlador.GetMontoAbonado.ToString("n3");
            L_CNT_DOC_ABONADO.Text = _controlador.GetCntDocAbonado.ToString("n0");
            L_NOTAS.Text = _controlador.GetNotasAbono;
        }
        private void AbonarCta()
        {
            _controlador.AbonarCta();
            ActualizarDataPanel();
        }
        private void VisualizarDocumento()
        {
            _controlador.VisualizarDocumento();
        }
        private void LimpiarAbonos()
        {
            _controlador.LimpiarAbonos();
            ActualizarDataPanel();
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
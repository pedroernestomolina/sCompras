using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtasPorPagar.PanelPrincipal._Inicio.vistas
{
    public partial class Frm : Form
    {
        private CultureInfo _cult;
        private interfaces.IPanelPrincipal _controlador;
        //
        private void InicializaDGV_1()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            //
            DGV_1.RowHeadersVisible = false;
            DGV_1.AllowUserToAddRows = false;
            DGV_1.AllowUserToDeleteRows = false;
            DGV_1.AutoGenerateColumns = false;
            DGV_1.AllowUserToResizeRows = false;
            DGV_1.AllowUserToResizeColumns = false;
            DGV_1.AllowUserToOrderColumns = false;
            DGV_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_1.MultiSelect = false;
            DGV_1.ReadOnly = true;
            //
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "CiRifEntidad";
            c4.HeaderText = "CI/RIF";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.Width = 100;
            //
            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "NombreEntidad";
            c5.HeaderText = "Nombre/Razón Social";
            c5.Visible = true;
            c5.Width = 180;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "MontoDeuda";
            c6.HeaderText = "Importe";
            c6.Visible = true;
            c6.MinimumWidth = 90;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";
            //
            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "MontoCredito";
            c7.HeaderText = "Credito";
            c7.Visible = true;
            c7.Width = 90;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n2";
            //
            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "MontoAcumulado";
            c8.HeaderText = "Acumulado";
            c8.Visible = true;
            c8.Width = 90;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c8.DefaultCellStyle.Format = "n2";
            //
            var c9 = new DataGridViewTextBoxColumn();
            c9.DataPropertyName = "MontoPendiente";
            c9.HeaderText = "Resta";
            c9.Visible = true;
            c9.Width = 90;
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f;
            c9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c9.DefaultCellStyle.Format = "n2";
            //
            var ca = new DataGridViewTextBoxColumn();
            ca.DataPropertyName = "CntDocDeuda";
            ca.HeaderText = "CntDoc";
            ca.Visible = true;
            ca.Width = 60;
            ca.HeaderCell.Style.Font = f;
            ca.DefaultCellStyle.Font = f;
            ca.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ca.DefaultCellStyle.Format = "n0";
            //
            DGV_1.Columns.Add(c4);
            DGV_1.Columns.Add(c5);
            DGV_1.Columns.Add(c6);
            DGV_1.Columns.Add(ca);
            DGV_1.Columns.Add(c7);
            DGV_1.Columns.Add(c8);
            DGV_1.Columns.Add(c9);
        }
        public Frm()
        {
            _cult = CultureInfo.CurrentCulture;
            InitializeComponent();
            InicializaDGV_1();
        }
        public void setControlador(interfaces.IPanelPrincipal ctr)
        {
            _controlador = ctr;
        }
        private bool _modoInicializar;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            L_TITULO_TOOLS.Text = _controlador.GetTituloPanel;
            DGV_1.DataSource = _controlador.GetDataSource;
            ActualizarPanel_Totales();
            FocoPrincipal();
            _modoInicializar = false;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarFichaIsOK)
            {
                e.Cancel = false;
            }
        }
        private void CTrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        //
        private void TB_BUSCAR_Leave(object sender, EventArgs e)
        {
            var _texto= TB_BUSCAR.Text.Trim().ToUpper();
            _controlador.setTextoBuscar(_texto);
        }
        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarCtasPendientes();
        }
        private void BT_LISTA_CTAS_PEND_Click(object sender, EventArgs e)
        {
            Proveedor_CtasPend();
        }
        private void BT_REPORTE_CTAS_Click(object sender, EventArgs e)
        {
            Reporte_CtasPendiente_General();
        }
        private void BT_AGREGAR_PAGO_Click(object sender, EventArgs e)
        {
            GestionPago();
        }
        private void BT_ADM_DOC_PAGO_Click(object sender, EventArgs e)
        {
            AdmDocPagos();
        }
        private void TSM_ARCHIVO_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        //
        private void FocoPrincipal()
        {
            TB_BUSCAR.Text = _controlador.GetTextoBuscar;
            TB_BUSCAR.Focus();
        }
        private void ActualizarPanel_Totales()
        {
            L_CNT_ITEM.Text = "Cant Items: " + _controlador.GetCntItems.ToString("n0");
            L_MONTO_PENDIENTE.Text = _controlador.GetMontoPendiente.ToString("n2", _cult);
        }
        private void BuscarCtasPendientes()
        {
            _controlador.BuscarCtasPendientes();
            ActualizarPanel_Totales();
            FocoPrincipal();
        }
        private void Proveedor_CtasPend()
        {
            _controlador.Proveedor_CtasPend();
        }
        private void Reporte_CtasPendiente_General()
        {
            _controlador.Reporte_CtasPendiente_General();
        }
        private void GestionPago()
        {
            _controlador.GestionPago();
            ActualizarPanel_Totales();
        }
        private void AdmDocPagos()
        {
            _controlador.AdmDocPagos();
            ActualizarPanel_Totales();
        }
        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarFichaIsOK)
            {
                salir();
            }
        }
        //
        private void salir()
        {
            this.Close();
        }
    }
}
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


namespace ModCompra.srcTransporte.CtaPagar.Tools.ToolsDoc.Vista
{
    public partial class Frm : Form
    {
        private CultureInfo _cult;
        private IToolDoc _controlador;


        private void InicializaDGV_1()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

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

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "dataFechaDoc";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 80;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "dataDocNro";
            c2.HeaderText = "Doc/Nro";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.Width = 100;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "dataDocTipo";
            c3.HeaderText = "Doc/Tipo";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.Width = 70;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "dataCiRif";
            c4.HeaderText = "CI/RIF";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.Width = 100;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "dataNombreRazonSocial";
            c5.HeaderText = "Nombre/Razón Social";
            c5.Visible = true;
            c5.Width = 180;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "dataImporte";
            c6.HeaderText = "Importe";
            c6.Visible = true;
            c6.MinimumWidth = 90;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "dataAcumulado";
            c7.HeaderText = "Acumulado";
            c7.Visible = true;
            c7.Width = 90;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n2";

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "dataResta";
            c8.HeaderText = "Resta";
            c8.Visible = true;
            c8.Width = 90;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c8.DefaultCellStyle.Format = "n2";
       
            DGV_1.Columns.Add(c1);
            DGV_1.Columns.Add(c2);
            DGV_1.Columns.Add(c3);
            DGV_1.Columns.Add(c4);
            DGV_1.Columns.Add(c5);
            DGV_1.Columns.Add(c6);
            DGV_1.Columns.Add(c7);
            DGV_1.Columns.Add(c8);
        }
        public Frm()
        {
            _cult = CultureInfo.CurrentCulture;
            InitializeComponent();
            InicializaDGV_1();
        }
        public void setControlador(IToolDoc ctr)
        {
            _controlador = ctr;
        }
        private bool _modoInicializar;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            L_TITULO_TOOLS.Text = _controlador.TituloTools;
            DGV_1.DataSource = _controlador.Hnd.CtasPendiente.Get_Source;
            ActualizarDataPanel_Totales();
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


        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarCtasPendientes();
        }
        private void BT_AGREGAR_PAGO_Click(object sender, EventArgs e)
        {
            AgregarPago();
        }
        private void BT_ADM_DOC_PAGO_Click(object sender, EventArgs e)
        {
            AdmDocPagos();
        }


        private void BuscarCtasPendientes()
        {
            _controlador.Hnd.CtasPendiente.CargarCtas();
            ActualizarDataPanel_Totales();
        }
        private void AgregarPago()
        {
            _controlador.Hnd.GestionPago();
            ActualizarDataPanel_Totales();
        }
        private void AdmDocPagos()
        {
            _controlador.Hnd.AdmDocPagos();
            ActualizarDataPanel_Totales();
            BuscarCtasPendientes();
        }


        private void TSM_ARCHIVO_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOK)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
        private void ActualizarDataPanel_Totales()
        {
            L_CNT_ITEM.Text = "Cant Items: "+_controlador.Hnd.CtasPendiente.Get_CntItem.ToString("n0");
            L_MONTO_PENDIENTE.Text = _controlador.Hnd.CtasPendiente.Get_MontoPendiente.ToString("n2",_cult);
        }
    }
}
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


namespace ModCompra.srcTransporte.CtaPagar.Tools.PagoDoc.Vista
{
    public partial class Frm : Form
    {
        private IPagoDoc _controlador;
        private CultureInfo _cult;


        private void DGV_Inicializa()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            var f2 = new Font("Serif", 10, FontStyle.Bold);

            DGV.RowHeadersVisible = false;
            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;

            var xc1 = new DataGridViewTextBoxColumn();
            xc1.DataPropertyName = "Metodo";
            xc1.HeaderText = "Medio Pago";
            xc1.Visible = true;
            xc1.MinimumWidth = 100;
            xc1.HeaderCell.Style.Font = f;
            xc1.DefaultCellStyle.Font = f1;
            xc1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            xc1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            xc1.ReadOnly = true;

            var xc11 = new DataGridViewTextBoxColumn();
            xc11.DataPropertyName = "Monto";
            xc11.HeaderText = "Monto";
            xc11.Visible = true;
            xc11.MinimumWidth = 100;
            xc11.HeaderCell.Style.Font = f;
            xc11.DefaultCellStyle.Font = f1;
            xc11.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc11.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            xc11.DefaultCellStyle.Format = "n2";
            xc11.ReadOnly = true;

            var xc12 = new DataGridViewTextBoxColumn();
            xc12.DataPropertyName = "Tasa";
            xc12.HeaderText = "Tasa";
            xc12.Visible = true;
            xc12.MinimumWidth = 60;
            xc12.HeaderCell.Style.Font = f;
            xc12.DefaultCellStyle.Font = f1;
            xc12.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc12.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            xc12.ReadOnly = true;

            var xc2 = new DataGridViewTextBoxColumn();
            xc2.DataPropertyName = "Importe";
            xc2.HeaderText = "Importe";
            xc2.Visible = true;
            xc2.Width = 120;
            xc2.HeaderCell.Style.Font = f;
            xc2.DefaultCellStyle.Font = f1;
            xc2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            xc2.DefaultCellStyle.Format = "n2";
            xc2.ReadOnly = true;

            DGV.Columns.Add(xc1);
            DGV.Columns.Add(xc11);
            DGV.Columns.Add(xc12);
            DGV.Columns.Add(xc2);
        }
        private void DGV_CAJA_Inicializa()
        {
            var f = new Font("Serif", 10, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            var f2 = new Font("Serif", 8, FontStyle.Regular);

            DGV_CAJA.RowHeadersVisible = false;
            DGV_CAJA.AllowUserToAddRows = false;
            DGV_CAJA.AllowUserToDeleteRows = false;
            DGV_CAJA.AutoGenerateColumns = false;
            DGV_CAJA.AllowUserToResizeRows = false;
            DGV_CAJA.AllowUserToResizeColumns = false;
            DGV_CAJA.AllowUserToOrderColumns = false;
            DGV_CAJA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_CAJA.MultiSelect = false;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "descripcion";
            c1.HeaderText = "Descripcion";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f2;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.ReadOnly = true;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "esDivisa";
            c5.Name= "esDivisa";
            c5.HeaderText = "$";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f;
            c5.Width = 20;
            c5.ReadOnly = true;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "SaldoActual";
            c2.HeaderText = "Saldo Actual";
            c2.Visible = true;
            c2.Width = 90;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f2;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c2.DefaultCellStyle.Format = "n2";
            c2.ReadOnly = true;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "montoAbonar";
            c3.HeaderText = "Monto Abonar";
            c3.Visible = true;
            c3.Width = 90;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f2;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";
            c3.ReadOnly = true;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = ""; // Deja el encabezado en blanco
            buttonColumn.Name = "Ed";
            buttonColumn.Text = "Ed"; // Texto que se mostrará en el botón
            buttonColumn.UseColumnTextForButtonValue = true; // Usa el texto del botón para todas las celdas
            buttonColumn.Width = 50;

            DGV_CAJA.Columns.Add(c1);
            DGV_CAJA.Columns.Add(c5);
            DGV_CAJA.Columns.Add(c2);
            DGV_CAJA.Columns.Add(c3);
            DGV_CAJA.Columns.Add(buttonColumn);
        }
        private void DGV_CAJA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGV_CAJA.Columns["Ed"].Index && e.RowIndex >= 0)
            {
                _controlador.HndCaja.EditarMontoAbonar();
                ActualizarTotalCaja();
            }
        }
        private void DGV_CAJA_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == DGV_CAJA.Columns["esDivisa"].Index && e.Value != null)
            {
                bool esDivisa = (bool)e.Value;
                if (esDivisa)
                {
                    e.Value = "$"; // Coloca el signo de dólar si es divisa
                    e.FormattingApplied = true;
                }
                else
                {
                    e.Value = string.Empty; // Deja en blanco si no es divisa
                    e.FormattingApplied = true;
                }
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTotalCaja();
        }
        public Frm()
        {
            _cult = CultureInfo.CurrentCulture;
            InitializeComponent();
            DGV_Inicializa();
            DGV_CAJA_Inicializa();
        }
        private bool _modoInicializa;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            //
            DGV.DataSource = _controlador.HndMetPag.Get_Source;
            //
            DGV_CAJA.DataSource = _controlador.HndCaja.Get_CajaSource;
            //
            L_PROV_INFO.Text = _controlador.HndData.Get_ProvInfo;
            DTP_FECHA_PAG.Value = _controlador.HndData.Get_FechaPag;
            TB_MONTO_PAG.Text = _controlador.HndData.Get_MontoPag.ToString();
            TB_FACTOR_PAG.Text = _controlador.HndData.Get_TasaFactorCambio.ToString("n2", _cult);
            TB_MOTIVO_PAG.Text = _controlador.HndData.Get_Motivo;
            L_DOC_NRO.Text = _controlador.HndData.Get_InfoDoc_Nro;
            L_DOC_FECHA.Text = _controlador.HndData.Get_InfoDoc_FechaEmision.ToShortDateString();
            L_DOC_CONTROL.Text = _controlador.HndData.Get_InfoDoc_Control;
            L_DOC_CONDICION.Text = _controlador.HndData.Get_InfoDoc_Condicion;
            L_DOC_CONCEPTO.Text = _controlador.HndData.Get_InfoDoc_Concepto;
            L_DOC_MOTIVO.Text = _controlador.HndData.Get_InfoDoc_Motivo; 
            ActualizarTotalPago();
            //
            _modoInicializa = false;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK || _controlador.ProcesarIsOK)
            {
                e.Cancel = false;
            }
        }
        private void CTRL_KEYDOWN(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        public void setControlador(IPagoDoc ctr)
        {
            _controlador = ctr;
        }

        private void DTP_FECHA_PAG_Leave(object sender, EventArgs e)
        {
            _controlador.HndData.setFechaPag(DTP_FECHA_PAG.Value);
        }
        private void DTP_FECHA_PAG_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = DTP_FECHA_PAG.Value > _controlador.HndData.Get_FechaServidor;
        }
        private void TB_MONTO_PAG_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_MONTO_PAG.Text);
            _controlador.HndData.setMontoPag(_monto);
            TB_MONTO_PAG.Text = _controlador.HndData.Get_MontoPag.ToString("n2", _cult);
            ActualizarTotalPago();
        }
        private void TB_FACTOR_PAG_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_FACTOR_PAG.Text);
            _controlador.HndData.setTasaFactorCambio(_monto);
            TB_FACTOR_PAG.Text = _controlador.HndData.Get_TasaFactorCambio.ToString("n2", _cult);
            ActualizarTotalPago();
        }
        private void TB_FACTOR_PAG_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = (_controlador.HndData.Get_TasaFactorCambio <= 0m);
        }
        private void TB_MOTIVO_PAG_Leave(object sender, EventArgs e)
        {
            _controlador.HndData.setMotivo(TB_MOTIVO_PAG.Text.Trim().ToUpper());
            TB_MOTIVO_PAG.Text = _controlador.HndData.Get_Motivo;
        }


        private void BT_METPAGO_AGREGAR_Click(object sender, EventArgs e)
        {
            AgregarMetPago();
        }
        private void BT_METPAGO_EDITAR_Click(object sender, EventArgs e)
        {
            EditarMetPago();
        }
        private void BT_METPAGO_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarMetPago();
        }


        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            ProcesarFicha();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void AgregarMetPago()
        {
            _controlador.HndMetPag.AgregarMet();
        }
        private void EditarMetPago()
        {
        }
        private void EliminarMetPago()
        {
            _controlador.HndMetPag.EliminarMet();
        }


        private void ProcesarFicha()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOK)
            {
                salir();
            }
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
        private void ActualizarTotalPago()
        {
            L_MONTO_MONEDA_ACT.Text = "Monto Bs: " + _controlador.HndData.Get_MontoPagMonAct.ToString("n2", _cult);
            ActualizarTotalCaja();
        }
        private void ActualizarTotalCaja()
        {
            _controlador.ActualizarSaldoCaja();
            L_MONTO_PEND_MON_DIV.Text = _controlador.HndCaja.Get_MontoPendMonDiv.ToString("n2", _cult);
            L_MONTO_PEND_MON_ACT.Text = _controlador.HndCaja.Get_MontoPendMonAct.ToString("n2", _cult);
            //
            L_METPAGO_MONTO_PAGAR.Text = _controlador.HndMetPag.Get_MontoPagar.ToString("n2", _cult);
            L_METPAGO_MONTO_PEND.Text = _controlador.HndMetPag.Get_MontoPend.ToString("n2", _cult);
            L_METPAGO_MONTO_RECIBIDO.Text = _controlador.HndMetPag.Get_MontoRecibido.ToString("n2", _cult);
        }
    }
}
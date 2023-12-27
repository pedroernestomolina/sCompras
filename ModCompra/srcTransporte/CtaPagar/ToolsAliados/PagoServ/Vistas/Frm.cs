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

namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Vistas
{
    public partial class Frm : Form
    {
        private Vistas.IPagServ _controlador;
        private CultureInfo _cult;


        private void DGV_Inicializa()
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

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "fechaDoc";
            c1.HeaderText = "Fecha/Doc";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 80;
            c1.ReadOnly = true;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "numeroDoc";
            c2.HeaderText = "Nro/Doc";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c2.Width = 80;
            c2.ReadOnly = true;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "nombreDoc";
            c3.HeaderText = "Nombre/Doc";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c3.Width = 90;
            c3.ReadOnly = true;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "cliente";
            c4.HeaderText = "Cliente";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.MinimumWidth = 250;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c4.ReadOnly = true;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Servicio";
            c5.HeaderText = "Servicio";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.MinimumWidth = 250;
            c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c5.ReadOnly = true;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "pendiente";
            c6.HeaderText = "Pendiente";
            c6.Visible = true;
            c6.MinimumWidth = 100;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";
            c6.ReadOnly = true;

            var c7 = new DataGridViewCheckBoxColumn();
            c7.DataPropertyName = "isSelected";
            c7.HeaderText = "";
            c7.Visible = true;
            c7.Width = 30;
            c7.ReadOnly = false;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            //DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
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
            var _ds = _controlador.data.Servicios.Get_Source;
            _ds.CurrentChanged += _ds_CurrentChanged;
            _modoInicializa = true;
            DGV.DataSource = _ds;
            L_ALIADO_INFO.Text = _controlador.data.Get_AliadoInfo;
            L_MONTO_ANTICIPOS.Text = _controlador.data.Get_AliadoAnticipos.ToString("n2", _cult);
            L_MONTO_PENDIENTE.Text = _controlador.data.Get_MontoPendiente.ToString("n2", _cult);
            L_CNT_ITEM.Text = _controlador.data.Servicios.Get_CntItem.ToString();
            L_SERV_DESC.Text = _controlador.data.Servicios.Get_DescripcionServicioActual;
            //
            DTP_FECHA_PAG_SERV.Value = _controlador.data.GestPago.Get_FechaPag;
            TB_MONTO_PAG_SERV.Text = _controlador.data.GestPago.Get_MontoPag.ToString();
            TB_FACTOR_PAG_SERV.Text = _controlador.data.GestPago.Get_TasaFactorCambio.ToString("n2", _cult);
            TB_MOTIVO_PAG_SERV.Text = _controlador.data.GestPago.Get_Motivo;
            ActualizarTotalPago();
            ActualizarRetencion();
            //
            DGV_CAJA.DataSource = _controlador.data.GestPago.Get_CajaSource;

            _modoInicializa = false;
        }
        void _ds_CurrentChanged(object sender, EventArgs e)
        {
            L_SERV_DESC.Text = _controlador.data.Servicios.Get_DescripcionServicioActual;
        }
        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 5)
                {
                    _controlador.data.Servicios.SeleccionarItem();
                    _controlador.data.GestPago.setMontoPagDiv(_controlador.data.Servicios.Get_MontoSeleccionadoPagar);
                    TB_MONTO_PAG_SERV.Text = _controlador.data.GestPago.Get_MontoPag.ToString();
                    ActualizarTotalPago();
                    ActualizarTotalCaja();
                    this.Refresh();
                }
            }
        }
        private void DGV_CAJA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGV_CAJA.Columns["Ed"].Index && e.RowIndex >= 0)
            {
                _controlador.data.GestPago.CajaEditarMontoAbonar();
                _controlador.data.GestPago.ActualizarSaldoCaja();
                L_MONTO_PEND_MON_DIV.Text = _controlador.data.GestPago.CajaGet_MontoPendMonDiv.ToString("n2", _cult);
                L_MONTO_PEND_MON_ACT.Text = _controlador.data.GestPago.CajaGet_MontoPendMonAct.ToString("n2", _cult);
            }
        }
        private void DGV_CAJA_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
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
        public void setControlador(Vistas.IPagServ ctr)
        {
            _controlador = ctr;
        }


        private void DTP_FECHA_PAG_SERV_Leave(object sender, EventArgs e)
        {
            _controlador.data.GestPago.setFechaPag(DTP_FECHA_PAG_SERV.Value);
        }
        private void DTP_FECHA_PAG_SERV_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = DTP_FECHA_PAG_SERV.Value > _controlador.data.GestPago.Get_FechaServidor;
        }
        private void TB_FACTOR_PAG_SERV_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_FACTOR_PAG_SERV.Text);
            _controlador.data.GestPago.setTasaFactorCambio(_monto);
            TB_FACTOR_PAG_SERV.Text = _controlador.data.GestPago.Get_TasaFactorCambio.ToString("n2", _cult);
            ActualizarTotalPago();
        }
        private void TB_FACTOR_PAG_SERV_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = (_controlador.data.GestPago.Get_TasaFactorCambio <= 0m);
        }
        private void TB_MOTIVO_PAG_SERV_Leave(object sender, EventArgs e)
        {
            _controlador.data.GestPago.setMotivo(TB_MOTIVO_PAG_SERV.Text.Trim().ToUpper());
            TB_MOTIVO_PAG_SERV.Text = _controlador.data.GestPago.Get_Motivo;
        }
        private void CHB_APLICA_RET_PAG_SERV_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.data.GestPago.setAplicaRet(CHB_APLICA_RET_PAG_SERV.Checked);
            ActualizarTotalPago();
            ActualizarRetencion();
        }
        private void TB_RET_TASA_PAG_SERV_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_RET_TASA_PAG_SERV.Text);
            _controlador.data.GestPago.setTasaRet(_monto);
            TB_RET_TASA_PAG_SERV.Text = _controlador.data.GestPago.Get_TasaRetencion.ToString("n2", _cult);
            ActualizarTotalPago();
        }
        private void TB_RET_SUSTRAENDO_PAG_SERV_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_RET_SUSTRAENDO_PAG_SERV.Text);
            _controlador.data.GestPago.setMontoSustraendo(_monto);
            TB_RET_SUSTRAENDO_PAG_SERV.Text = _controlador.data.GestPago.Get_MontoSustraendo.ToString("n2", _cult);
            ActualizarTotalPago();
        }


        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            ProcesarFicha();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
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
            TB_FACTOR_PAG_SERV.Text = _controlador.data.GestPago.Get_TasaFactorCambio.ToString("n2");
            L_MONTO_MONEDA_ACT.Text = "Monto Bs: " + _controlador.data.GestPago.Get_MontoPagMonAct.ToString("n2", _cult);
            L_MONTO_RETENCION.Text = _controlador.data.GestPago.Get_MontoRetencion.ToString("n2", _cult);
            L_MONTO_ABONA_MON_DIV.Text = _controlador.data.GestPago.Get_MontoAbonoMonDiv.ToString("n2", _cult);
            L_MONTO_ABONA_MON_ACT.Text = _controlador.data.GestPago.Get_MontoAbonoMonAct.ToString("n2", _cult);
            ActualizarTotalCaja();
        }
        private void ActualizarRetencion()
        {
            TB_RET_TASA_PAG_SERV.Text = _controlador.data.GestPago.Get_TasaRetencion.ToString("n2", _cult);
            TB_RET_SUSTRAENDO_PAG_SERV.Text = _controlador.data.GestPago.Get_MontoSustraendo.ToString("n2", _cult);
            TB_RET_TASA_PAG_SERV.Enabled = _controlador.data.GestPago.Get_AplicaRet;
            TB_RET_SUSTRAENDO_PAG_SERV.Enabled = _controlador.data.GestPago.Get_AplicaRet;
            L_MONTO_ABONA_MON_DIV.Text = _controlador.data.GestPago.Get_MontoAbonoMonDiv.ToString("n2", _cult);
            L_MONTO_ABONA_MON_ACT.Text = _controlador.data.GestPago.Get_MontoAbonoMonAct.ToString("n2", _cult);
            ActualizarTotalCaja();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTotalPago();
        }
        private void ActualizarTotalCaja()
        {
            _controlador.data.GestPago.ActualizarSaldoCaja();
            L_MONTO_PEND_MON_DIV.Text = _controlador.data.GestPago.CajaGet_MontoPendMonDiv.ToString("n2", _cult);
            L_MONTO_PEND_MON_ACT.Text = _controlador.data.GestPago.CajaGet_MontoPendMonAct.ToString("n2", _cult);
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
    }
}
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


namespace ModCompra.srcTransporte.Beneficiario.Movimiento.Vistas
{
    public partial class Frm : Form
    {
        private Vistas.IHnd _controlador;
        private CultureInfo _cult;


        private void InicializarDGV()
        {
            var f = new Font("Serif", 10, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

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
            c1.DataPropertyName = "descripcion";
            c1.HeaderText = "Descripcion";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 250;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.ReadOnly = true;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "SaldoActual";
            c2.HeaderText = "Saldo Actual";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c2.DefaultCellStyle.Format = "n2";
            c2.ReadOnly = true;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "montoAbonar";
            c3.HeaderText = "Monto Abonar";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";
            c3.ReadOnly = true;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = ""; // Deja el encabezado en blanco
            buttonColumn.Name = "Ed";
            buttonColumn.Text = "Ed"; // Texto que se mostrará en el botón
            buttonColumn.UseColumnTextForButtonValue = true; // Usa el texto del botón para todas las celdas
            buttonColumn.Width = 60;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(buttonColumn);
        }
        public Frm()
        {
            InitializeComponent();
            InicializarDGV();
            InicializaCB();
            _cult= CultureInfo.CurrentCulture;
        }
        private void InicializaCB()
        {
            CB_BENEFICIARIO.DisplayMember = "desc";
            CB_BENEFICIARIO.ValueMember = "id";
            CB_CONCEPTO.DisplayMember = "desc";
            CB_CONCEPTO.ValueMember = "id";
        }

        private bool _modoInicializa;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            DGV.DataSource = _controlador.caja.Get_CajaSource;
            DGV.CellContentClick += DGV_CellContentClick; 
            CB_CONCEPTO.DataSource = _controlador.Mov.Get_ConceptoMov_Source;
            CB_CONCEPTO.SelectedValue= _controlador.Mov.Get_ConceptoMovId;
            CB_BENEFICIARIO.DataSource = _controlador.Mov.Get_Beneficiario_Source;
            CB_BENEFICIARIO.SelectedValue = _controlador.Mov.Get_BeneficiarioId;
            DTP_FECHA_MOV.Value = _controlador.Mov.Get_FechaMovimiento;
            TB_MONTO_MOV.Text = _controlador.Mov.Get_MontoMov.ToString("n2",_cult);
            TB_FACTOR_CAMBIO.Text = _controlador.Mov.Get_FactorCambio.ToString("n2", _cult);
            TB_NOTAS.Text = _controlador.Mov.Get_Notas;
            L_MONTO_MON_ACT.Text = "Monto En Bs"+Environment.NewLine+_controlador.Mov.Get_MontoMonAct.ToString("n2",_cult);
            _modoInicializa = false;
        }
        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGV.Columns["Ed"].Index && e.RowIndex >= 0)
            {
                _controlador.caja.EditarMontoAbonar();
                _controlador.ActualizarSaldoCaja();
                L_MONTO_PEND_MON_DIV.Text = _controlador.caja.Get_MontoPendMonDiv.ToString("n2", _cult);
                L_MONTO_PEND_MON_ACT.Text = _controlador.caja.Get_MontoPendMonAct.ToString("n2", _cult);
            }                
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
        public void setControlador(Vistas.IHnd ctr)
        {
            _controlador = ctr;
        }


        private void CB_BENEFICIARIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.Mov.setBeneficiarioById("");
            if (CB_BENEFICIARIO.SelectedIndex != -1)
            {
                _controlador.Mov.setBeneficiarioById(CB_BENEFICIARIO.SelectedValue.ToString());
            }
        }
        private void CB_CONCEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.Mov.setConceptoById("");
            if (CB_CONCEPTO.SelectedIndex != -1)
            {
                _controlador.Mov.setConceptoById(CB_CONCEPTO.SelectedValue.ToString());
            }
        }
        private void TB_MONTO_MOV_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_MONTO_MOV.Text);
            _controlador.Mov.setMontoMov(_monto);
            _controlador.ActualizarSaldoCaja();
            TB_MONTO_MOV.Text = _controlador.Mov.Get_MontoMov.ToString("n2", _cult);
            L_MONTO_MON_ACT.Text = "Monto En Bs" + Environment.NewLine + _controlador.Mov.Get_MontoMonAct.ToString("n2", _cult);
        }
        private void TB_FACTOR_CAMBIO_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_FACTOR_CAMBIO.Text);
            _controlador.Mov.setFactorCambio(_monto);
            _controlador.ActualizarSaldoCaja();
            TB_FACTOR_CAMBIO.Text = _controlador.Mov.Get_FactorCambio.ToString("n2", _cult);
            L_MONTO_MON_ACT.Text = "Monto En Bs" + Environment.NewLine + _controlador.Mov.Get_MontoMonAct.ToString("n2", _cult);
        }
        private void TB_NOTAS_Leave(object sender, EventArgs e)
        {
            _controlador.Mov.setNotas(TB_NOTAS.Text.Trim().ToUpper());
            TB_NOTAS.Text = _controlador.Mov.Get_Notas;
        }
        private void TB_FACTOR_CAMBIO_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.Mov.Get_FactorCambio <= 0m;
        }
        private void TB_MONTO_MOV_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.Mov.Get_MontoMov <= 0m;
        }
        private void DTP_FECHA_MOV_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Mov.setFechaMov(DTP_FECHA_MOV.Value);
        }
        private void DTP_FECHA_MOV_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = DTP_FECHA_MOV.Value > _controlador.Mov.Get_FechaServidor;
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
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                _controlador.ActualizarSaldoCaja();
                L_MONTO_PEND_MON_DIV.Text = _controlador.caja.Get_MontoPendMonDiv.ToString("n2", _cult);
                L_MONTO_PEND_MON_ACT.Text = _controlador.caja.Get_MontoPendMonAct.ToString("n2", _cult);
            }
        }
    }
}
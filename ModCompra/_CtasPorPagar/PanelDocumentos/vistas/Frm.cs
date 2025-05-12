﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtasPorPagar.PanelDocumentos.vistas
{
    public partial class Frm: Form
    {
        private PanelDocumentos.interfaces.IPanel _controlador;
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
            c6.DataPropertyName = "montoDeuda";
            c6.HeaderText = "Importe";
            c6.Visible = true;
            c6.Width = 100;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";
            //
            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "montoAcumulado";
            c7.HeaderText = "Abonado";
            c7.Visible = true;
            c7.Width = 100;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n2";
            //
            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "montoPendiente";
            c8.HeaderText = "Resta";
            c8.Visible = true;
            c8.Width = 100;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c8.DefaultCellStyle.Format = "n2";
            //
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c8);
        }
        public Frm()
        {
            InitializeComponent();
            InicializaGrid();
        }
        public void setControlador(PanelDocumentos.interfaces.IPanel ctr)
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
            L_NOTAS.Text = _controlador.GetNotasDocumento;
        }
        private void BT_REPORTE_DOC_Click(object sender, EventArgs e)
        {
            ReporteDocumentos();
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
            L_IMPORTE.Text = _controlador.GetMontoImporte.ToString("n2");
            L_ABONADO.Text = _controlador.GetMontoAcumulado.ToString("n2");
            L_RESTA.Text = _controlador.GetMontoResta.ToString("n2");
            L_CNT_DOC.Text = _controlador.GetCantDoc.ToString();
            L_NOTAS.Text = _controlador.GetNotasDocumento;
        }
        private void ReporteDocumentos()
        {
            _controlador.ReporteDocumentos();
        }
        private void VisualizarDocumento()
        {
            _controlador.VisualizarDocumento();
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
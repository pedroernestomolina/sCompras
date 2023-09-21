﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Vistas
{
    public partial class Frm : Form
    {
        private CultureInfo _cult;
        private IAliados _controlador;


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
            c1.DataPropertyName = "CiRif";
            c1.HeaderText = "CI/RIF";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 100;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "NombreRazonSocial";
            c2.HeaderText = "Nombre/Razón Social";
            c2.Visible = true;
            c2.Width = 180;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "pendiente";
            c3.HeaderText = "Pendiente";
            c3.Visible = true;
            c3.MinimumWidth = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "anticipos";
            c4.HeaderText = "Anticipos";
            c4.Visible = true;
            c4.Width = 100;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "MontoResta";
            c8.HeaderText = "Resta";
            c8.Visible = true;
            c8.Width = 100;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c8.DefaultCellStyle.Format = "n2";

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "CntDocPend";
            c5.HeaderText = "Doc/Pend";
            c5.Visible = true;
            c5.Width = 80;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DGV_1.Columns.Add(c1);
            DGV_1.Columns.Add(c2);
            DGV_1.Columns.Add(c3);
            DGV_1.Columns.Add(c4);
            DGV_1.Columns.Add(c8);
            DGV_1.Columns.Add(c5);
        }
        public Frm()
        {
            _cult = CultureInfo.CurrentCulture;
            InitializeComponent();
            InicializaDGV_1();
        }
        public void setControlador(IAliados ctr)
        {
            _controlador = ctr;
        }
        private bool _modoInicializar;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            L_TITULO_TOOLS.Text = _controlador.TituloTools;
            DGV_1.DataSource = _controlador.data.CtasPendientes.GetSource;
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
        private void BT_AGREGAR_ANTICIPO_Click(object sender, EventArgs e)
        {
            AgregarAnticipo();
        }
        private void BT_SERV_Click(object sender, EventArgs e)
        {
            ServPrestado();
        }


        private void BT_VER_DETALLES_CTA_Click(object sender, EventArgs e)
        {
            DocDetallesPend();
        }
        private void DocDetallesPend()
        {
            //_controlador.DocDetallesPend();
        }
        private void BT_REPORTE_CTAS_Click(object sender, EventArgs e)
        {
            ListadoCtasPend();
        }
        private void ListadoCtasPend()
        {
            //_controlador.ListadoCtasPend();
        }
        private void BT_AGREGAR_NCR_ADM_Click(object sender, EventArgs e)
        {
            AgregarNCrAdm();
        }
        private void AgregarNCrAdm()
        {
            //_controlador.AgregarNCrAdm();
            //if (_controlador.AgregarNCrAdmIsOk)
            //{
            //    ActualizarDataPanel();
            //}
        }

        private void BT_AGREGAR_NDB_ADM_Click(object sender, EventArgs e)
        {
            AgregarNDbAdm();
        }
        private void AgregarNDbAdm()
        {
            //_controlador.AgregarNDbAdm();
            //if (_controlador.AgregarNDbAdmIsOk)
            //{
            //    ActualizarDataPanel();
            //}
        }

        private void BuscarCtasPendientes()
        {
            _controlador.data.CtasPendientes.CargarCtas();
            ActualizarDataPanel_Totales();
        }
        private void AgregarAnticipo()
        {
            _controlador.data.AgregarAnticipo();
            ActualizarDataPanel_Totales();
        }
        private void ServPrestado()
        {
            _controlador.data.ServPrestado();
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
            L_MONTO_PENDIENTE.Text = _controlador.data.CtasPendientes.Get_MontoPendiente.ToString("n2",_cult);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra
{

    public partial class Form1 : Form
    {

        private Gestion _controlador;
        private Timer timer;


        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var s = DateTime.Now;
            L_FECHA.Text = s.ToLongDateString();
            L_HORA.Text = s.ToLongTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
            L_VERSION.Text = _controlador.Version;
            L_HOST.Text = _controlador.Host;
            L_USUARIO.Text = _controlador.Usuario;
            L_FECHA.Text = "";
            L_HORA.Text = "";
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void TSM_ARCHIVO_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void MENU_DOCUMENTOS_REGISTRAR_FACTURA_COMPRA_Click(object sender, EventArgs e)
        {
            RegistrarFacturaCompra();
        }

        private void RegistrarFacturaCompra()
        {
            _controlador.RegistrarFacturaCompra();
        }

        public void setVisibilidadOff()
        {
            this.Visible = false;
        }

        public void setVisibilidadOn()
        {
            this.Visible = true;
        }

        private void MENU_DOCUMENTOS_ADMINISTRADOR_Click(object sender, EventArgs e)
        {
            AdministradorDoc();
        }

        private void AdministradorDoc()
        {
            _controlador.AdministradorDoc();
        }

        private void MENU_REPORTES_GENERAL_DOCUMENTOS_Click(object sender, EventArgs e)
        {
            ReporteGeneralDocumentos();
        }

        private void ReporteGeneralDocumentos()
        {
            _controlador.ReporteGeneralDocumentos();
        }

        private void MENU_REPORTES_COMPRAS_DEPARTAMENTOS_Click(object sender, EventArgs e)
        {
            ReporteComprasDepartamentos();
        }

        private void ReporteComprasDepartamentos()
        {
            _controlador.ReporteComprasDepartamentos();
        }

        private void MENU_REPORTES_COMPRAS_POR_PRODUCTO_Click(object sender, EventArgs e)
        {
            ReporteComprasPorProducto();
        }

        private void ReporteComprasPorProducto()
        {
            _controlador.ReporteComprasPorProducto();
        }

        private void MENU_REPORTES_COMPRAS_POR_PRODUCTO_DETALLE_Click(object sender, EventArgs e)
        {
            ReporteComprasDetalleProducto();
        }

        private void ReporteComprasDetalleProducto()
        {
            _controlador.ReporteComprasDetalleProducto();
        }

        private void MENU_DOCUMENTOS_REGISTRAR_NC_COMPRA_Click(object sender, EventArgs e)
        {
            RegistrarNcCompra();
        }

        private void RegistrarNcCompra()
        {
            _controlador.RegistrarNcCompra();
        }

        private void MENU_MAESTROS_GRUPOS_Click(object sender, EventArgs e)
        {
            MaestrosGrupos();
        }

        private void MaestrosGrupos()
        {
            _controlador.MaestrosGrupos();
        }

        private void MENU_MAESTROS_PROVEEDOR_Click(object sender, EventArgs e)
        {
            MaestroProveedor();
        }

        private void MaestroProveedor()
        {
            _controlador.MaestroProveedor();
        }

        private void MENU_MAESTROS_REPORTE_PROVEEDORES_Click(object sender, EventArgs e)
        {
            ReporteMaestroProveedores();
        }

        private void ReporteMaestroProveedores()
        {
            _controlador.ReporteMaestroProveedor();
        }

    }

}
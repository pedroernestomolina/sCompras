using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.PantallaInicio
{

    public partial class Frm : Form
    {

        private Gestion _controlador;
        private Timer timer;


        public Frm()
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
            P_ICONO.BackgroundImage = _controlador.EmpresaLogo;
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
        private void MENU_REPORTES_COMPRAS_CON_CAMBIOS_PRECIO_Click(object sender, EventArgs e)
        {
            ReporteComprasConCambiosPrecio();
        }
        private void ReporteComprasConCambiosPrecio()
        {
            _controlador.ReporteComprasConCambiosPrecio();
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

        private void TSM_CONFIGURACION_SISTEMA_Click(object sender, EventArgs e)
        {
            ConfiguracionSistema();
        }
        private void ConfiguracionSistema()
        {
            _controlador.ConfiguracionSistema();
        }

        private void MENU_DOCUMENTOS_REGISTRAR_COMPRA_GASTO_Click(object sender, EventArgs e)
        {
            RegistrarCompraGasto();
        }
        private void RegistrarCompraGasto()
        {
            _controlador.RegistrarCompraGasto();
        }


        //MAESTROS
        private void MENU_MAESTRO_CONCEPTOS_Click(object sender, EventArgs e)
        {
            MaestroConceptos();
        }
        private void MENU_MAESTRO_CAJA_Click(object sender, EventArgs e)
        {
            MaestroCaja();
        }
        private void MaestroCaja()
        {
            _controlador.MaestroCaja();
        }
        private void MaestroConceptos()
        {
            _controlador.MaestroConceptos();
        }


        //CXP
        private void MENU_CXP_TOOLS_ALIADOS_Click(object sender, EventArgs e)
        {
            ToolAliados();
        }
        private void ToolAliados()
        {
            _controlador.ToolAliados();
        }


        //CAJA
        private void MENU_CAJA_REGISTRAR_MOV_Click(object sender, EventArgs e)
        {
            CajaRegistrarMov();
        }
        private void MENU_CAJA_ADM_DOC_Click(object sender, EventArgs e)
        {
            CajaAdmDoc();
        }
        private void CajaRegistrarMov()
        {
            _controlador.CajaRegistrarMov();
        }
        private void CajaAdmDoc()
        {
            _controlador.CajaAdmDoc();
        }


        //REPORTES
        private void MENU_REPORTES_DOCUMENTOS_GENERAL_Click(object sender, EventArgs e)
        {
            ReporteGeneralDoc();
        }
        private void MENU_REPORTES_DOCUMENTOS_RET_IVA_Click(object sender, EventArgs e)
        {
            ReportesRetIva();
        }
        private void MENU_REPORTES_DOCUMENTOS_RET_ISLR_Click(object sender, EventArgs e)
        {
            ReportesRetIslr();
        }
        //
        private void MENU_REPORTES_CXP_ALIADO_ANTICIPO_Click(object sender, EventArgs e)
        {
            ReportesAliadoAnticipo();
        }
        private void MENU_REPORTES_CXP_ALIDOS_PAGO_SERV_Click(object sender, EventArgs e)
        {
            ReportesAliadoPagoServ();
        }
        //
        private void MENU_REPORTES_CAJA_GENERAL_MOV_Click(object sender, EventArgs e)
        {
            ReportesCajaGeneralMov();
        }
        private void MENU_REPORTES_CAJA_EDO_CTA_Click(object sender, EventArgs e)
        {
            ReportesCajaEdoCta();
        }
        //
        private void ReporteGeneralDoc()
        {
            _controlador.ReporteGeneralDocTransp();
        }
        private void ReportesRetIva()
        {
            _controlador.ReportesRetIva();
        }
        private void ReportesRetIslr()
        {
            _controlador.ReportesRetIslr();
        }
        //
        private void ReportesAliadoAnticipo()
        {
            _controlador.ReportesAliadoAnticipo();
        }
        private void ReportesAliadoPagoServ()
        {
            _controlador.ReportesAliadoPagoServ();
        }
        //
        private void ReportesCajaGeneralMov()
        {
            _controlador.ReportesCajaGeneralMov();
        }
        private void ReportesCajaEdoCta()
        {
            _controlador.ReportesCajaEdoCta();
        }
    }
}
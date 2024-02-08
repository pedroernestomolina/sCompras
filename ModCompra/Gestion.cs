using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra
{
    public class Gestion
    {
        private Administrador.Gestion _gestionAdmDoc;
        private Reportes.Filtros.Gestion _gestionRep;
        private Maestros.Gestion _gestionMaestro;
        private Proveedor.Administrador.Gestion _gestionProveedor;
        private ReporteProveedor.Gestion _gestionRepPrv;
        private Configuracion.Modulo.IConf _gCnfSistema;


        public System.Drawing.Image EmpresaLogo { get { return logo(); } }
        public string Version { get { return "Ver. " + Application.ProductVersion; } }
        public string Host { get { return Sistema._Instancia + "/" + Sistema._BaseDatos; } }
        public string Usuario
        {
            get
            {
                return Sistema.UsuarioP.codigoUsu + Environment.NewLine +
                        Sistema.UsuarioP.nombreUsu + Environment.NewLine +
                        Sistema.UsuarioP.nombreGru;
            }
        }


        public Gestion()
        {
            _gestionAdmDoc = new Administrador.Gestion();
            _gestionRep = new Reportes.Filtros.Gestion();
            _gestionMaestro = new Maestros.Gestion();
            _gestionProveedor = new Proveedor.Administrador.Gestion();
            _gestionRepPrv = new ReporteProveedor.Gestion();
            _gCnfSistema = new Configuracion.Modulo.Conf();
        }


        public void Inicia()
        {
            if (cargarData())
            {
                Sistema.Fabrica.Iniciar_FrmPrincipal(this);
            }
        }

        public void RegistrarFacturaCompra()
        {
            if (SolicitarPermiso(Sistema.MyData.Permiso_Registrar_Factura, Sistema.UsuarioP.autoGru))
            {
                //frm.setVisibilidadOff();
                var gestionFac = new Documento.Cargar.Factura.GestionFac();
                var gestionEntrada = new Documento.Cargar.Controlador.Gestion();
                gestionEntrada.setGestion(gestionFac);
                gestionEntrada.Inicia();
                //frm.setVisibilidadOn();
            }
        }

        public void AdministradorDoc()
        {
            if (SolicitarPermiso(Sistema.MyData.Permiso_AdmDoc, Sistema.UsuarioP.autoGru))
            {
                _gestionAdmDoc.setGestion(new Administrador.Documentos.Gestion());
                _gestionAdmDoc.setActivarSeleccionItem(false);
                _gestionAdmDoc.Inicializa();
                _gestionAdmDoc.Inicia();
            }
        }

        public void RegistrarNcCompra()
        {
            if (SolicitarPermiso(Sistema.MyData.Permiso_Registrar_Nc, Sistema.UsuarioP.autoGru))
            {
                //frm.setVisibilidadOff();
                var gestionEntrada = new Documento.Cargar.Controlador.Gestion();
                gestionEntrada.setGestion(new Documento.Cargar.NotaCredito.GestionNc());
                gestionEntrada.Inicia();
                //frm.setVisibilidadOn();
            }
        }

        public void MaestrosGrupos()
        {
            if (SolicitarPermiso(Sistema.MyData.Permiso_Grupo, Sistema.UsuarioP.autoGru))
            {
                _gestionMaestro.setGestion(new Maestros.Grupo.Gestion());
                _gestionMaestro.Inicia();
            }
        }

        public void MaestroProveedor()
        {
            if (SolicitarPermiso(Sistema.MyData.Permiso_Proveedor, Sistema.UsuarioP.autoGru))
            {
                _gestionProveedor.Inicializar();
                _gestionProveedor.Inicia();
            }
        }

        public void ReporteMaestroProveedor()
        {
            ReporteProveedor(new ReporteProveedor.Modo.Maestro.Gestion());
        }
        private void ReporteProveedor(ReporteProveedor.IGestion gestion)
        {
            if (SolicitarPermiso(Sistema.MyData.Permiso_Proveedor_Reportes, Sistema.UsuarioP.autoGru))
            {
                _gestionRepPrv.setGestion(gestion);
                _gestionRepPrv.Inicializa();
                _gestionRepPrv.Inicia();
            }
        }

        public void ConfiguracionSistema()
        {
            if (SolicitarPermiso(Sistema.MyData.Permiso_ConfiguracionSistema, Sistema.UsuarioP.autoGru))
            {
                _gCnfSistema.Inicializa();
                _gCnfSistema.Inicia();
            }
        }

        public void ReporteGeneralDocumentos()
        {
            if (PermisoReporte())
            {
                _gestionRep.setGestion(new Reportes.Filtros.GeneralDocumentos.Gestion());
                _gestionRep.Inicia();
            }
        }
        public void ReporteComprasDepartamentos()
        {
            if (PermisoReporte())
            {
                _gestionRep.setGestion(new Reportes.Filtros.CompraDepartamentos.Gestion());
                _gestionRep.Inicia();
            }
        }
        public void ReporteComprasPorProducto()
        {
            if (PermisoReporte())
            {
                _gestionRep.setGestion(new Reportes.Filtros.CompraPorProductos.Gestion());
                _gestionRep.Inicia();
            }
        }
        public void ReporteComprasDetalleProducto()
        {
            if (PermisoReporte())
            {
                _gestionRep.setGestion(new Reportes.Filtros.CompraDetalleProducto.Gestion());
                _gestionRep.Inicia();
            }
        }
        public void ReporteComprasConCambiosPrecio()
        {
            if (PermisoReporte())
            {
                GenerarReporte(new Reportes.Filtros.CompraConCambioPrecios.Gestion());
            }
        }


        private void GenerarReporte(Reportes.Filtros.IReporte rep)
        {
            _gestionRep.setGestion(rep);
            _gestionRep.Inicia();
        }
        private bool PermisoReporte()
        {
            return SolicitarPermiso(Sistema.MyData.Permiso_Reportes, Sistema.UsuarioP.autoGru);
        }
        private bool SolicitarPermiso(Func<string, OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>> met, string idGrupoUsu)
        {
            var rt1 = met(idGrupoUsu);
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            return Seguridad.Gestion.SolicitarClave(rt1.Entidad);
        }
        private System.Drawing.Image logo()
        {
            if (Sistema.Negocio.logo.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(Sistema.Negocio.logo))
                {
                    Image image = Image.FromStream(ms);
                    return image;
                }
            }
            return null;
        }


        private bool cargarData()
        {
            try
            {
                Sistema.EquipoEstacion = Environment.MachineName;
                var r01 = Sistema.MyData.Empresa_Datos();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                Sistema.Negocio = r01.Entidad;
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        /////////////////////////
        //
        //
        // TRANSPORTE
        //
        //
        /////////////////////////
        //
        //
        //MAESTRO
        Utils.Maestro.IMaestro _concepto;
        public void MaestroConceptos()
        {
            if (_concepto == null)
            {
                _concepto = new ModCompra.srcTransporte.Concepto.Maestro.Imp();
            }
            _concepto.Inicializa();
            _concepto.Inicia();
        }
        Utils.Maestro.IMaestro _cajaMaster;
        public void MaestroCaja()
        {
            if (_cajaMaster == null)
            {
                _cajaMaster = new ModCompra.srcTransporte.Caja.Maestro.Imp();
            }
            _cajaMaster.Inicializa();
            _cajaMaster.Inicia();
        }
        Utils.Maestro.IMaestro _beneficiario;
        public void MaestroBeneficiarios()
        {
            if (_beneficiario == null)
            {
                _beneficiario = new ModCompra.srcTransporte.Beneficiario.Maestro.Imp();
            }
            _beneficiario.Inicializa();
            _beneficiario.Inicia();
        }

        //DOCUMENTOS
        ModCompra.srcTransporte.CompraGasto.Vistas.Generar.ICompraGasto _compraGasto;
        public void RegistrarCompraGasto()
        {
            if (_compraGasto == null)
            {
                _compraGasto = new ModCompra.srcTransporte.CompraGasto.Handlres.Generar.Imp();
            }
            _compraGasto.Inicializa();
            _compraGasto.Inicia();
        }
        public void AdministradorDocRet()
        {
            srcTransporte.Retencion.Administrador.Vistas.IAdm _adm = new srcTransporte.Retencion.Administrador.Handler.Imp();
            _adm.Inicializa();
            _adm.Inicia();
        }


        //CXP
        srcTransporte.CtaPagar.ToolsAliados.Vistas.IAliados _toolAliados;
        public void ToolAliados()
        {
            if (_toolAliados == null)
            {
                _toolAliados = new srcTransporte.CtaPagar.ToolsAliados.Handlers.Imp();
            }
            _toolAliados.Inicializa();
            _toolAliados.Inicia();
        }
        srcTransporte.CtaPagar.Tools.ToolsDoc.Vista.IToolDoc _toolDoc;
        public void ToolsDocumentos()
        {
            if (_toolDoc == null)
            {
                _toolDoc = new srcTransporte.CtaPagar.Tools.ToolsDoc.Handler.ImpToolDoc();
            }
            _toolDoc.Inicializa();
            _toolDoc.Inicia();
        }


        //CAJA
        public void CajaRegistrarMov()
        {
            srcTransporte.Caja.Movimiento.Agregar.Vistas.IMov _mov = new srcTransporte.Caja.Movimiento.Agregar.Handler.Imp();
            _mov.Inicializa();
            _mov.Inicia();
        }
        public void CajaAdmDoc()
        {
            srcTransporte.Caja.Administrador.Vistas.IAdm _adm = new srcTransporte.Caja.Administrador.Handler.Imp();
            _adm.Inicializa();
            _adm.Inicia();
        }


        //REPORTES
        public void ReporteGeneralDocTransp()
        {
            srcTransporte.Reportes.RepFiltro.Vista.IHnd _filtro = new srcTransporte.Reportes.RepFiltro.Handler.Imp();
            _filtro.Desde.setActivarCheck(true);
            _filtro.Hasta.setActivarCheck(true);
            _filtro.Inicializa();
            _filtro.setFiltrosCargar(new srcTransporte.Reportes.Documentos.ListaGeneralDoc.FiltroActivar());
            _filtro.Inicia();
            if (_filtro.ProcesarIsOK)
            {
                srcTransporte.Reportes.IRepFiltro _rep = new srcTransporte.Reportes.Documentos.ListaGeneralDoc.Imp();
                _rep.setFiltros(_filtro.Get_Filtros);
                _rep.Generar();
            }
        }
        public void ReportesRetIva()
        {
            srcTransporte.Reportes.RepFiltro.Vista.IHnd _filtro = new srcTransporte.Reportes.RepFiltro.Handler.Imp();
            _filtro.Desde.setActivarCheck(true);
            _filtro.Hasta.setActivarCheck(true);
            _filtro.Inicializa();
            _filtro.setFiltrosCargar(new srcTransporte.Reportes.Documentos.ListaRet.FiltroActivar());
            _filtro.Inicia();
            if (_filtro.ProcesarIsOK)
            {
                srcTransporte.Reportes.IRepFiltro _rep = new srcTransporte.Reportes.Documentos.ListaRet.iva();
                _rep.setFiltros(_filtro.Get_Filtros);
                _rep.Generar();
            }
        }
        public void ReportesRetIslr()
        {
            srcTransporte.Reportes.RepFiltro.Vista.IHnd _filtro = new srcTransporte.Reportes.RepFiltro.Handler.Imp();
            _filtro.Desde.setActivarCheck(true);
            _filtro.Hasta.setActivarCheck(true);
            _filtro.Inicializa();
            _filtro.setFiltrosCargar(new srcTransporte.Reportes.Documentos.ListaRet.FiltroActivar());
            _filtro.Inicia();
            if (_filtro.ProcesarIsOK)
            {
                srcTransporte.Reportes.IRepFiltro _rep = new srcTransporte.Reportes.Documentos.ListaRet.islr();
                _rep.setFiltros(_filtro.Get_Filtros);
                _rep.Generar();
            }
        }
        public void ReportesAliadoAnticipo()
        {
            srcTransporte.Reportes.RepFiltro.Vista.IHnd _filtro = new srcTransporte.Reportes.RepFiltro.Handler.Imp();
            _filtro.Desde.setActivarCheck(true);
            _filtro.Hasta.setActivarCheck(true);
            _filtro.Inicializa();
            _filtro.setFiltrosCargar(new srcTransporte.Reportes.CXP.Aliado.Anticipo.FiltroActivar());
            _filtro.Inicia();
            if (_filtro.ProcesarIsOK)
            {
                srcTransporte.Reportes.IRepFiltro _rep = new srcTransporte.Reportes.CXP.Aliado.Anticipo.Imp();
                _rep.setFiltros(_filtro.Get_Filtros);
                _rep.Generar();
            }
        }
        public void ReportesAliadoPagoServ()
        {
            srcTransporte.Reportes.RepFiltro.Vista.IHnd _filtro = new srcTransporte.Reportes.RepFiltro.Handler.Imp();
            _filtro.Desde.setActivarCheck(true);
            _filtro.Hasta.setActivarCheck(true);
            _filtro.Inicializa();
            _filtro.setFiltrosCargar(new srcTransporte.Reportes.CXP.Aliado.PagoServ.FiltroActivar());
            _filtro.Inicia();
            if (_filtro.ProcesarIsOK)
            {
                srcTransporte.Reportes.IRepFiltro _rep = new srcTransporte.Reportes.CXP.Aliado.PagoServ.Imp();
                _rep.setFiltros(_filtro.Get_Filtros);
                _rep.Generar();
            }
        }
        public void ReportesAliadoMovCaja()
        {
            srcTransporte.Reportes.RepFiltro.Vista.IHnd _filtro = new srcTransporte.Reportes.RepFiltro.Handler.Imp();
            _filtro.Desde.setActivarCheck(true);
            _filtro.Hasta.setActivarCheck(true);
            _filtro.Inicializa();
            _filtro.setFiltrosCargar(new srcTransporte.Reportes.CXP.Aliado.MovCaja.FiltroActivar());
            _filtro.Inicia();
            if (_filtro.ProcesarIsOK)
            {
                srcTransporte.Reportes.IRepFiltro _rep = new srcTransporte.Reportes.CXP.Aliado.MovCaja.Imp();
                _rep.setFiltros(_filtro.Get_Filtros);
                _rep.Generar();
            }
        }
        public void ReportesCxpDocumentos_PagosEmitidos()
        {
            srcTransporte.Reportes.RepFiltro.Vista.IHnd _filtro = new srcTransporte.Reportes.RepFiltro.Handler.Imp();
            _filtro.Desde.setActivarCheck(true);
            _filtro.Hasta.setActivarCheck(true);
            _filtro.Inicializa();
            _filtro.setFiltrosCargar(new srcTransporte.Reportes.CXP.Documentos.Pagos.FiltroActivar());
            _filtro.Inicia();
            if (_filtro.ProcesarIsOK)
            {
                srcTransporte.Reportes.IRepFiltro _rep = new srcTransporte.Reportes.CXP.Documentos.Pagos.Imp();
                _rep.setFiltros(_filtro.Get_Filtros);
                _rep.Generar();
            }
        }
        public void ReportesCxp_PagosPorConcepto()
        {
            srcTransporte.Reportes.RepFiltro.Vista.IHnd _filtro = new srcTransporte.Reportes.RepFiltro.Handler.Imp();
            _filtro.Desde.setActivarCheck(true);
            _filtro.Hasta.setActivarCheck(true);
            _filtro.Inicializa();
            _filtro.setFiltrosCargar(new srcTransporte.Reportes.CXP.PagosPorConcepto.FiltroActivar());
            _filtro.Inicia();
            if (_filtro.ProcesarIsOK)
            {
                srcTransporte.Reportes.IRepFiltro _rep = new srcTransporte.Reportes.CXP.PagosPorConcepto.Imp();
                _rep.setFiltros(_filtro.Get_Filtros);
                _rep.Generar();
            }
        }


        public void ReportesCajaGeneralMov()
        {
            srcTransporte.Reportes.RepFiltro.Vista.IHnd _filtro = new srcTransporte.Reportes.RepFiltro.Handler.Imp();
            _filtro.Desde.setActivarCheck(true);
            _filtro.Hasta.setActivarCheck(true);
            _filtro.Inicializa();
            _filtro.setFiltrosCargar(new srcTransporte.Reportes.Caja.GeneralMov.FiltroActivar());
            _filtro.Inicia();
            if (_filtro.ProcesarIsOK)
            {
                srcTransporte.Reportes.IRepFiltro _rep = new srcTransporte.Reportes.Caja.GeneralMov.Imp();
                _rep.setFiltros(_filtro.Get_Filtros);
                _rep.Generar();
            }
        }
        public void ReportesCajaEdoCta()
        {
            srcTransporte.Reportes.RepFiltro.Vista.IHnd _filtro = new srcTransporte.Reportes.RepFiltro.Handler.Imp();
            _filtro.Desde.setActivarCheck(false);
            _filtro.Hasta.setActivarCheck(false);
            _filtro.Inicializa();
            _filtro.setFiltrosCargar(new srcTransporte.Reportes.Caja.EdoCta.FiltroActivar());
            _filtro.Inicia();
            if (_filtro.ProcesarIsOK)
            {
                if (_filtro.Get_Filtros.IdCaja == -1)
                {
                    Helpers.Msg.Alerta("DEBES INDICAR / SELECCIONAR UNA CAJA");
                    return;
                }
                if (_filtro.Get_Filtros.Desde.HasValue == false)
                {
                    Helpers.Msg.Alerta("DEBES INDICAR FECHA INICIO DEL MOVIMIENTO");
                    return;
                }
                if (_filtro.Get_Filtros.Hasta.HasValue == false)
                {
                    Helpers.Msg.Alerta("DEBES INDICAR FECHA FINAL DEL MOVIMIENTO");
                    return;
                }
                srcTransporte.Reportes.IRepFiltro _rep = new srcTransporte.Reportes.Caja.EdoCta.Imp();
                _rep.setFiltros(_filtro.Get_Filtros);
                _rep.Generar();
            }
        }
        public void ReporteMaestroConcepto()
        {
            srcTransporte.Reportes.IRep _rep = new srcTransporte.Reportes.Maestros.Concepto.Imp();
            _rep.Generar();
        }
        public void ReportesMaestroCaja()
        {
            srcTransporte.Reportes.IRep _rep = new srcTransporte.Reportes.Maestros.Caja.Imp();
            _rep.Generar();
        }
        public void ReporteMaestroProveedorTransporte()
        {
            srcTransporte.Reportes.IRep _rep = new srcTransporte.Reportes.Maestros.Proveedor.Imp();
            _rep.Generar();
        }
        public void ReportesMaestroBeneficiairo()
        {
            srcTransporte.Reportes.IRep _rep = new srcTransporte.Reportes.Maestros.Beneficiario.Imp();
            _rep.Generar();
        }

        public void ReportesBeneficiarioMovimiento()
        {
            //srcTransporte.Reportes.CXP.Aliado.Idata _data = new srcTransporte.Reportes.CXP.Aliado.data();
            srcTransporte.Reportes.IRepFiltro _rep = new srcTransporte.Reportes.Beneficiario.Movimiento.Imp();
            _rep.setFiltros(null);
            _rep.Generar();
        }
        public void ReporteLibroSeniat()
        {
            srcTransporte.Reportes.RepFiltro.Vista.IHnd _filtro = new srcTransporte.Reportes.RepFiltro.Handler.Imp();
            _filtro.Desde.setActivarCheck(false);
            _filtro.Hasta.setActivarCheck(false);
            _filtro.Inicializa();
            _filtro.setFiltrosCargar(new srcTransporte.Reportes.Documentos.LibroSeniat.FiltroActivar());
            _filtro.Inicia();
            if (_filtro.ProcesarIsOK)
            {
                srcTransporte.Reportes.IRepFiltro _rep = new srcTransporte.Reportes.Documentos.LibroSeniat.Imp();
                _rep.setFiltros(_filtro.Get_Filtros);
                _rep.Generar();
            }
        }


        //BENEFICIARIO
        public void BeneficiarioRegMov()
        {
            srcTransporte.Beneficiario.Movimiento.Vistas.IHnd _hnd = new srcTransporte.Beneficiario.Movimiento.Handler.Imp();
            _hnd.Inicializa();
            _hnd.Inicia();
        }
        public void BeneficiarioAdm()
        {
            srcTransporte.Beneficiario.AdmMov.Vistas.IAdm _adm = new srcTransporte.Beneficiario.AdmMov.Handler.Imp();
            _adm.Inicializa();
            _adm.Inicia();
        }

        ModCompra.srcTransporte.CompraGastoAliadoPagServ.Vistas.Generar.ICompraGasto _compraAliado;
        public void RegistrarCompraAliado()
        {
            if (_compraAliado == null)
            {
                _compraAliado = new ModCompra.srcTransporte.CompraGastoAliadoPagServ.Handlres.Generar.Imp();
            }
            _compraAliado.Inicializa();
            _compraAliado.Inicia();
        }
    }
}
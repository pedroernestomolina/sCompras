﻿using System;
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
        private Administrador.Gestion _gestionAdmDoc ;
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
                return  Sistema.UsuarioP.codigoUsu +Environment.NewLine + 
                        Sistema.UsuarioP.nombreUsu +Environment.NewLine + 
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
    }
}
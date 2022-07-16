using System;
using System.Collections.Generic;
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


        public string Version
        {
            get
            {
                return "Ver. " + Application.ProductVersion;
            }
        }
        public string Host
        {
            get
            {
                return Sistema._Instancia + "/" + Sistema._BaseDatos;
            }
        }
        public string Usuario
        {
            get
            {
                var rt = "";
                rt = Sistema.UsuarioP.codigoUsu +
                    Environment.NewLine + Sistema.UsuarioP.nombreUsu +
                    Environment.NewLine + Sistema.UsuarioP.nombreGru;
                return rt;
            }
        }


        public Gestion()
        {
            _gestionAdmDoc = new Administrador.Gestion();
            _gestionRep = new Reportes.Filtros.Gestion();
            _gestionMaestro = new Maestros.Gestion();
            _gestionProveedor = new Proveedor.Administrador.Gestion();
            _gestionRepPrv = new ReporteProveedor.Gestion();
        }


        Form1 frm = null;
        public void Inicia()
        {
            if (frm == null)
            {
                frm = new Form1();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }

        public void RegistrarFacturaCompra()
        {
            var r00 = Sistema.MyData.Permiso_Registrar_Factura (Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                frm.setVisibilidadOff();

                var gestionEntrada = new Documento.Cargar.Controlador.Gestion();
                gestionEntrada.setGestion(new Documento.Cargar.Factura.GestionFac());
                gestionEntrada.Inicia();

                frm.setVisibilidadOn();
            }
        }

        public void AdministradorDoc()
        {
            var r00 = Sistema.MyData.Permiso_AdmDoc(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionAdmDoc.setGestion(new Administrador.Documentos.Gestion());
                _gestionAdmDoc.setActivarSeleccionItem(false);
                _gestionAdmDoc.Inicializa();
                _gestionAdmDoc.Inicia();
            }
        }

        public void ReporteGeneralDocumentos()
        {
            var r00 = Sistema.MyData.Permiso_Reportes(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionRep.setGestion(new Reportes.Filtros.GeneralDocumentos.Gestion());
                _gestionRep.Inicia();
            }
        }

        public void ReporteComprasDepartamentos()
        {
            var r00 = Sistema.MyData.Permiso_Reportes(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionRep.setGestion(new Reportes.Filtros.CompraDepartamentos.Gestion());
                _gestionRep.Inicia();
            }
        }

        public void ReporteComprasPorProducto()
        {
            var r00 = Sistema.MyData.Permiso_Reportes(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionRep.setGestion(new Reportes.Filtros.CompraPorProductos.Gestion());
                _gestionRep.Inicia();
            }
        }

        public void ReporteComprasDetalleProducto()
        {
            var r00 = Sistema.MyData.Permiso_Reportes(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionRep.setGestion(new Reportes.Filtros.CompraDetalleProducto.Gestion());
                _gestionRep.Inicia();
            }
        }

        public void RegistrarNcCompra()
        {
            var r00 = Sistema.MyData.Permiso_Registrar_Nc(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                frm.setVisibilidadOff();

                var gestionEntrada = new Documento.Cargar.Controlador.Gestion();
                gestionEntrada.setGestion(new Documento.Cargar.NotaCredito.GestionNc());
                gestionEntrada.Inicia();

                frm.setVisibilidadOn();
            }
        }

        public void MaestrosGrupos()
        {
            var r00 = Sistema.MyData.Permiso_Grupo(Sistema.UsuarioP.autoGru);
            if (r00.Result ==  OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionMaestro.setGestion(new Maestros.Grupo.Gestion());
                _gestionMaestro.Inicia();
            }
        }

        public void MaestroProveedor()
        {
            var r00 = Sistema.MyData.Permiso_Proveedor(Sistema.UsuarioP.autoGru);
            if (r00.Result ==  OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
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
            var r00 = Sistema.MyData.Permiso_Proveedor_Reportes(Sistema.UsuarioP.autoGru);
            if (r00.Result ==  OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionRepPrv.setGestion(gestion);
                _gestionRepPrv.Inicializa();
                _gestionRepPrv.Inicia();
            }
        }
    }

}
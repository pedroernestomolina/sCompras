using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    
    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<string> 
            Permiso_PedirClaveAcceso_NivelMaximo()
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Permiso_PedirClaveAcceso_NivelMaximo();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }
        public OOB.ResultadoEntidad<string> 
            Permiso_PedirClaveAcceso_NivelMedio()
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Permiso_PedirClaveAcceso_NivelMedio();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }
        public OOB.ResultadoEntidad<string> 
            Permiso_PedirClaveAcceso_NivelMinimo()
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Permiso_PedirClaveAcceso_NivelMinimo();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_ToolCompra(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_ToolCompra, autoGrupoUsuario);
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_Registrar_Factura(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_Registrar_Factura, autoGrupoUsuario);
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_Registrar_Nc(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_Registrar_Nc, autoGrupoUsuario);
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_AdmDoc(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_AdmDoc, autoGrupoUsuario);
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>
            Permiso_AdmDoc_Anular(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_AdmDoc_Anular, autoGrupoUsuario);
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>
            Permiso_AdmDoc_Visualizar(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_AdmDoc_Visualizar, autoGrupoUsuario);
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_AdmDoc_Reporte(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_AdmDoc_Reporte, autoGrupoUsuario);
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>
            Permiso_AdmDoc_Corrector(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_AdmDoc_Corrector, autoGrupoUsuario);
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_Reportes(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_Reportes, autoGrupoUsuario);
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_Grupo(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_Grupo, autoGrupoUsuario);
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_CrearGrupo(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_CrearGrupo, autoGrupoUsuario);
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_ModificarGrupo(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_ModificarGrupo, autoGrupoUsuario);
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>
            Permiso_Proveedor(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_Proveedor, autoGrupoUsuario);
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>
            Permiso_Proveedor_Agregar(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_Proveedor_Agregar, autoGrupoUsuario);
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_Proveedor_Editar(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_Proveedor_Editar, autoGrupoUsuario);
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_Proveedor_CambiarEstatus(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_Proveedor_CambiarEstatus, autoGrupoUsuario);
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_Proveedor_Reportes(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_Proveedor_Reportes, autoGrupoUsuario);
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_RegistrarFactura_ProcesarDocumento(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_RegistrarFactura_ProcesarDocumento, autoGrupoUsuario);
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_RegistrarFactura_CambiarPrecioVenta(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_RegistrarFactura_CambiarPrecioVenta, autoGrupoUsuario);
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> 
            Permiso_ConfiguracionSistema(string autoGrupoUsuario)
        {
            return Helpers.PermisoRt(MyData.Permiso_ConfiguracionSistema, autoGrupoUsuario);
        }

    }

}
using LibEntityCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCompra
{
    
    public partial class Provider: ILibCompras.IProvider
    {

        public DtoLib.ResultadoEntidad<string>
            Permiso_PedirClaveAcceso_NivelMaximo()
        {
            var result = new DtoLib.ResultadoEntidad<string>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var ent = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL17");
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] CONFIGURACION NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }

                    result.Entidad = ent.usuario.Trim().ToUpper();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.ResultadoEntidad<string> 
            Permiso_PedirClaveAcceso_NivelMedio()
        {
            var result = new DtoLib.ResultadoEntidad<string>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var ent = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL18");
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] CONFIGURACION NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }

                    result.Entidad = ent.usuario.Trim().ToUpper();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.ResultadoEntidad<string> 
            Permiso_PedirClaveAcceso_NivelMinimo()
        {
            var result = new DtoLib.ResultadoEntidad<string>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var ent = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL19");
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] CONFIGURACION NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }

                    result.Entidad = ent.usuario.Trim().ToUpper();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_ToolCompra(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0720000000");
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_Registrar_Factura(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0701000000");
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_Registrar_Nc(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0704000000");
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_AdmDoc(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0705000000");
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_AdmDoc_Anular(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0705010000");
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_AdmDoc_Visualizar(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0705020000");
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_AdmDoc_Reporte(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0705030000");
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_AdmDoc_Corrector(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0705040000");
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_Reportes(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0799000000");
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha>
            Permiso_Grupo(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0202000000");
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha>
            Permiso_CrearGrupo(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0202010000");
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_ModificarGrupo(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0202020000");
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_Proveedor(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0201000000");
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_Proveedor_Agregar(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0201010000");
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_Proveedor_Editar(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0201020000");
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_Proveedor_CambiarEstatus(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0201040000");
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha>
            Permiso_Proveedor_Reportes(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0299000000");
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_RegistrarFactura_ProcesarDocumento(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0701010000");
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_RegistrarFactura_CambiarPrecioVenta(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "0701020000");
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha> 
            Permiso_ConfiguracionSistema(string autoGrupoUsuario)
        {
            return Helpers.Permiso_Modulo(autoGrupoUsuario, "1202000000");
        }

    }

}
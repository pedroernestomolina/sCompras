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

        public OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMaximo()
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

        public OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMedio()
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

        public OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMinimo()
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


        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_ToolCompra(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_ToolCompra(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }


        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Registrar_Factura(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_Registrar_Factura(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Registrar_Nc(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_Registrar_Nc(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }


        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_AdmDoc(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc_Anular(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_AdmDoc_Anular(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc_Visualizar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_AdmDoc_Visualizar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc_Reporte(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_AdmDoc_Reporte(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Reportes(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_Reportes (autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc_Corrector(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_AdmDoc_Corrector (autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }


        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Grupo(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_Grupo(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_CrearGrupo(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_CrearGrupo(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_ModificarGrupo(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_ModificarGrupo(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Proveedor(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_Proveedor(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Proveedor_Agregar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_Proveedor_Agregar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Proveedor_Editar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_Proveedor_Editar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Proveedor_CambiarEstatus(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_Proveedor_CambiarEstatus(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Proveedor_Reportes(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var r01 = MyData.Permiso_Proveedor_Reportes(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibCompra.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}
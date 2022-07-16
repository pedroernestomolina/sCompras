using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IPermiso
    {

        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMaximo();
        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMedio();
        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMinimo();

        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Grupo(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_CrearGrupo(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_ModificarGrupo(string autoGrupoUsuario);
         
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_ToolCompra(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Registrar_Factura(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Registrar_Nc(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc_Anular(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc_Visualizar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc_Reporte(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc_Corrector(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Reportes(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Proveedor(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Proveedor_Agregar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Proveedor_Editar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Proveedor_CambiarEstatus(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Proveedor_Reportes(string autoGrupoUsuario);

    }

}
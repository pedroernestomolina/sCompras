using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    
    public class Helpers
    {

        public static OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>
         PermisoRt(Func<string, DtoLib.ResultadoEntidad<DtoLibCompra.Permiso.Ficha>> met, string grupo)
        {
            var rs = new OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha>();

            var rt = met(grupo);
            if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rs.Mensaje = rt.Mensaje;
                rs.Result = OOB.Enumerados.EnumResult.isError; 
                return rs;
            }
            var s = rt.Entidad;
            var nr = new OOB.LibCompra.Permiso.Ficha()
            {
                estatus = s.estatus,
                seguridad = s.seguridad,
            };
            rs.Entidad = nr;

            return rs;
        }
    }

}
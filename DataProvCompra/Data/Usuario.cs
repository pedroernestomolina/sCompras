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

        public OOB.ResultadoEntidad<OOB.LibCompra.Usuario.Data.Ficha> Usuario_Principal()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Usuario.Data.Ficha>();

            var r01 = MyData.Usuario_Principal();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Usuario.Data.Ficha()
            {
                autoUsu = s.autoUsu,
                codigoUsu = s.codigoUsu,
                nombreUsu = s.nombreUsu,
                apellidoUsu = s.apellidoUsu,
                isActivo = s.isActivo,
                autoGru = s.autoGru,
                nombreGru = s.nombreGru,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Usuario.Data.Ficha> Usuario_Cargar(OOB.LibCompra.Usuario.Buscar.Ficha ficha)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Usuario.Data.Ficha>();

            var fichaBuscar = new DtoLibCompra.Usuario.Buscar.Ficha()
            {
                codigo = ficha.codigo,
                clave = ficha.clave,
            };
            var r01 = MyData.Usuario_Buscar(fichaBuscar);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var u = r01.Entidad;
            var nr = new OOB.LibCompra.Usuario.Data.Ficha()
            {
                autoUsu = u.autoUsu,
                codigoUsu = u.codigoUsu,
                nombreUsu = u.nombreUsu,
                apellidoUsu = u.apellidoUsu,
                isActivo = u.isActivo,
                autoGru = u.autoGru,
                nombreGru = u.nombreGru,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.Resultado Usuario_ActualizarSesion(OOB.LibCompra.Usuario.ActualizarSesion.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibCompra.Usuario.ActualizarSesion.Ficha()
            {
                autoUsu = ficha.autoUsu
            };
            var r01 = MyData.Usuario_ActualizarSesion(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

    }

}
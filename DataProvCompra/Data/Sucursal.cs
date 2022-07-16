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

        public OOB.ResultadoLista<OOB.LibCompra.Sucursal.Data.Ficha> Sucursal_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Sucursal.Data.Ficha>();

            var r01 = MyData.Sucursal_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Sucursal.Data.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCompra.Sucursal.Data.Ficha()
                        {
                            auto = s.auto,
                            codigo = s.codigo,
                            nombre = s.nombre,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Sucursal.Data.Ficha> Sucursal_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Sucursal.Data.Ficha>();

            var r01 = MyData.Sucursal_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Sucursal.Data.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
                autoDepositoPrincipal = s.autoDepositoPrincipal,
                codigoDepositoPrincipal = s.codigoDepositoPrincipal,
                nombreDepositoPrincipal = s.nombreDepositoPrincipal,
                autoEmpresaGrupo = s.autoEmpresaGrupo,
                nombreEmpresaGrupo = s.nombreEmpresaGrupo,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}
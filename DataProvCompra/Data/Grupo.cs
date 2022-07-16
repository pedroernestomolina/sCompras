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

        public OOB.ResultadoLista<OOB.LibCompra.Maestros.Grupo.Ficha> Grupo_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Maestros.Grupo.Ficha>();

            var r01 = MyData.Grupo_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Maestros.Grupo.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCompra.Maestros.Grupo.Ficha()
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

        public OOB.ResultadoEntidad<OOB.LibCompra.Maestros.Grupo.Ficha> Grupo_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Maestros.Grupo.Ficha>();

            var r01 = MyData.Grupo_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Maestros.Grupo.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoAuto Grupo_Agregar(OOB.LibCompra.Maestros.Grupo.Agregar ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibCompra.Maestros.Grupo.Agregar()
            {
                nombre = ficha.nombre,
                codigo = ficha.codigo,
            };
            var r01 = MyData.Grupo_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }

        public OOB.Resultado Grupo_Editar(OOB.LibCompra.Maestros.Grupo.Editar ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibCompra.Maestros.Grupo.Editar()
            {
                auto = ficha.auto,
                nombre = ficha.nombre,
                codigo = ficha.codigo,
            };
            var r01 = MyData.Grupo_Editar(fichaDTO);
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
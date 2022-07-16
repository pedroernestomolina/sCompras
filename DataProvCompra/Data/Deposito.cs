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

        public OOB.ResultadoLista<OOB.LibCompra.Deposito.Data.Ficha> Deposito_GetLista(OOB.LibCompra.Deposito.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Deposito.Data.Ficha>();

            var filtroDTO = new DtoLibCompra.Deposito.Lista.Filtro() { PorCodigoSuc = filtro.PorCodigoSuc };
            var r01 = MyData.Deposito_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Deposito.Data.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCompra.Deposito.Data.Ficha()
                        {
                            auto = s.id,
                            codigo = s.codigo,
                            nombre = s.nombre,
                            codigoSucursal = s.codigoSuc,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Deposito.Data.Ficha> Deposito_GetFicha(string autoDeposito)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Deposito.Data.Ficha>();

            var r01 = MyData.Deposito_GetFicha(autoDeposito);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Deposito.Data.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
                autoSucursal = s.autoSucursal,
                codigoSucursal = s.codigoSucursal,
                nombreSucursal = s.nombreSucursal,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}
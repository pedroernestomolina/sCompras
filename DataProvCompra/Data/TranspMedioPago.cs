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
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.MedioPago.Lista.Ficha> 
            Transporte_MedioPago_GetLista()
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.MedioPago.Lista.Ficha>();
            var r01 = MyData.Transporte_MedioPago_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.MedioPago.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.MedioPago.Lista.Ficha()
                        {
                            codigo = s.codigo,
                            id = s.id,
                            nombre = s.nombre,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.MedioPago.Entidad.Ficha> 
            Transporte_MedioPago_GetFichaById(string id)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.MedioPago.Entidad.Ficha>();
            var r01 = MyData.Transporte_MedioPago_GetFichaById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s= r01.Entidad;
            result.Entidad = new OOB.LibCompra.Transporte.MedioPago.Entidad.Ficha()
            {
                codigo = s.codigo,
                id = s.id,
                nombre = s.nombre,
            };
            return result;
        }
    }
}
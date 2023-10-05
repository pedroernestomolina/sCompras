using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    public partial class DataProv : IData
    {
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Ficha> 
            Transporte_DocumentoRet_GetLista(OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Ficha>();
            var filtroDTO = new DtoLibTransporte.DocumentoRet.ListaAdm.Filtro()
            {
                Desde = filtro.Desde,
                Estatus = filtro.Estatus,
                Hasta = filtro.Hasta,
                IdProveedor = filtro.IdProveedor,
                TipoRetencion = filtro.TipoRetencion,
            };
            var r01 = MyData.Transporte_DocumentoRet_GetLista (filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Ficha()
                        {
                            auto = s.auto,
                            autoDocRef=s.autoDocRef,
                            documentoNro = s.documentoNro,
                            fechaEmision = s.fechaEmision,
                            provCiRif = s.provCiRif,
                            provNombre = s.provNombre,
                            retMonto = s.retMonto,
                            retTasa = s.retTasa,
                            tipoRetCod = s.tipoRetCod,
                            tipoRetDesc = s.tipoRetDesc,
                            estatusAnulado = s.estatusAnulado,
                            signoRet= s.signoRet,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
    }
}
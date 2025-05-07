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
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.CxpDoc.DocPend.Ficha>
            Transporte_CxpDoc_GetLista_DocPend(OOB.LibCompra.Transporte.CxpDoc.DocPend.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.CxpDoc.DocPend.Ficha>();
            //
            var filtroDto = new DtoLibTransporte.CxpDoc.DocPend.Filtro()
            {
                CadenaBusq = filtro.CadenaBusq,
                IdEntidad = filtro.IdEntidad,
            };
            var r01 = MyData.Transporte_CxpDoc_GetLista_DocPend(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.CxpDoc.DocPend.Ficha>();
            if (r01 != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.CxpDoc.DocPend.Ficha()
                        {
                            acumuladoDiv = s.acumuladoDiv,
                            ciRif = s.ciRif,
                            diasCredito = s.diasCredito,
                            docNro = s.docNro,
                            fechaEmision = s.fechaEmision,
                            fechaVence = s.fechaVence,
                            id = s.idCxP,
                            importeDiv = s.importeDiv,
                            nombreRazonSocial = s.nombreRazonSocial,
                            restaDiv = s.restaDiv,
                            signoDoc = s.signoDoc,
                            tasafactor = s.tasafactor,
                            tipoDoc = s.tipoDoc,
                            idDocOrigen = s.idDocOrigen,
                            idEntidad = s.idEntidad,
                            diasVencida = s.diasvencida,
                            notasDoc= s.notasDoc,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            //
            return result;
        }
    }
}
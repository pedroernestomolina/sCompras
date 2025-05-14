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
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.CxpDoc.GetInfoEntidad.Ficha>
            Transporte_CxpDoc_GetInfo_Entidad(string id)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.CxpDoc.GetInfoEntidad.Ficha>();
            //
            var r01 = MyData.Transporte_CxpDoc_GetInfo_Entidad(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.CxpDoc.GetInfoEntidad.DocPendiente>();
            var ent = new OOB.LibCompra.Transporte.CxpDoc.GetInfoEntidad.Entidad();
            if (r01 != null)
            {
                if (r01.Entidad != null)
                {
                    if (r01.Entidad.DocPendentes.Count > 0)
                    {
                        lst = r01.Entidad.DocPendentes.Select(s =>
                        {
                            var nr = new OOB.LibCompra.Transporte.CxpDoc.GetInfoEntidad.DocPendiente()
                            {
                                acumuladoDiv = s.acumuladoDiv,
                                ciRif = s.ciRif,
                                diasCredito = s.diasCredito,
                                docNro = s.docNro,
                                fechaEmision = s.fechaEmision,
                                fechaVence = s.fechaVence,
                                idCxP = s.idCxP,
                                importeDiv = s.importeDiv,
                                nombreRazonSocial = s.nombreRazonSocial,
                                restaDiv = s.restaDiv,
                                signoDoc = s.signoDoc,
                                tasafactor = s.tasafactor,
                                tipoDoc = s.tipoDoc,
                                idDocOrigen = s.idDocOrigen,
                                idEntidad = s.idEntidad,
                                diasvencida = s.diasvencida,
                                notasDoc = s.notasDoc,
                            };
                            return nr;
                        }).ToList();
                    }
                    if (r01.Entidad.Entidad != null) 
                    {
                        var _f= r01.Entidad.Entidad;
                        ent = new OOB.LibCompra.Transporte.CxpDoc.GetInfoEntidad.Entidad()
                        {
                            anticiposEntidad = _f.anticiposEntidad,
                            ciRifEntidad = _f.ciRifEntidad,
                            codigoEntidad = _f.codigoEntidad,
                            dirFiscalEntidad = _f.dirFiscalEntidad,
                            idEntidad = _f.idEntidad,
                            nombreRazonSocialEntidad = _f.nombreRazonSocialEntidad,
                            telfEntidad = _f.telfEntidad,
                        };
                    }
                }
            }
            result.Entidad = new OOB.LibCompra.Transporte.CxpDoc.GetInfoEntidad.Ficha()
            {
                DocPendentes = lst,
                Entidad = ent,
            };
            //
            return result;
        }
    }
}
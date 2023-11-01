﻿using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    public partial class DataProv: IData
    {
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.CxpDoc.DocPend.Ficha> 
            Transporte_CxpDoc_GetLista_DocPend()
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.CxpDoc.DocPend.Ficha>();
            var r01 = MyData.Transporte_CxpDoc_GetLista_DocPend();
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
                            id = s.id,
                            importeDiv = s.importeDiv,
                            nombreRazonSocial = s.nombreRazonSocial,
                            restaDiv = s.restaDiv,
                            signoDoc = s.signoDoc,
                            tasafactor = s.tasafactor,
                            tipoDoc = s.tipoDoc,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.CxpDoc.DocEntidad.Ficha> 
            Transporte_CxpDoc_GetDocPend_ById(string idCxP)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.CxpDoc.DocEntidad.Ficha>();
            var r01 = MyData.Transporte_CxpDoc_GetDocPend_ById(idCxP);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            if (r01 != null)
            {
                var s= r01.Entidad;
                result.Entidad = new OOB.LibCompra.Transporte.CxpDoc.DocEntidad.Ficha()
                {
                    acumuladoDiv = s.acumuladoDiv,
                    ciRif = s.ciRif,
                    diasCredito = s.diasCredito,
                    docNro = s.docNro,
                    fechaEmision = s.fechaEmision,
                    fechaVence = s.fechaVence,
                    id = s.id,
                    importeDiv = s.importeDiv,
                    nombreRazonSocial = s.nombreRazonSocial,
                    restaDiv = s.restaDiv,
                    signoDoc = s.signoDoc,
                    tasafactor = s.tasafactor,
                    tipoDoc = s.tipoDoc,
                    anoRelacion = s.anoRelacion,
                    autoProv = s.autoProv,
                    codProv = s.codProv,
                    codTipoDoc = s.codTipoDoc,
                    conceptoCod = s.conceptoCod,
                    conceptoDesc = s.conceptoDesc,
                    descripcionDoc = s.descripcionDoc,
                    docNroControl = s.docNroControl,
                    fechaReg = s.fechaReg,
                    mesRelacion = s.mesRelacion,
                    condicion = s.condicion,
                };
            }
            return result;
        }
    }
}
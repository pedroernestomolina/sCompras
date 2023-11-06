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
                var s = r01.Entidad;
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
                    dirFiscalPrv = s.dirFiscalPrv,
                    telefonoPrv = s.telefonoPrv,
                };
            }
            return result;
        }
        //
        public OOB.Resultado
            Transporte_CxpDoc_GestionPago_Agregar(OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.Ficha ficha)
        {
            var result = new OOB.Resultado();
            var rec = ficha.Recibo;
            var fichaDTO = new DtoLibTransporte.CxpDoc.Pago.Agregar.Ficha()
            {
                Recibo = new DtoLibTransporte.CxpDoc.Pago.Agregar.DataRecibo()
                {
                    importeMonAct = rec.importeMonAct,
                    importeDivisa = rec.importeDivisa,
                    montoRecibidoMonAct = rec.montoRecibidoMonAct,
                    montoRecibidoDivisa = rec.montoRecibidoDivisa,
                    nota = rec.nota,
                    prvAuto = rec.prvAuto,
                    prvCiRif = rec.prvCiRif,
                    prvCodigo = rec.prvCodigo,
                    prvDirFiscal = rec.prvDirFiscal,
                    prvNombre = rec.prvNombre,
                    prvTlf = rec.prvTlf,
                    tasaCambio = rec.tasaCambio,
                    usuarioAuto = rec.usuarioAuto,
                    usuarioNombre = rec.usuarioNombre,
                    autoSistemaDoc = rec.autoSistemaDoc,
                    codSistemaDoc = rec.codSistemaDoc,
                    reciboDoc = rec.reciboDoc.Select(s =>
                    {
                        var nr = new DtoLibTransporte.CxpDoc.Pago.Agregar.DataReciboDoc()
                        {
                            autoCxpDoc = s.autoCxpDoc,
                            codTipoDc = s.codTipoDc,
                            importeDivisa = s.importeDivisa,
                            numDoc = s.numDoc,
                        };
                        return nr;
                    }).ToList(),
                }
            };
            var r01 = MyData.Transporte_CxpDoc_GestionPago_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return result;
        }
    }
}
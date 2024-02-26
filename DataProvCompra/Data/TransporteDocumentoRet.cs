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
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.DocumentoRet.Crud.Corrector.ObtenerData.Ficha> 
            Transporte_DocumentoRet_Crud_Corrector_ObtenerData(string idDoc)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.DocumentoRet.Crud.Corrector.ObtenerData.Ficha>();
            //
            var r01 = MyData.Transporte_DocumentoRet_Crud_Corrector_ObtenerData(idDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            result.Entidad = new OOB.LibCompra.Transporte.DocumentoRet.Crud.Corrector.ObtenerData.Ficha()
            {
                anoRelRet = s.anoRelRet,
                aplica = s.aplica,
                base1 = s.base1,
                base2 = s.base2,
                base3 = s.base3,
                comprobanteRet = s.comprobanteRet,
                exento = s.exento,
                fechaEmiDoc = s.fechaEmiDoc,
                fechaRet = s.fechaRet,
                impuesto1 = s.impuesto1,
                impuesto2 = s.impuesto2,
                impuesto3 = s.impuesto3,
                mesRelRet = s.mesRelRet,
                totalRet = s.totalRet,
                numControlDoc = s.numControlDoc,
                numDoc = s.numDoc,
                prvCiRif = s.prvCiRif,
                prvNombre = s.prvNombre,
                prvDirFiscal=s.prvDirFiscal,
                retencion1 = s.retencion1,
                retencion2 = s.retencion2,
                retencion3 = s.retencion3,
                tasa1 = s.tasa1,
                tasa2 = s.tasa2,
                tasa3 = s.tasa3,
                tasaRet = s.tasaRet,
                tipoDoc = s.tipoDoc,
                total = s.total,
                conceptoCod = s.conceptoCod,
                conceptoDoc = s.conceptoDoc,
                subtRet = s.subtRet,
                sustraendoRet = s.sustraendoRet,
                codXmlIslr = s.codXmlIslr,
                descXmlIslr = s.descXmlIslr,
                maquinaFiscal=s.maquinaFiscal,
            };
            return result;
        }
    }
}
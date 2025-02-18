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
        public OOB.ResultadoEntidad<OOB.LibCompra.Documento.Corrector.GetData.Ficha>
            Compra_DocumentoCorrector_GetData(string idDoc)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Documento.Corrector.GetData.Ficha>();
            //
            var r01 = MyData.Compra_DocumentoCorrector_GetData_ByIdDoc(idDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                throw new Exception(r01.Mensaje);
            }
            var s= r01.Entidad;
            var ent = new OOB.LibCompra.Documento.Corrector.GetData.Ficha()
            {
                anoRelacion = s.anoRelacion,
                autoId = s.autoId,
                controlNro = s.controlNro,
                diasCredito = s.diasCredito,
                documentoNombre = s.documentoNombre,
                documentoNro = s.documentoNro,
                documentoSerie = s.documentoSerie,
                documentoTipo = s.documentoTipo,
                estatusAnulado = s.estatusAnulado,
                estatusAplicaLibroSeniat = s.estatusAplicaLibroSeniat,
                fechaEmision = s.fechaEmision,
                fechaRegistro = s.fechaRegistro,
                fechaVencimiento = s.fechaVencimiento,
                mesRelacion = s.mesRelacion,
                montoBase = s.montoBase,
                montoBase1 = s.montoBase1,
                montoBase2 = s.montoBase2,
                montoBase3 = s.montoBase3,
                montoExento = s.montoExento,
                montoImpuesto = s.montoImpuesto,
                montoIva1 = s.montoIva1,
                montoIva2 = s.montoIva2,
                montoIva3 = s.montoIva3,
                montoTotal = s.montoTotal,
                notas = s.notas,
                ordenCompraNro = s.ordenCompraNro,
                provId=s.provId,
                provCiRif = s.provCiRif,
                provCodigo = s.provCodigo,
                provDirFiscal = s.provDirFiscal,
                provNombre = s.provNombre,
                provTelefono = s.provTelefono,
                subTotal = s.subTotal,
                tasaIva1 = s.tasaIva1,
                tasaIva2 = s.tasaIva2,
                tasaIva3 = s.tasaIva3,
            };
            rt.Entidad=ent;
            //
            return rt;
        }
        public OOB.Resultado
            Compra_DocumentoCorrector_ActualizarData(OOB.LibCompra.Documento.Corrector.ActualizarData.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            //
            var fichaDTO = new DtoLibCompra.Documento.Corrector.ActualizarData.Ficha()
            {
                autoId = ficha.autoId,
                controlNro = ficha.controlNro,
                documentoNro = ficha.documentoNro,
                fechaEmision = ficha.fechaEmision,
                montoBase = ficha.montoBase,
                montoBase1 = ficha.montoBase1,
                montoBase2 = ficha.montoBase2,
                montoBase3 = ficha.montoBase3,
                montoExento = ficha.montoExento,
                montoImpuesto = ficha.montoImpuesto,
                montoIva1 = ficha.montoIva1,
                montoIva2 = ficha.montoIva2,
                montoIva3 = ficha.montoIva3,
                montoTotal = ficha.montoTotal,
                notas = ficha.notas,
                provCiRif = ficha.provCiRif,
                provCodigo = ficha.provCodigo,
                provDirFiscal = ficha.provDirFiscal,
                provId = ficha.provId,
                provNombre = ficha.provNombre,
                provTelefono = ficha.provTelefono,
                subTotal = ficha.subTotal,
            };
            var r01 = MyData.Compra_DocumentoCorrector_Actualizar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            //
            return rt;
        }
        //
        public OOB.Resultado
            Compra_DocumentoCorrector(OOB.LibCompra.Documento.Corrector.Ficha ficha)
        {
            var rt = new OOB.Resultado();
            //
            var fichaDTO = new DtoLibCompra.Documento.Corrector.Factura.Ficha()
            {
                autoDoc = ficha.autoDoc,
                autoProveedor = ficha.autoProveedor,
                ciRifProveedor = ficha.ciRifProveedor,
                controlNro = ficha.controlNro,
                direccionFiscalProveedor = ficha.direccionFiscalProveedor,
                documentoNro = ficha.documentoNro,
                fechaDocumento = ficha.fechaDocumento,
                nombreRazonSocialProveedor = ficha.nombreRazonSocialProveedor,
                notaDocumento = ficha.notaDocumento,
            };
            var r01 = MyData.Compra_DocumentoCorrectorFactura(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            //
            return rt;
        }
    }
}

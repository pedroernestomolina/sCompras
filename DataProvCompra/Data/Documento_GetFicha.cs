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
        public OOB.ResultadoEntidad<OOB.LibCompra.Documento.GetData.Ficha>
            Compra_DocumentoGetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Documento.GetData.Ficha>();
            //
            var r01 = MyData.Compra_DocumentoGetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Documento.GetData.Ficha()
            {
                anoRelacion = s.anoRelacion,
                cargoPorct = s.cargoPorct,
                controlNro = s.controlNro,
                descuentoPorct = s.descuentoPorct,
                diasCredito = s.diasCredito,
                documentoNombre = s.documentoNombre,
                documentoNro = s.documentoNro,
                documentoSerie = s.documentoSerie,
                equipoEstacion = s.equipoEstacion,
                factorCambio = s.factorCambio,
                fechaEmision = s.fechaEmision,
                fechaRegistro = s.fechaRegistro,
                fechaVencimiento = s.fechaVencimiento,
                mesRelacion = s.mesRelacion,
                montoBase = s.montoBase,
                montoBase1 = s.montoBase1,
                montoBase2 = s.montoBase2,
                montoBase3 = s.montoBase3,
                montoCargo = s.montoCargo,
                montoDescuento = s.montoDescuento,
                montoDivisa = s.montoDivisa,
                montoExento = s.montoExento,
                montoImpuesto = s.montoImpuesto,
                montoTotal = s.montoTotal,
                notas = s.notas,
                ordenCompraNro = s.ordenCompraNro,
                provCiRif = s.provCiRif,
                provCodigo = s.provCodigo,
                provDirFiscal = s.provDirFiscal,
                provNombre = s.provNombre,
                provTelefono = s.provTelefono,
                renglones = s.renglones,
                signo = s.signo,
                subTotal = s.subTotal,
                tasaIva1 = s.tasaIva1,
                tasaIva2 = s.tasaIva2,
                tasaIva3 = s.tasaIva3,
                usuarioCodigo = s.usuarioCodigo,
                usuarioNombre = s.usuarioNombre,
                montoIva1 = s.montoIva1,
                montoIva2 = s.montoIva2,
                montoIva3 = s.montoIva3,
                horaRegistro = s.horaRegistro,
                autoId = s.autoId,
                documentoTipo = s.documentoTipo,
                provAuto = s.provAuto,
                codigoSucursal = s.codigoSucursal,
                //
                AplicaLibroSeniat = s.estatusAplicaLibroSeniat == "1" ? true : false,
                DescSucursal = s.descSucursal,
                IdSucursal = s.idSucursal,
                EstatusDocTipoMercancia = s.estatusMercanciaGasto == "1" ? true : false,
            };
            var det = s.detalles.Select(ss =>
            {
                var dt = new OOB.LibCompra.Documento.GetData.FichaDetalle()
                {
                    cntFactura = ss.cntFactura,
                    contenido = ss.contenido,
                    depositoAuto = ss.depositoAuto,
                    depositoCodigo = ss.depositoCodigo,
                    depositoNombre = ss.depositoNombre,
                    dscto1m = ss.dscto1m,
                    dscto1p = ss.dscto1p,
                    dscto2m = ss.dscto2m,
                    dscto2p = ss.dscto2p,
                    dscto3m = ss.dscto3m,
                    dscto3p = ss.dscto3p,
                    empaqueCompra = ss.empaqueCompra,
                    importe = ss.importe,
                    prdCodigo = ss.prdCodigo,
                    prdNombre = ss.prdNombre,
                    precioFactura = ss.precioFactura,
                    tasaIva = ss.tasaIva,
                    prdAuto = ss.prdAuto,
                    CodRefPrv = ss.codigoReferenciaProveedor,
                    prdAutoDepartamento = ss.prdAutoDepartamento,
                    prdAutoGrupo = ss.prdAutoGrupo,
                    prdAutoTasaIva = ss.prdAutoTasaIva,
                    decimales = ss.decimales,
                    categoria = ss.categoria,
                };
                return dt;
            }).ToList();
            nr.detalles = det;
            rt.Entidad = nr;
            //
            return rt;
        }
    }
}
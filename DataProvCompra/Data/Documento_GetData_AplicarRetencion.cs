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
        public OOB.ResultadoEntidad<OOB.LibCompra.Documento.GetData.AplicarRetencion.Ficha> 
            Compra_GetData_AplicarRetencion(string idDocCompra)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Documento.GetData.AplicarRetencion.Ficha>();
            //
            var r01 = MyData.Compra_GetData_AplicarRetencion(idDocCompra);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Documento.GetData.AplicarRetencion.Ficha()
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
                autoId = s.idDocCompra,
                documentoTipo = s.documentoTipo,
                provAuto = s.provAuto,
                codigoSucursal = s.codigoSucursal,
                AplicaLibroSeniat = s.estatusAplicaLibroSeniat == "1" ? true : false,
                DescSucursal = s.descSucursal,
                IdSucursal = s.idSucursal,
                EstatusDocTipoMercancia = s.estatusMercanciaGasto == "1" ? true : false,
                idDocCxp = s.idDocCxp,
                AplicaRetencionISLR = string.IsNullOrEmpty(s.estatusAplicaRetIslr) ? false : true,
                AplicaRetencionIva = string.IsNullOrEmpty(s.estatusAplicaRetIva) ? false : true,
            };
            rt.Entidad = nr;
            //
            return rt;
        }
    }
}

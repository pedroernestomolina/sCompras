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
        public OOB.ResultadoEntidad<OOB.LibCompra.Documento.Visualizar.Ficha> 
            Compra_DocumentoVisualizar(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Documento.Visualizar.Ficha>();
            //
            var r01 = MyData.Compra_DocumentoVisualizar(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            if (r01.Entidad == null)
            {
                rt.Mensaje = "DOCUMENTO NO INICIALIZADO";
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            if (r01.Entidad.encabezado == null)
            {
                rt.Mensaje = "ENCABEZADO NO INICIALIZADO";
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var s = r01.Entidad.encabezado;
            var _enc = new OOB.LibCompra.Documento.Visualizar.Encabezado()
            {
                anoRelacion = s.anoRelacion,
                cargoPorct = s.cargoPorct,
                controlNro = s.controlNro,
                descuentoPorct = s.descuentoPorct,
                diasCredito = s.diasCredito,
                documentoNombre = s.documentoNombre,
                documentoNro = s.documentoNro,
                documentoSerie = s.documentoSerie,
                documentoTipo = s.documentoTipo,
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
                aplica = s.aplica,
                estatusDoc = s.EstatusDoc,
                idDoc = s.idDoc,
            };
            var _det = new List<OOB.LibCompra.Documento.Visualizar.Detalle>();
            if (r01.Entidad.detalles != null)
            {
                if (r01.Entidad.detalles.Count > 0) 
                {
                    _det = r01.Entidad.detalles.Select(ss =>
                    {
                        var dt = new OOB.LibCompra.Documento.Visualizar.Detalle()
                        {
                            cntFactura = ss.cntFactura,
                            contenido = ss.contenido,
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
                        };
                        return dt;
                    }).ToList();
                }
            }
            rt.Entidad = new OOB.LibCompra.Documento.Visualizar.Ficha()
            {
                encabezado = _enc,
                detalles = _det,
            };
            //
            return rt;
        }
    }
}
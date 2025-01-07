using LibEntityCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCompra
{
    public partial class Provider : ILibCompras.IProvider
    {
        public DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Cargar.Ficha> 
            Compra_DocumentoGetFicha(string autoDoc)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Cargar.Ficha>();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var ent = cnn.compras.Find(autoDoc);
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] DOCUMENTO NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    var det = cnn.compras_detalle.Where(f => f.auto_documento == autoDoc).ToList();
                    var doc = new DtoLibCompra.Documento.Cargar.Ficha()
                    {
                        autoId = ent.auto,
                        anoRelacion = ent.ano_relacion,
                        cargoPorct = ent.cargosp,
                        controlNro = ent.control,
                        descuentoPorct = ent.descuento1p,
                        diasCredito = ent.dias,
                        documentoNombre = ent.documento_nombre,
                        documentoNro = ent.documento,
                        documentoSerie = ent.serie,
                        documentoTipo = ent.tipo,
                        equipoEstacion = ent.estacion,
                        factorCambio = ent.factor_cambio,
                        fechaEmision = ent.fecha,
                        fechaRegistro = ent.fecha_registro,
                        horaRegistro = ent.hora,
                        fechaVencimiento = ent.fecha_vencimiento,
                        mesRelacion = ent.mes_relacion,
                        montoBase = ent.@base,
                        montoBase1 = ent.base1,
                        montoBase2 = ent.base2,
                        montoBase3 = ent.base3,
                        montoCargo = ent.cargos,
                        montoDescuento = ent.descuento1,
                        montoDivisa = ent.monto_divisa,
                        montoExento = ent.exento,
                        montoImpuesto = ent.impuesto,
                        montoTotal = ent.total,
                        notas = ent.nota,
                        ordenCompraNro = ent.orden_compra,
                        provAuto = ent.auto_proveedor,
                        provCiRif = ent.ci_rif,
                        provCodigo = ent.codigo_proveedor,
                        provDirFiscal = ent.dir_fiscal,
                        provNombre = ent.razon_social,
                        provTelefono = ent.telefono,
                        renglones = ent.renglones,
                        signo = ent.signo,
                        subTotal = ent.subtotal_neto,
                        tasaIva1 = ent.tasa1,
                        tasaIva2 = ent.tasa2,
                        tasaIva3 = ent.tasa3,
                        usuarioCodigo = ent.codigo_usuario,
                        usuarioNombre = ent.usuario,
                        montoIva1 = ent.impuesto1,
                        montoIva2 = ent.impuesto2,
                        montoIva3 = ent.impuesto3,
                        codigoSucursal = ent.codigo_sucursal,
                        //
                        estatusAplicaLibroSeniat = ent.estatus_fiscal,
                        idSucursal = ent.auto_sucursal,
                        descSucursal = ent.desc_sucursal,
                        estatusMercanciaGasto = ent.tipo_documento_compra,
                    };
                    var lista = det.Select(s =>
                    {
                        var dt = new DtoLibCompra.Documento.Cargar.FichaDetalle()
                        {
                            prdAuto = s.auto_producto,
                            cntFactura = s.cantidad,
                            contenido = s.contenido_empaque,
                            depositoAuto = s.auto_deposito,
                            depositoCodigo = s.codigo_deposito,
                            depositoNombre = s.deposito,
                            dscto1p = s.descuento1p,
                            dscto2p = s.descuento2p,
                            dscto3p = s.descuento3p,
                            dscto1m = s.descuento1,
                            dscto2m = s.descuento2,
                            dscto3m = s.descuento3,
                            importe = s.total_neto,
                            empaqueCompra = s.empaque,
                            prdCodigo = s.codigo,
                            prdNombre = s.nombre,
                            precioFactura = s.costo_bruto,
                            tasaIva = s.tasa,
                            codigoReferenciaProveedor = s.codigo_proveedor,
                            prdAutoDepartamento = s.auto_departamento,
                            prdAutoGrupo = s.auto_grupo,
                            prdAutoTasaIva = s.auto_tasa,
                            categoria = s.categoria,
                            decimales = s.decimales,
                        };
                        return dt;
                    }).ToList();
                    doc.detalles = lista;

                    result.Entidad = doc;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
    }
}
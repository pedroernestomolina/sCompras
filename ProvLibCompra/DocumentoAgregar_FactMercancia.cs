using LibEntityCompra;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCompra
{
    public partial class Provider : ILibCompras.IProvider
    {
        public DtoLib.ResultadoAuto
            Compra_DocumentoAgregarFactura(DtoLibCompra.Documento.Agregar.Factura.Ficha docFac)
        {
            var result = new DtoLib.ResultadoAuto();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var sql = "";

                        sql = "update sistema_contadores set a_compras=a_compras+1, a_cxp=a_cxp+1, a_sistema_transito_asiento=a_sistema_transito_asiento+1 ";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        var aMovCompra = cnn.Database.SqlQuery<int>("select a_compras from sistema_contadores").FirstOrDefault();
                        var aMovAsiento = cnn.Database.SqlQuery<int>("select a_sistema_transito_asiento from sistema_contadores").FirstOrDefault();
                        var aMovCxP = cnn.Database.SqlQuery<int>("select a_cxp from sistema_contadores").FirstOrDefault();
                        var autoMovCompra = aMovCompra.ToString().Trim().PadLeft(10, '0');
                        var autoMovAsiento = aMovAsiento.ToString().Trim().PadLeft(10, '0');
                        var autoMovCxP = aMovCxP.ToString().Trim().PadLeft(10, '0');
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();

                        var doc = docFac.documento;
                        var entMovCompra = new compras()
                        {
                            auto = autoMovCompra,
                            documento = doc.documentoNro,
                            fecha = doc.fechaDocumento,
                            fecha_vencimiento = doc.fechaVencimiento,
                            razon_social = doc.nombreRazonSocialProveedor,
                            dir_fiscal = doc.direccionFiscalProveedor,
                            ci_rif = doc.ciRifProveedor,
                            tipo = doc.tipoDocumento,
                            exento = doc.montoExento,
                            base1 = doc.montoBase1,
                            base2 = doc.montoBase2,
                            base3 = doc.montoBase3,
                            impuesto1 = doc.montoImpuesto1,
                            impuesto2 = doc.montoImpuesto2,
                            impuesto3 = doc.montoImpuesto3,
                            @base = doc.montoBase,
                            impuesto = doc.montoImpuesto,
                            total = doc.montoTotal,
                            tasa1 = doc.valorTasaIva1,
                            tasa2 = doc.valorTasaIva2,
                            tasa3 = doc.valorTasaIva3,
                            nota = doc.notaDocumento,
                            tasa_retencion_iva = doc.valorTasaRetencionIva,
                            tasa_retencion_islr = doc.valorTasaRetencionISLR,
                            retencion_iva = doc.montoRetencionIva,
                            retencion_islr = doc.montoRetencionISLR,
                            auto_proveedor = doc.autoProveedor,
                            codigo_proveedor = doc.codigoProveedor,
                            mes_relacion = doc.mesRelacion,
                            control = doc.controlNro,
                            fecha_registro = fechaSistema.Date,
                            orden_compra = doc.ordenCompraNro,
                            dias = doc.diasCredito,
                            descuento1 = doc.montoDescuento1,
                            descuento2 = doc.montoDescuento2,
                            cargos = doc.montoCargo,
                            descuento1p = doc.valorPorcDescuento1,
                            descuento2p = doc.valorPorcDescuento2,
                            cargosp = doc.valorPorccargo,
                            columna = doc.columna,
                            estatus_anulado = doc.esAnulado,
                            aplica = doc.aplicaDocumentoNro,
                            comprobante_retencion = doc.comprobanteRetencionNro,
                            subtotal_neto = doc.subTotalNeto,
                            telefono = doc.telefonoPropveedor,
                            factor_cambio = doc.factorCambio,
                            condicion_pago = doc.codicionPago,
                            usuario = doc.usuarioNombre,
                            codigo_usuario = doc.usuarioCodigo,
                            codigo_sucursal = doc.sucursalCodigo,
                            hora = fechaSistema.ToShortTimeString(),
                            monto_divisa = doc.montoDivisa,
                            estacion = doc.estacionEquipo,
                            renglones = doc.cntRenglones,
                            saldo_pendiente = doc.montoSaldoPendeiente,
                            ano_relacion = doc.anoRelacion,
                            comprobante_retencion_islr = doc.comprobanteRetencionISLR,
                            dias_validez = doc.diasValidez,
                            auto_usuario = doc.usuarioAuto,
                            situacion = doc.situacionDocumento,
                            signo = doc.signoDocumento,
                            serie = doc.serieDocumento,
                            tarifa = doc.tarifa,
                            tipo_remision = doc.tipoRemision,
                            documento_remision = doc.documentoRemision,
                            auto_remision = doc.autoRemision,
                            documento_nombre = doc.documentoNombre,
                            subtotal_impuesto = doc.subTotalImpuesto,
                            subtotal = doc.subTotal,
                            auto_cxp = autoMovCxP,
                            tipo_proveedor = doc.tipoProveedor,
                            planilla = doc.planilla,
                            expediente = doc.expediente,
                            anticipo_iva = doc.anticipoIva,
                            terceros_iva = doc.tercerosIva,
                            neto = doc.montoNeto,
                            costo = doc.montoCosto,
                            utilidad = doc.montoUtilidad,
                            utilidadp = doc.valorPorctUtilidad,
                            documento_tipo = doc.documentoTipo,
                            denominacion_fiscal = doc.denominacionFiscal,
                            auto_concepto = doc.autoConcepto,
                            fecha_retencion = doc.fechaRetencion,
                            estatus_cierre_contable = doc.estatusCierreContable,
                            cierre_ftp = doc.cierreFtp,
                            //
                            estatus_fiscal=doc.AplicaLibroSeniat,
                            id_compras_concepto=0,
                            desc_compras_concepto="COMPRA MERCANCIA",
                            codigo_compras_concepto="MERCANCIA",
                            auto_sucursal=doc.IdSucursal,
                            desc_sucursal=doc.DescSucursal,
                            igtf_monto=0m,
                            tipo_documento_compra="1",
                            sustraendo_ret_islr=0m,
                            monto_ret_islr=0m,
                            auto_sistema_documento="0000000019",
                            maquina_fiscal="",
                        };
                        cnn.compras.Add(entMovCompra);
                        cnn.SaveChanges();

                        var doc2 = docFac.cxp;
                        var entMovCxP = new cxp()
                        {
                            auto = autoMovCxP,
                            fecha = fechaSistema.Date,
                            tipo_documento = doc2.tipoDocumento,
                            documento = doc2.documentoNro,
                            fecha_vencimiento = doc2.fechaVencimiento,
                            nota = doc2.nota,
                            importe = doc2.importe,
                            acumulado = doc2.acumulado,
                            auto_proveedor = doc2.autoProveedor,
                            proveedor = doc2.nombreRazonSocialProveedor,
                            ci_rif = doc2.ciRifProveedor,
                            codigo_proveedor = doc2.codigoProveedor,
                            estatus_cancelado = doc2.esCancelado,
                            resta = doc2.resta,
                            estatus_anulado = doc2.esAnulado,
                            auto_documento = autoMovCompra,
                            numero = doc2.numero,
                            auto_agencia = doc2.autoAgencia,
                            agencia = doc2.nombreAgencia,
                            signo = doc2.signoDocumento,
                            dias = doc2.diasCredito,
                            auto_asiento = autoMovAsiento,
                            anexo = doc2.Anexo,
                            estatus_cierre_contable = doc2.estatusCierreContable,
                            importeDivisa = doc2.importeDivisa,
                            //
                            acumulado_divisa = 0m,
                            resta_divisa = doc2.importeDivisa,
                            tasa_divisa = doc.factorCambio,
                            auto_sistema_documento = "0000000014",
                            fecha_registro = fechaSistema,
                        };
                        cnn.cxp.Add(entMovCxP);
                        cnn.SaveChanges();
                        //
                        var entProveedor = cnn.proveedores.Find(docFac.documento.autoProveedor);
                        if (entProveedor == null)
                        {
                            result.Mensaje = "[ ID ] PROVEEDOR NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        entProveedor.saldo += docFac.documento.montoTotal;
                        entProveedor.fecha_ult_compra = docFac.documento.fechaDocumento;
                        cnn.SaveChanges();


                        var sqlDetalle = @"INSERT INTO compras_detalle (
                                            auto_documento, 
                                            auto_producto, 
                                            codigo, 
                                            nombre, 
                                            auto_departamento, 
                                            auto_grupo, 
                                            auto_subgrupo, 
                                            auto_deposito, 
                                            cantidad, 
                                            empaque, 
                                            descuento1p, 
                                            descuento2p, 
                                            descuento3p, 
                                            descuento1, 
                                            descuento2,
                                            descuento3,
                                            total_neto, 
                                            tasa, 
                                            impuesto, 
                                            total, 
                                            auto, 
                                            estatus_anulado, 
                                            fecha, 
                                            tipo, 
                                            deposito, 
                                            signo, 
                                            auto_proveedor, 
                                            decimales, 
                                            contenido_empaque, 
                                            cantidad_und, 
                                            costo_und, 
                                            codigo_deposito, 
                                            detalle, 
                                            auto_tasa, 
                                            categoria, 
                                            costo_promedio_und, 
                                            costo_compra, 
                                            codigo_proveedor, 
                                            cantidad_bono, 
                                            costo_bruto, 
                                            estatus_unidad, 
                                            fecha_lote, 
                                            cierre_ftp, 
                                            estatus_cambio_precio_venta) 
                                        VALUES (
                                            {0}, {1}, {2}, {3}, {4}, 
                                            {5}, {6}, {7}, {8}, {9}, 
                                            {10}, {11}, {12}, {13}, {14}, 
                                            {15}, {16}, {17}, {18}, {19}, 
                                            {20}, {21}, {22}, {23}, {24}, 
                                            {25}, {26}, {27}, {28}, {29}, 
                                            {30}, {31}, {32}, {33}, {34}, 
                                            {35}, {36}, {37}, {38}, {39}, 
                                            {40}, {41}, {42}, {43})";
                        var _auto = 0;
                        foreach (var it in docFac.detalles)
                        {
                            _auto += 1;
                            var xauto = _auto.ToString().Trim().PadLeft(10, '0');
                            var vdet = cnn.Database.ExecuteSqlCommand(sqlDetalle,
                                autoMovCompra, it.autoProducto, it.codigoProducto, it.nombreProducto, it.autoDepartamento,
                                it.autoGrupo, it.autoSubGrupo, it.autoDeposito, it.cantidadFac, it.empaquePrd,
                                it.valorPorcDescto1, it.valorPorcDescto2, it.valorPorcDescto3, it.montoDescto1, it.montoDescto2,
                                it.montoDescto3, it.totalNeto, it.valorTasaIva, it.montoImpuesto, it.montoTotal,
                                xauto, it.esAnulado, fechaSistema.Date, it.tipoDocumento, it.depositoNombre,
                                it.signo, it.autoProveedor, it.decimalesPrd, it.contenidoEmpaque, it.cantidadUnd,
                                it.costoUnd, it.depositoCodigo, it.detalle, it.autoTasaIva, it.categoriaPrd,
                                it.costoPromedioUnd, it.costoCompra, it.codigoProveedor, it.cantidadBonoFac, it.costoBruto,
                                it.estatusUnidad, it.fechaLote, it.cierreFtp, it.estatusHabilitarCambioPrecioVenta);
                            if (vdet == 0)
                            {
                                result.Mensaje = "PROBLEMA AL REGISTRAR ITEM DETALLE [ " + Environment.NewLine + it.nombreProducto + " ]";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                        }

                        var sqlKardex = @"INSERT INTO productos_kardex (
                                            auto_producto,
                                            total,
                                            auto_deposito,
                                            auto_concepto,
                                            auto_documento,
                                            fecha,
                                            hora,
                                            documento,
                                            modulo,
                                            entidad,
                                            signo,
                                            cantidad,
                                            cantidad_bono,
                                            cantidad_und,
                                            costo_und,  
                                            estatus_anulado,
                                            nota,
                                            precio_und,
                                            codigo,
                                            siglas,
                                            codigo_sucursal, 
                                            cierre_ftp, 
                                            codigo_deposito, 
                                            nombre_deposito, 
                                            codigo_concepto, 
                                            nombre_concepto,
                                            factor_cambio) 
                                        VALUES (
                                                {0}, {1}, {2}, {3}, {4}, 
                                                {5}, {6}, {7}, {8}, {9}, 
                                                {10}, {11}, {12}, {13}, {14}, 
                                                {15}, {16}, {17}, {18}, {19}, 
                                                {20}, {21}, {22}, {23}, {24},
                                                {25}, {26})";
                        foreach (var it in docFac.prdKardex)
                        {
                            var vk = cnn.Database.ExecuteSqlCommand(sqlKardex, it.autoPrd, it.montoTotal, it.autoDeposito,
                                it.autoConcepto, autoMovCompra, fechaSistema.Date, fechaSistema.ToShortTimeString(), it.documentoNro,
                                it.modulo, it.entidad, it.signoDocumento, it.cantidadFac, it.cantidadBonoFac, it.cantidadUnd, it.costoUnd, it.esAnulado,
                                it.nota, it.precioUnd, it.codigoMovDoc, it.siglasMovDoc, it.codigoSucursal, it.cierreFtp, it.codigoDeposito,
                                it.nombreDeposito, it.codigoConcepto, it.nombreConcepto, it.factorCambio);
                            if (vk == 0)
                            {
                                result.Mensaje = "PROBLEMA AL REGISTRAR MOVIMIENTO KARDEX [ " + Environment.NewLine + it.nombrePrd + " ]";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
                        };

                        foreach (var it in docFac.prdCosto)
                        {
                            var entPrd = cnn.productos.Find(it.autoPrd);
                            if (entPrd == null)
                            {
                                result.Mensaje = "PRODUCTO NO ENCONTRADO" + Environment.NewLine + it.nombrePrd;
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result; ;
                            }

                            var cPromedio = 0.0m;
                            var cActual = 0.0m;
                            var cCompra = 0.0m;
                            var ex = 0.0m;
                            var exLista = cnn.productos_deposito.Where(w => w.auto_producto == it.autoPrd).ToList();
                            if (exLista.Count > 0)
                                ex = exLista.Sum(s => s.fisica);
                            if ((ex + it.cntUnd) != 0)
                            {
                                cActual = entPrd.costo_promedio_und * ex;
                                cCompra = it.costoUnd * it.cntUnd;
                                cPromedio = (cActual + cCompra) / (ex + it.cntUnd);
                            }
                            else
                            {
                                cActual = 0.0m;
                                cCompra = it.costoUnd * it.cntUnd;
                                cPromedio = (cActual + cCompra) / (it.cntUnd);
                            }

                            entPrd.costo = it.costo;
                            entPrd.costo_und = it.costoUnd;
                            entPrd.costo_proveedor = it.costo;
                            entPrd.costo_proveedor_und = it.costoUnd;
                            entPrd.costo_promedio = cPromedio * it.contenido;
                            entPrd.costo_promedio_und = cPromedio;
                            entPrd.divisa = it.costoDivisa;
                            entPrd.fecha_movimiento = fechaSistema.Date;
                            entPrd.fecha_cambio = fechaSistema.Date;
                            entPrd.fecha_ult_costo = fechaSistema.Date;
                            cnn.SaveChanges();
                        }

                        foreach (var it in docFac.prdCostosHistorico)
                        {
                            var entHist = new productos_costos()
                            {
                                auto_producto = it.autoPrd,
                                costo = it.costo,
                                costo_divisa = it.costoDivisa,
                                divisa = it.tasaDivisa,
                                documento = it.documento,
                                estacion = docFac.documento.estacionEquipo,
                                fecha = fechaSistema.Date,
                                hora = fechaSistema.ToShortTimeString(),
                                nota = it.nota,
                                serie = it.serie,
                                usuario = docFac.documento.usuarioNombre,
                            };
                            cnn.productos_costos.Add(entHist);
                            cnn.SaveChanges();
                        }

                        foreach (var it in docFac.prdDeposito)
                        {
                            var entPrdDeposito = cnn.productos_deposito.FirstOrDefault(f => f.auto_deposito == it.autoDep && f.auto_producto == it.autoPrd);
                            if (entPrdDeposito == null)
                            {
                                result.Mensaje = "PRODUCTO - DEPOSITO NO ENCONTRADO" + Environment.NewLine + it.nombrePrd;
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result; ;
                            }

                            if (entPrdDeposito != null)
                            {
                                entPrdDeposito.fisica += it.cantidadUnd;
                                entPrdDeposito.disponible += it.cantidadUnd;
                                cnn.SaveChanges();
                            }
                        }

                        foreach (var it in docFac.prdProveedor)
                        {
                            var entPrdPrv = new productos_proveedor()
                            {
                                auto_producto = it.autoPrd,
                                auto_proveedor = it.autoProveedor,
                                codigo_producto = it.codigoRefProveedor,
                            };
                            cnn.productos_proveedor.Add(entPrdPrv);
                            cnn.SaveChanges();
                        }

                        var xt1 = new MySql.Data.MySqlClient.MySqlParameter();
                        var xt2 = new MySql.Data.MySqlClient.MySqlParameter();
                        var xt3 = new MySql.Data.MySqlClient.MySqlParameter();
                        var xt4 = new MySql.Data.MySqlClient.MySqlParameter();
                        var xt5 = new MySql.Data.MySqlClient.MySqlParameter();
                        var xt6 = new MySql.Data.MySqlClient.MySqlParameter();
                        foreach (var it in docFac.prdPreciosMod)
                        {
                            if (it.precio1_Emp1 != null)
                            {
                                xt1.ParameterName = "@autoPrecio";
                                xt1.Value = it.precio1_Emp1.autoEmp;
                                xt2.ParameterName = "@contenido";
                                xt2.Value = it.precio1_Emp1.contenido;
                                xt3.ParameterName = "@precio";
                                xt3.Value = it.precio1_Emp1.precioNeto;
                                xt4.ParameterName = "@utilidad";
                                xt4.Value = it.precio1_Emp1.utilidad;
                                xt5.ParameterName = "@precioFullDivisa";
                                xt5.Value = it.precio1_Emp1.precioFullDivisa;
                                xt6.ParameterName = "@autoPrd";
                                xt6.Value = it.autoPrd;
                                var xsql = @"update productos set 
                                                precio_1=@precio,
                                                utilidad_1=@utilidad,
                                                pdf_1=@precioFullDivisa
                                            where auto=@autoPrd";
                                var vk = cnn.Database.ExecuteSqlCommand(xsql, xt3, xt4, xt5, xt6);
                                cnn.SaveChanges();
                            }
                            if (it.precio1_Emp2 != null)
                            {
                                xt1.ParameterName = "@autoPrecio";
                                xt1.Value = it.precio1_Emp2.autoEmp;
                                xt2.ParameterName = "@contenido";
                                xt2.Value = it.precio1_Emp2.contenido;
                                xt3.ParameterName = "@precio";
                                xt3.Value = it.precio1_Emp2.precioNeto;
                                xt4.ParameterName = "@utilidad";
                                xt4.Value = it.precio1_Emp2.utilidad;
                                xt5.ParameterName = "@precioFullDivisa";
                                xt5.Value = it.precio1_Emp2.precioFullDivisa;
                                xt6.ParameterName = "@autoPrd";
                                xt6.Value = it.autoPrd;
                                var xsql = @"update productos_ext set 
                                                precio_may_1=@precio,
                                                utilidad_may_1=@utilidad,
                                                pdmf_1=@precioFullDivisa
                                            where auto_producto=@autoPrd";
                                var vk = cnn.Database.ExecuteSqlCommand(xsql, xt3, xt4, xt5, xt6);
                                cnn.SaveChanges();
                            }
                            if (it.precio1_Emp3 != null)
                            {
                                xt1.ParameterName = "@autoPrecio";
                                xt1.Value = it.precio1_Emp3.autoEmp;
                                xt2.ParameterName = "@contenido";
                                xt2.Value = it.precio1_Emp3.contenido;
                                xt3.ParameterName = "@precio";
                                xt3.Value = it.precio1_Emp3.precioNeto;
                                xt4.ParameterName = "@utilidad";
                                xt4.Value = it.precio1_Emp3.utilidad;
                                xt5.ParameterName = "@precioFullDivisa";
                                xt5.Value = it.precio1_Emp3.precioFullDivisa;
                                xt6.ParameterName = "@autoPrd";
                                xt6.Value = it.autoPrd;
                                var xsql = @"update productos_ext set 
                                                precio_dsp_1=@precio,
                                                utilidad_dsp_1=@utilidad,
                                                pdivisafull_dsp_1=@precioFullDivisa
                                            where auto_producto=@autoPrd";
                                var vk = cnn.Database.ExecuteSqlCommand(xsql, xt3, xt4, xt5, xt6);
                                cnn.SaveChanges();
                            }
                            //
                            if (it.precio2_Emp1 != null)
                            {
                                xt1.ParameterName = "@autoPrecio";
                                xt1.Value = it.precio2_Emp1.autoEmp;
                                xt2.ParameterName = "@contenido";
                                xt2.Value = it.precio2_Emp1.contenido;
                                xt3.ParameterName = "@precio";
                                xt3.Value = it.precio2_Emp1.precioNeto;
                                xt4.ParameterName = "@utilidad";
                                xt4.Value = it.precio2_Emp1.utilidad;
                                xt5.ParameterName = "@precioFullDivisa";
                                xt5.Value = it.precio2_Emp1.precioFullDivisa;
                                xt6.ParameterName = "@autoPrd";
                                xt6.Value = it.autoPrd;
                                var xsql = @"update productos set 
                                                precio_2=@precio,
                                                utilidad_2=@utilidad,
                                                pdf_2=@precioFullDivisa
                                            where auto=@autoPrd";
                                var vk = cnn.Database.ExecuteSqlCommand(xsql, xt3, xt4, xt5, xt6);
                                cnn.SaveChanges();
                            }
                            if (it.precio2_Emp2 != null)
                            {
                                xt1.ParameterName = "@autoPrecio";
                                xt1.Value = it.precio2_Emp2.autoEmp;
                                xt2.ParameterName = "@contenido";
                                xt2.Value = it.precio2_Emp2.contenido;
                                xt3.ParameterName = "@precio";
                                xt3.Value = it.precio2_Emp2.precioNeto;
                                xt4.ParameterName = "@utilidad";
                                xt4.Value = it.precio2_Emp2.utilidad;
                                xt5.ParameterName = "@precioFullDivisa";
                                xt5.Value = it.precio2_Emp2.precioFullDivisa;
                                xt6.ParameterName = "@autoPrd";
                                xt6.Value = it.autoPrd;
                                var xsql = @"update productos_ext set 
                                                precio_may_2=@precio,
                                                utilidad_may_2=@utilidad,
                                                pdmf_2=@precioFullDivisa
                                            where auto_producto=@autoPrd";
                                var vk = cnn.Database.ExecuteSqlCommand(xsql, xt3, xt4, xt5, xt6);
                                cnn.SaveChanges();
                            }
                            if (it.precio2_Emp3 != null)
                            {
                                xt1.ParameterName = "@autoPrecio";
                                xt1.Value = it.precio2_Emp3.autoEmp;
                                xt2.ParameterName = "@contenido";
                                xt2.Value = it.precio2_Emp3.contenido;
                                xt3.ParameterName = "@precio";
                                xt3.Value = it.precio2_Emp3.precioNeto;
                                xt4.ParameterName = "@utilidad";
                                xt4.Value = it.precio2_Emp3.utilidad;
                                xt5.ParameterName = "@precioFullDivisa";
                                xt5.Value = it.precio2_Emp3.precioFullDivisa;
                                xt6.ParameterName = "@autoPrd";
                                xt6.Value = it.autoPrd;
                                var xsql = @"update productos_ext set 
                                                precio_dsp_2=@precio,
                                                utilidad_dsp_2=@utilidad,
                                                pdivisafull_dsp_2=@precioFullDivisa
                                            where auto_producto=@autoPrd";
                                var vk = cnn.Database.ExecuteSqlCommand(xsql, xt3, xt4, xt5, xt6);
                                cnn.SaveChanges();
                            }
                            //
                            if (it.precio3_Emp1 != null)
                            {
                                xt1.ParameterName = "@autoPrecio";
                                xt1.Value = it.precio3_Emp1.autoEmp;
                                xt2.ParameterName = "@contenido";
                                xt2.Value = it.precio3_Emp1.contenido;
                                xt3.ParameterName = "@precio";
                                xt3.Value = it.precio3_Emp1.precioNeto;
                                xt4.ParameterName = "@utilidad";
                                xt4.Value = it.precio3_Emp1.utilidad;
                                xt5.ParameterName = "@precioFullDivisa";
                                xt5.Value = it.precio3_Emp1.precioFullDivisa;
                                xt6.ParameterName = "@autoPrd";
                                xt6.Value = it.autoPrd;
                                var xsql = @"update productos set 
                                                precio_3=@precio,
                                                utilidad_3=@utilidad,
                                                pdf_3=@precioFullDivisa
                                            where auto=@autoPrd";
                                var vk = cnn.Database.ExecuteSqlCommand(xsql, xt3, xt4, xt5, xt6);
                                cnn.SaveChanges();
                            }
                            if (it.precio3_Emp2 != null)
                            {
                                xt1.ParameterName = "@autoPrecio";
                                xt1.Value = it.precio3_Emp2.autoEmp;
                                xt2.ParameterName = "@contenido";
                                xt2.Value = it.precio3_Emp2.contenido;
                                xt3.ParameterName = "@precio";
                                xt3.Value = it.precio3_Emp2.precioNeto;
                                xt4.ParameterName = "@utilidad";
                                xt4.Value = it.precio3_Emp2.utilidad;
                                xt5.ParameterName = "@precioFullDivisa";
                                xt5.Value = it.precio3_Emp2.precioFullDivisa;
                                xt6.ParameterName = "@autoPrd";
                                xt6.Value = it.autoPrd;
                                var xsql = @"update productos_ext set 
                                                precio_may_3=@precio,
                                                utilidad_may_3=@utilidad,
                                                pdmf_3=@precioFullDivisa
                                            where auto_producto=@autoPrd";
                                var vk = cnn.Database.ExecuteSqlCommand(xsql, xt3, xt4, xt5, xt6);
                                cnn.SaveChanges();
                            }
                            if (it.precio3_Emp3 != null)
                            {
                                xt1.ParameterName = "@autoPrecio";
                                xt1.Value = it.precio3_Emp3.autoEmp;
                                xt2.ParameterName = "@contenido";
                                xt2.Value = it.precio3_Emp3.contenido;
                                xt3.ParameterName = "@precio";
                                xt3.Value = it.precio3_Emp3.precioNeto;
                                xt4.ParameterName = "@utilidad";
                                xt4.Value = it.precio3_Emp3.utilidad;
                                xt5.ParameterName = "@precioFullDivisa";
                                xt5.Value = it.precio3_Emp3.precioFullDivisa;
                                xt6.ParameterName = "@autoPrd";
                                xt6.Value = it.autoPrd;
                                var xsql = @"update productos_ext set 
                                                precio_dsp_3=@precio,
                                                utilidad_dsp_3=@utilidad,
                                                pdivisafull_dsp_3=@precioFullDivisa
                                            where auto_producto=@autoPrd";
                                var vk = cnn.Database.ExecuteSqlCommand(xsql, xt3, xt4, xt5, xt6);
                                cnn.SaveChanges();
                            }
                            //
                            if (it.precio4_Emp1 != null)
                            {
                                xt1.ParameterName = "@autoPrecio";
                                xt1.Value = it.precio4_Emp1.autoEmp;
                                xt2.ParameterName = "@contenido";
                                xt2.Value = it.precio4_Emp1.contenido;
                                xt3.ParameterName = "@precio";
                                xt3.Value = it.precio4_Emp1.precioNeto;
                                xt4.ParameterName = "@utilidad";
                                xt4.Value = it.precio4_Emp1.utilidad;
                                xt5.ParameterName = "@precioFullDivisa";
                                xt5.Value = it.precio4_Emp1.precioFullDivisa;
                                xt6.ParameterName = "@autoPrd";
                                xt6.Value = it.autoPrd;
                                var xsql = @"update productos set 
                                                precio_4=@precio,
                                                utilidad_4=@utilidad,
                                                pdf_4=@precioFullDivisa
                                            where auto=@autoPrd";
                                var vk = cnn.Database.ExecuteSqlCommand(xsql, xt3, xt4, xt5, xt6);
                                cnn.SaveChanges();
                            }
                            if (it.precio4_Emp2 != null)
                            {
                                xt1.ParameterName = "@autoPrecio";
                                xt1.Value = it.precio4_Emp2.autoEmp;
                                xt2.ParameterName = "@contenido";
                                xt2.Value = it.precio4_Emp2.contenido;
                                xt3.ParameterName = "@precio";
                                xt3.Value = it.precio4_Emp2.precioNeto;
                                xt4.ParameterName = "@utilidad";
                                xt4.Value = it.precio4_Emp2.utilidad;
                                xt5.ParameterName = "@precioFullDivisa";
                                xt5.Value = it.precio4_Emp2.precioFullDivisa;
                                xt6.ParameterName = "@autoPrd";
                                xt6.Value = it.autoPrd;
                                var xsql = @"update productos_ext set 
                                                precio_may_4=@precio,
                                                utilidad_may_4=@utilidad,
                                                pdmf_4=@precioFullDivisa
                                            where auto_producto=@autoPrd";
                                var vk = cnn.Database.ExecuteSqlCommand(xsql, xt3, xt4, xt5, xt6);
                                cnn.SaveChanges();
                            }
                            if (it.precio4_Emp3 != null)
                            {
                                xt1.ParameterName = "@autoPrecio";
                                xt1.Value = it.precio4_Emp3.autoEmp;
                                xt2.ParameterName = "@contenido";
                                xt2.Value = it.precio4_Emp3.contenido;
                                xt3.ParameterName = "@precio";
                                xt3.Value = it.precio4_Emp3.precioNeto;
                                xt4.ParameterName = "@utilidad";
                                xt4.Value = it.precio4_Emp3.utilidad;
                                xt5.ParameterName = "@precioFullDivisa";
                                xt5.Value = it.precio4_Emp3.precioFullDivisa;
                                xt6.ParameterName = "@autoPrd";
                                xt6.Value = it.autoPrd;
                                var xsql = @"update productos_ext set 
                                                precio_dsp_4=@precio,
                                                utilidad_dsp_4=@utilidad,
                                                pdivisafull_dsp_4=@precioFullDivisa
                                            where auto_producto=@autoPrd";
                                var vk = cnn.Database.ExecuteSqlCommand(xsql, xt3, xt4, xt5, xt6);
                                cnn.SaveChanges();
                            }
                            //
                            if (it.precio5_Emp1 != null)
                            {
                                xt1.ParameterName = "@autoPrecio";
                                xt1.Value = it.precio5_Emp1.autoEmp;
                                xt2.ParameterName = "@contenido";
                                xt2.Value = it.precio5_Emp1.contenido;
                                xt3.ParameterName = "@precio";
                                xt3.Value = it.precio5_Emp1.precioNeto;
                                xt4.ParameterName = "@utilidad";
                                xt4.Value = it.precio5_Emp1.utilidad;
                                xt5.ParameterName = "@precioFullDivisa";
                                xt5.Value = it.precio5_Emp1.precioFullDivisa;
                                xt6.ParameterName = "@autoPrd";
                                xt6.Value = it.autoPrd;
                                var xsql = @"update productos set 
                                                precio_pto=@precio,
                                                utilidad_pto=@utilidad,
                                                pdf_pto=@precioFullDivisa
                                            where auto=@autoPrd";
                                var vk = cnn.Database.ExecuteSqlCommand(xsql, xt3, xt4, xt5, xt6);
                                cnn.SaveChanges();
                            }
                        }
                        var pt1 = new MySql.Data.MySqlClient.MySqlParameter();
                        var pt2 = new MySql.Data.MySqlClient.MySqlParameter();
                        var pt3 = new MySql.Data.MySqlClient.MySqlParameter();
                        var pt4 = new MySql.Data.MySqlClient.MySqlParameter();
                        foreach (var it in docFac.prdPreciosHistorico)
                        {
                            var entHist = new productos_precios()
                            {
                                auto_producto = it.autoPrd,
                                estacion = docFac.documento.estacionEquipo,
                                fecha = fechaSistema.Date,
                                hora = fechaSistema.ToShortTimeString(),
                                usuario = docFac.documento.usuarioNombre,
                                nota = it.nota,
                                precio = it.precio,
                                precio_id = it.precioId,
                            };
                            cnn.productos_precios.Add(entHist);
                            cnn.SaveChanges();

                            pt1.ParameterName = "@pt1";
                            pt1.Value = entHist.id;
                            pt2.ParameterName = "@pt2";
                            pt2.Value = it.empaque;
                            pt3.ParameterName = "@pt3";
                            pt3.Value = it.contenido;
                            pt4.ParameterName = "@pt4";
                            pt4.Value = it.tasaFactorCambio;
                            var xsql = @"INSERT INTO productos_precios_ext (
                                            id, 
                                            id_producto_precio, 
                                            empaque, 
                                            contenido, 
                                            factor_cambio) 
                                        VALUES 
                                            (NULL, 
                                            @pt1,
                                            @pt2,
                                            @pt3,
                                            @pt4)";
                            var xres = cnn.Database.ExecuteSqlCommand(xsql, pt1, pt2, pt3, pt4);
                            cnn.SaveChanges();
                        }

                        ts.Commit();
                        result.Auto = autoMovCompra;
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result.Mensaje = Helpers.MYSQL_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (DbUpdateException ex)
            {
                result.Mensaje = Helpers.ENTITY_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
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
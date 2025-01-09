using LibEntityCompra;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace ProvLibCompra
{
    public partial class Provider : ILibCompras.IProvider
    {
        /*
        public DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Visualizar.Ficha>
            Compra_DocumentoVisualizar(string auto)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Visualizar.Ficha>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var ent = cnn.compras.Find(auto);
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] DOCUMENTO NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }

                    var det = cnn.compras_detalle.Where(f => f.auto_documento == auto).ToList();
                    var doc = new DtoLibCompra.Documento.Visualizar.Ficha()
                    {
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
                        aplica = ent.aplica,
                        EstatusDoc= ent.estatus_anulado,
                    };
                    var lista = det.Select(s =>
                    {
                        var dt = new DtoLibCompra.Documento.Visualizar.FichaDetalle()
                        {
                            cntFactura = s.cantidad,
                            contenido = s.contenido_empaque,
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

            return result;
        }
         */

        public DtoLib.Resultado
            Compra_DocumentoAnularFactura(DtoLibCompra.Documento.Anular.Factura.Ficha ficha)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();

                        var sql = "INSERT INTO `auditoria_documentos` (`auto_documento`, `auto_sistema_documentos`, " +
                            "`auto_usuario`, `usuario`, `codigo`, `fecha`, `hora`, `memo`, `estacion`, `ip`) " +
                            "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, '')";

                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", ficha.autoDocumento);
                        var p2 = new MySql.Data.MySqlClient.MySqlParameter("@p2", ficha.auditoria.autoSistemaDocumento);
                        var p3 = new MySql.Data.MySqlClient.MySqlParameter("@p3", ficha.auditoria.autoUsuario);
                        var p4 = new MySql.Data.MySqlClient.MySqlParameter("@p4", ficha.auditoria.usuario);
                        var p5 = new MySql.Data.MySqlClient.MySqlParameter("@p5", ficha.auditoria.codigo);
                        var p6 = new MySql.Data.MySqlClient.MySqlParameter("@p6", fechaSistema.Date);
                        var p7 = new MySql.Data.MySqlClient.MySqlParameter("@p7", fechaSistema.ToShortTimeString());
                        var p8 = new MySql.Data.MySqlClient.MySqlParameter("@p8", ficha.auditoria.motivo);
                        var p9 = new MySql.Data.MySqlClient.MySqlParameter("@p9", ficha.auditoria.estacion);
                        var vk = cnn.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8, p9);
                        if (vk == 0)
                        {
                            result.Mensaje = "PROBLEMA AL REGISTRAR MOVIMIENTO AUDITORIA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }

                        var entCompra = cnn.compras.Find(ficha.autoDocumento);
                        if (entCompra == null)
                        {
                            result.Mensaje = "DOCUMENTO NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        entCompra.estatus_anulado = "1";
                        cnn.SaveChanges();

                        sql = "update compras_detalle set estatus_anulado='1' where auto_documento=@p1";
                        p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", ficha.autoDocumento);
                        vk = cnn.Database.ExecuteSqlCommand(sql, p1);
                        if (vk == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR DETALLES DEL DOCUMENTO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();

                        var pA = new MySql.Data.MySqlClient.MySqlParameter("@pa", ficha.codigoDocumento);
                        sql = "update productos_kardex set estatus_anulado='1' where auto_documento=@p1 and modulo='Compras' and codigo=@pA";
                        p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", ficha.autoDocumento);
                        vk = cnn.Database.ExecuteSqlCommand(sql, p1, pA);
                        if (vk == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR MOVIMIENTOS KARDEX";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();

                        var entCxP = cnn.cxp.Find(entCompra.auto_cxp);
                        if (entCxP == null)
                        {
                            result.Mensaje = "DOCUMENTO POR PAGAR NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        entCxP.estatus_anulado = "1";
                        cnn.SaveChanges();

                        var entKardex = cnn.productos_kardex.Where(w => w.auto_documento == ficha.autoDocumento && w.modulo == "Compras" && w.codigo == ficha.codigoDocumento).ToList();
                        foreach (var rg in entKardex)
                        {
                            var autoDeposito = rg.auto_deposito;
                            var autoProducto = rg.auto_producto;
                            var cnt = rg.cantidad_und;

                            var entPrdDep = cnn.productos_deposito.FirstOrDefault(f => f.auto_deposito == autoDeposito && f.auto_producto == autoProducto);
                            if (entPrdDep == null)
                            {
                                result.Mensaje = "PRODUCTO / DEPOSITO NO ENCONTRADO";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }

                            entPrdDep.fisica -= cnt;
                            //entPrdDep.disponible = entPrdDep.fisica;
                            entPrdDep.disponible -= cnt;
                            cnn.SaveChanges();
                        }
                        cnn.SaveChanges();

                        var entProveedor = cnn.proveedores.Find(entCompra.auto_proveedor);
                        if (entProveedor == null)
                        {
                            result.Mensaje = "[ ID ] PROVEEDOR NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        entProveedor.saldo -= entCompra.total;
                        cnn.SaveChanges();

                        ts.Complete();
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                var msg = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        msg += ve.ErrorMessage;
                    }
                }
                result.Mensaje = msg;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                var msg = "";
                foreach (var eve in e.Entries)
                {
                    //msg += eve.m;
                    foreach (var ve in eve.CurrentValues.PropertyNames)
                    {
                        msg += ve.ToString();
                    }
                }
                result.Mensaje = msg;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }

        public DtoLib.Resultado
            Compra_DocumentoAnular_Verificar(string autoDoc)
        {
            var rt = new DtoLib.Resultado();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();

                    var entCompra = cnn.compras.Find(autoDoc);
                    if (entCompra == null)
                    {
                        rt.Mensaje = "[ ID ] DOCUMENTO NO ENCONTRADO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    if (entCompra.estatus_anulado == "1")
                    {
                        rt.Mensaje = "DOCUMENTO YA ANULADO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    if (entCompra.fecha.Year != fechaSistema.Year || entCompra.fecha.Month != fechaSistema.Month)
                    {
                        rt.Mensaje = "DOCUMENTO SE ENCUENTRA EN OTRO PERIODO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    if (entCompra.tipo == "01" || entCompra.tipo == "FF")
                    {
                        var xref = cnn.compras.FirstOrDefault(f => f.auto_remision == autoDoc && f.estatus_anulado == "0");
                        if (xref != null)
                        {
                            rt.Mensaje = "DOCUMENTO A ANULAR TIENE DOCUMENTOS RELACIONADOS";
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                            return rt;
                        }
                    }
                    if (entCompra.estatus_cierre_contable == "1")
                    {
                        rt.Mensaje = "DOCUMENTO SE ENCUENTRA BLOQUEADO CONTABLEMENTE";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    var entCxP = cnn.cxp.Find(entCompra.auto_cxp);
                    if (entCxP.acumulado > 0)
                    {
                        rt.Mensaje = "HAY ABONOS REGISTRADO ( CUENTA POR PAGAR ) AL DOCUMENTO A ANULAR";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return rt;
        }

        public DtoLib.Resultado
            Compra_DocumentoAnularNotaCredito(DtoLibCompra.Documento.Anular.NotaCredito.Ficha ficha)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();

                        var sql = "INSERT INTO `auditoria_documentos` (`auto_documento`, `auto_sistema_documentos`, " +
                            "`auto_usuario`, `usuario`, `codigo`, `fecha`, `hora`, `memo`, `estacion`, `ip`) " +
                            "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, '')";

                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", ficha.autoDocumento);
                        var p2 = new MySql.Data.MySqlClient.MySqlParameter("@p2", ficha.auditoria.autoSistemaDocumento);
                        var p3 = new MySql.Data.MySqlClient.MySqlParameter("@p3", ficha.auditoria.autoUsuario);
                        var p4 = new MySql.Data.MySqlClient.MySqlParameter("@p4", ficha.auditoria.usuario);
                        var p5 = new MySql.Data.MySqlClient.MySqlParameter("@p5", ficha.auditoria.codigo);
                        var p6 = new MySql.Data.MySqlClient.MySqlParameter("@p6", fechaSistema.Date);
                        var p7 = new MySql.Data.MySqlClient.MySqlParameter("@p7", fechaSistema.ToShortTimeString());
                        var p8 = new MySql.Data.MySqlClient.MySqlParameter("@p8", ficha.auditoria.motivo);
                        var p9 = new MySql.Data.MySqlClient.MySqlParameter("@p9", ficha.auditoria.estacion);
                        var vk = cnn.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8, p9);
                        if (vk == 0)
                        {
                            result.Mensaje = "PROBLEMA AL REGISTRAR MOVIMIENTO AUDITORIA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }

                        var entCompra = cnn.compras.Find(ficha.autoDocumento);
                        if (entCompra == null)
                        {
                            result.Mensaje = "DOCUMENTO NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        entCompra.estatus_anulado = "1";
                        cnn.SaveChanges();

                        sql = "update compras_detalle set estatus_anulado='1' where auto_documento=@p1";
                        p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", ficha.autoDocumento);
                        vk = cnn.Database.ExecuteSqlCommand(sql, p1);
                        if (vk == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR DETALLES DEL DOCUMENTO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();

                        var pA = new MySql.Data.MySqlClient.MySqlParameter("@pa", ficha.codigoDocumento);
                        sql = "update productos_kardex set estatus_anulado='1' where auto_documento=@p1 and modulo='Compras' and codigo=@pA";
                        p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", ficha.autoDocumento);
                        vk = cnn.Database.ExecuteSqlCommand(sql, p1, pA);
                        if (vk == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR MOVIMIENTOS KARDEX";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();

                        var entCxP = cnn.cxp.Find(entCompra.auto_cxp);
                        if (entCxP == null)
                        {
                            result.Mensaje = "DOCUMENTO POR PAGAR NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        entCxP.estatus_anulado = "1";
                        cnn.SaveChanges();

                        var entKardex = cnn.productos_kardex.Where(w => w.auto_documento == ficha.autoDocumento && w.modulo == "Compras" && w.codigo == ficha.codigoDocumento).ToList();
                        foreach (var rg in entKardex)
                        {
                            var autoDeposito = rg.auto_deposito;
                            var autoProducto = rg.auto_producto;
                            var cnt = rg.cantidad_und;

                            var entPrdDep = cnn.productos_deposito.FirstOrDefault(f => f.auto_deposito == autoDeposito && f.auto_producto == autoProducto);
                            if (entPrdDep == null)
                            {
                                result.Mensaje = "PRODUCTO / DEPOSITO NO ENCONTRADO";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }

                            entPrdDep.fisica += cnt;
                            entPrdDep.disponible = entPrdDep.fisica;
                            cnn.SaveChanges();
                        }
                        cnn.SaveChanges();

                        var entProveedor = cnn.proveedores.Find(entCompra.auto_proveedor);
                        if (entProveedor == null)
                        {
                            result.Mensaje = "[ ID ] PROVEEDOR NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        entProveedor.saldo += entCompra.total;
                        cnn.SaveChanges();

                        ts.Complete();
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                var msg = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        msg += ve.ErrorMessage;
                    }
                }
                result.Mensaje = msg;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                var msg = "";
                foreach (var eve in e.Entries)
                {
                    //msg += eve.m;
                    foreach (var ve in eve.CurrentValues.PropertyNames)
                    {
                        msg += ve.ToString();
                    }
                }
                result.Mensaje = msg;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.Resultado
            Compra_DocumentoAgregar_Verificar(string documentoNro, string controlNro, string autoPrv)
        {
            var rt = new DtoLib.Resultado();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var entCompra = cnn.compras.FirstOrDefault(f => f.documento == documentoNro && f.control == controlNro && f.auto_proveedor == autoPrv && f.estatus_anulado == "0");
                    if (entCompra != null)
                    {
                        rt.Mensaje = "DOCUMENTO PARA ESTE PROVEEDOR CON EL NUMERO DE CONTROL Y DOCUMENTO YA ESTA REGISTRADO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DtoLib.Resultado
            Compra_DocumentoCorrectorFactura(DtoLibCompra.Documento.Corrector.Factura.Ficha docFac)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var entCompra = cnn.compras.Find(docFac.autoDoc);
                        if (entCompra == null)
                        {
                            result.Mensaje = "DOCUMENTO NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }

                        entCompra.documento = docFac.documentoNro;
                        entCompra.control = docFac.controlNro;
                        entCompra.fecha = docFac.fechaDocumento;
                        entCompra.razon_social = docFac.nombreRazonSocialProveedor;
                        entCompra.ci_rif = docFac.ciRifProveedor;
                        entCompra.dir_fiscal = docFac.direccionFiscalProveedor;
                        entCompra.nota = docFac.notaDocumento;
                        cnn.SaveChanges();

                        ts.Complete();
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                var msg = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        msg += ve.ErrorMessage;
                    }
                }
                result.Mensaje = msg;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                var msg = "";
                foreach (var eve in e.Entries)
                {
                    //msg += eve.m;
                    foreach (var ve in eve.CurrentValues.PropertyNames)
                    {
                        msg += ve.ToString();
                    }
                }
                result.Mensaje = msg;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.Resultado
            Compra_DocumentoCorrector_Verificar(string documentoNro, string controlNro, string autoPrv, string autoDoc)
        {
            var rt = new DtoLib.Resultado();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var entCompra = cnn.compras.FirstOrDefault(f => f.documento == documentoNro &&
                        f.control == controlNro &&
                        f.auto_proveedor == autoPrv &&
                        f.estatus_anulado == "0" &&
                        f.auto != autoDoc);
                    if (entCompra != null)
                    {
                        rt.Mensaje = "NUMERO DE CONTROL Y DOCUMENTO YA ESTA REGISTRADO PARA ESTE PROVEEDOR";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DtoLib.ResultadoLista<DtoLibCompra.Documento.ListaItemImportar.Ficha>
            Compra_Documento_ItemImportar_GetLista(string autoDoc)
        {
            var rt = new DtoLib.ResultadoLista<DtoLibCompra.Documento.ListaItemImportar.Ficha>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql_1 = @"SELECT
                                    compraDet.auto_producto as prdAuto, 
                                    compraDet.codigo as prdCodigo, 
                                    compraDet.nombre as prdNombre, 
                                    compraDet.auto_departamento as prdAutoDepartamento, 
                                    compraDet.auto_grupo as prdAutoGrupo, 
                                    compraDet.auto_subgrupo as prdAutoSubGrupo, 
                                    compraDet.cantidad as cntFactura, 
                                    compraDet.empaque as empaqueCompra, 
                                    compraDet.descuento1p as dscto1p, 
                                    compraDet.descuento2p as dscto2p, 
                                    compraDet.descuento3p as dscto3p, 
                                    compraDet.tasa as tasaIva, 
                                    compraDet.estatus_unidad as estatusUnidad,  
                                    compraDet.costo_compra as precioFactura,
                                    compraDet.decimales, 
                                    compraDet.contenido_empaque as contenidoEmp, 
                                    compraDet.auto_tasa as prdAutoTasaIva, 
                                    compraDet.categoria,
                                    compraDet.codigo_proveedor as codRefProv,
                                    prd.auto_empaque_compra as autoEmpCompPreDeterminado, 
                                    prd.contenido_compras as contEmpCompPreDeterminado, 
                                    prdExt.auto_emp_inv_1 as autoEmpInv, 
                                    prdExt.cont_emp_inv_1 as contEmpInv ";

                    var sql_2 = @" FROM compras_detalle as compraDet 
                                    join productos as prd on compraDet.auto_producto=prd.auto
                                    join productos_ext as prdExt on prdExt.auto_producto=prd.auto ";

                    var sql_3 = "where auto_documento = @autoDoc ";

                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    p1.ParameterName = "@autoDoc";
                    p1.Value = autoDoc;

                    var sql = sql_1 + sql_2 + sql_3;
                    var lst = cnn.Database.SqlQuery<DtoLibCompra.Documento.ListaItemImportar.Ficha>(sql, p1).ToList();
                    rt.Lista = lst;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return rt;
        }

        public DtoLib.Resultado
            Compra_Documento_Pendiente_Agregar(DtoLibCompra.Documento.Pendiente.Agregar.Ficha ficha)
        {
            var result = new DtoLib.Resultado();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        var xfecha = fechaSistema.Date;
                        var xhora = fechaSistema.ToShortTimeString();
                        var entCompraPend = new compras_pend
                        {
                            auto_usuario = ficha.usuarioId,
                            documento_factor_cambio = ficha.docFactorCambio,
                            documento_items = ficha.docItemsNro,
                            documento_monto = ficha.docMonto,
                            documento_monto_divisa = ficha.docMontoDivisa,
                            documento_tipo = ficha.docTipo,
                            entidad_cirif = ficha.entidadCiRif,
                            entidad_nombre = ficha.entidadNombre,
                            documento_nombre = ficha.docNombre,
                            usuario_nombre = ficha.usuarioNombre,
                            documento_control = ficha.docControl,
                            documento_numero = ficha.docNumero,
                            fecha = xfecha,
                            hora = xhora,
                            auto_deposito = ficha.autoDeposito,
                            auto_sucursal = ficha.autoSucursal,
                            documento_notas = ficha.docNotas,
                            documento_ordenCompra = ficha.docOrdenCompra,
                            entidad_auto = ficha.entidadAuto,
                            entidad_codigo = ficha.entidadCodigo,
                            entidad_dirFiscal = ficha.entidadCodigo,
                            documento_dias_credito = ficha.docDiasCredito,
                            documento_fecha_emision = ficha.docFechaEmision,
                        };
                        cnn.compras_pend.Add(entCompraPend);
                        cnn.SaveChanges();

                        foreach (var it in ficha.items)
                        {
                            var entCompraPendDet = new compras_pend_detalle()
                            {
                                idPend = entCompraPend.id,
                                cant_fact = it.cntFactura,
                                codrefprv_fact = it.codRefProv,
                                depart_auto = it.prdAutoDepartamento,
                                dsct_1_fact = it.dscto1p,
                                dsct_2_fact = it.dscto2p,
                                dsct_3_fact = it.dscto3p,
                                empaque_cont = it.contenidoEmp,
                                empaque_nombre = it.empaqueCompra,
                                empaque_unidad = it.estatusUnidad,
                                grupo_auto = it.prdAutoGrupo,
                                prd_auto = it.prdAuto,
                                prd_categoria = it.categoria,
                                prd_codigo = it.prdCodigo,
                                prd_decimales = it.decimales,
                                prd_nombre = it.prdNombre,
                                precio_fact = it.precioFactura,
                                subg_auto = it.prdAutoSubGrupo,
                                tasa_auto = it.prdAutoTasaIva,
                                tasa_iva = it.tasaIva,
                                //
                                costoActual_local = it.prdCostoActualLocal,
                                costoActual_divisa = it.prdCostoActualDivisa,
                                admDivisa = it.prdEstatusDivisa,
                                precio_fact_divisa = it.precioFacturaDivisa,
                                //
                                empaque_auto = it.autoEmpaque,
                                empaque_decimales = it.decimalEmpaque,
                                empaque_predeterminado_compra = it.estatusEmpCompraPredeterminado,
                                empaque_seleccionado_id = it.idEmpSeleccionado,
                            };
                            cnn.compras_pend_detalle.Add(entCompraPendDet);
                            cnn.SaveChanges();
                            //
                            if (it.preciosVtaPend != null) 
                            {
                                foreach (var rg in it.preciosVtaPend)
                                {
                                    var pt1 = new MySql.Data.MySqlClient.MySqlParameter("@id_item_pend", entCompraPendDet.id);
                                    var pt2 = new MySql.Data.MySqlClient.MySqlParameter("@id_pend", entCompraPend.id);
                                    var pt3 = new MySql.Data.MySqlClient.MySqlParameter("@id_tipo_empq_vta",rg.idEmpqVta);
                                    var pt4 = new MySql.Data.MySqlClient.MySqlParameter("@desc_empq_vta",rg.descEmpVta);
                                    var pt5 = new MySql.Data.MySqlClient.MySqlParameter("@cont_empq_vta",rg.contEmpVta);
                                    var pt6 = new MySql.Data.MySqlClient.MySqlParameter("precio_vta_1",rg.precios[0]);
                                    var pt7 = new MySql.Data.MySqlClient.MySqlParameter("precio_vta_2",rg.precios[1]);
                                    var pt8 = new MySql.Data.MySqlClient.MySqlParameter("precio_vta_3",rg.precios[2]);
                                    var pt9 = new MySql.Data.MySqlClient.MySqlParameter("precio_vta_4",rg.precios[3]);
                                    var sql = @"INSERT INTO compras_pend_detalle_preciosvta (
                                                    id, 
                                                    id_item_pend, 
                                                    id_pend, 
                                                    id_tipo_empq_vta, 
                                                    desc_empq_vta, 
                                                    cont_empq_vta, 
                                                    precio_vta_1, 
                                                    precio_vta_2, 
                                                    precio_vta_3, 
                                                    precio_vta_4, 
                                                    precio_vta_5
                                                ) VALUES (
                                                    NULL, 
                                                    @id_item_pend, 
                                                    @id_pend, 
                                                    @id_tipo_empq_vta, 
                                                    @desc_empq_vta, 
                                                    @cont_empq_vta, 
                                                    @precio_vta_1, 
                                                    @precio_vta_2, 
                                                    @precio_vta_3, 
                                                    @precio_vta_4, 
                                                    0
                                                )";
                                    var rt = cnn.Database.ExecuteSqlCommand(sql, pt1, pt2, pt3, pt4, pt5, 
                                        pt6, pt7, pt8, pt9);
                                    if (rt==0)
                                    {
                                        throw new Exception("PROBLEMA AL INSERTAR EN PENDIENTE PRECIO VENTA");
                                    }
                                    cnn.SaveChanges();
                                }
                            }
                        }
                        ts.Commit();
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
            return result;
        }
        public DtoLib.ResultadoEntidad<int>
            Compra_Documento_Pendiente_Cnt(DtoLibCompra.Documento.Pendiente.Filtro.Ficha filtro)
        {
            var result = new DtoLib.ResultadoEntidad<int>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();

                    var sql_1 = "SELECT count(*) as cnt ";
                    var sql_2 = "FROM compras_pend ";
                    var sql_3 = "where 1=1 ";
                    if (filtro.idUsuario != "")
                    {
                        p1.ParameterName = "@idUsuario";
                        p1.Value = filtro.idUsuario;
                        sql_3 += " and auto_usuario=@idUsuario ";
                    }
                    if (filtro.docTipo != "")
                    {
                        p2.ParameterName = "@docTipo";
                        p2.Value = filtro.docTipo;
                        sql_3 += " and documento_tipo=@docTipo ";
                    }
                    var sql = sql_1 + sql_2 + sql_3;
                    var cnt = cnn.Database.SqlQuery<int>(sql, p1, p2).FirstOrDefault();
                    result.Entidad = cnt;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.ResultadoLista<DtoLibCompra.Documento.Pendiente.Lista.Ficha>
            Compra_Documento_Pendiente_GetLista(DtoLibCompra.Documento.Pendiente.Filtro.Ficha filtro)
        {
            var rt = new DtoLib.ResultadoLista<DtoLibCompra.Documento.Pendiente.Lista.Ficha>();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var sql_1 = @"SELECT 
                                    id, 
                                    entidad_cirif as entidadCiRif, 
                                    entidad_nombre as entidadNombre, 
                                    documento_tipo as docTipo, 
                                    documento_monto as docMonto, 
                                    documento_monto_divisa as docMontoDivisa, 
                                    documento_nombre as docNombre, 
                                    documento_factor_cambio as docFactorCambio, 
                                    documento_numero as docNumero, 
                                    documento_control as docControl, 
                                    documento_items as docItemsNro ";
                    var sql_2 = "FROM compras_pend ";
                    var sql_3 = "where 1=1 ";
                    if (filtro.idUsuario != "")
                    {
                        sql_3 += "and auto_usuario=@idUsuario ";
                        p1.ParameterName = "@idUsuario";
                        p1.Value = filtro.idUsuario;
                    }
                    if (filtro.docTipo != "")
                    {
                        sql_3 += "and documento_tipo=@docTipo ";
                        p2.ParameterName = "@docTipo";
                        p2.Value = filtro.docTipo;
                    }
                    var sql = sql_1 + sql_2 + sql_3;
                    var lst = cnn.Database.SqlQuery<DtoLibCompra.Documento.Pendiente.Lista.Ficha>(sql, p1, p2, p3).ToList();
                    rt.Lista = lst;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public DtoLib.Resultado
            Compra_Documento_Pendiente_Eliminar(int idPend)
        {
            var rt = new DtoLib.Resultado();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@id", idPend);
                        var sql = @"delete 
                                    from compras_pend_detalle_preciosvta 
                                    where id_pend=@id";
                        cnn.Database.ExecuteSqlCommand(sql, p1);
                        //
                        p1 = new MySql.Data.MySqlClient.MySqlParameter("@id", idPend);
                        sql = @"delete 
                                    from compras_pend_detalle 
                                    where idPend=@id";
                        var cnt = cnn.Database.ExecuteSqlCommand(sql, p1);
                        if (cnt == 0)
                        {
                            throw new Exception("ITEMS NO ENCONTRADOS ");
                        }
                        //
                        sql = @"delete 
                                    from compras_pend 
                                    where id=@id";
                        cnt = cnn.Database.ExecuteSqlCommand(sql, p1);
                        if (cnt == 0)
                        {
                            throw new Exception("[ ID ] DOCUMENTO PENDIENTE NO ENCONTRADO");
                        }
                        cnn.SaveChanges();
                        ts.Commit();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                rt.Mensaje = Helpers.MYSQL_VerificaError(ex);
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (DbUpdateException ex)
            {
                rt.Mensaje = Helpers.ENTITY_VerificaError(ex);
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Pendiente.Abrir.Ficha>
            Compra_Documento_Pendiente_Abrir(int idPend)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Pendiente.Abrir.Ficha>();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var ent = cnn.compras_pend.Find(idPend);
                    if (ent == null)
                    {
                        throw  new Exception("[ ID ] DOCUMENTO NO ENCONTRADO");
                    }
                    //
                    var det = cnn.compras_pend_detalle.Where(f => f.idPend == idPend).ToList();
                    var doc = new DtoLibCompra.Documento.Pendiente.Abrir.Ficha()
                    {
                        docControl = ent.documento_control,
                        docDiasCredito = ent.documento_dias_credito,
                        docFactorCambio = ent.documento_factor_cambio,
                        docFechaEmision = ent.documento_fecha_emision,
                        docNumero = ent.documento_numero,
                        docNotas = ent.documento_notas,
                        docOrdenCompra = ent.documento_ordenCompra,
                        entidadAuto = ent.entidad_auto,
                        entidadCiRif = ent.entidad_cirif,
                        entidadCodigo = ent.entidad_codigo,
                        entidadDirFiscal = ent.entidad_dirFiscal,
                        entidadNombre = ent.entidad_nombre,
                        autoDeposito = ent.auto_deposito,
                        autoSucursal = ent.auto_sucursal,
                    };
                    var lista = det.Select(s =>
                    {
                        var dt = new DtoLibCompra.Documento.Pendiente.Abrir.FichaDetalle()
                        {
                            categoria = s.prd_categoria,
                            cntFactura = s.cant_fact,
                            codRefProv = s.codrefprv_fact,
                            contenidoEmp = s.empaque_cont,
                            decimales = s.prd_decimales,
                            dscto1p = s.dsct_1_fact,
                            dscto2p = s.dsct_2_fact,
                            dscto3p = s.dsct_3_fact,
                            empaqueCompra = s.empaque_nombre,
                            estatusUnidad = s.empaque_unidad,
                            prdAuto = s.prd_auto,
                            prdAutoDepartamento = s.depart_auto,
                            prdAutoGrupo = s.grupo_auto,
                            prdAutoSubGrupo = s.subg_auto,
                            prdAutoTasaIva = s.tasa_auto,
                            prdCodigo = s.prd_codigo,
                            prdNombre = s.prd_nombre,
                            precioFactura = s.precio_fact,
                            tasaIva = s.tasa_iva,
                            //
                            prdCostoActualDivisa = s.costoActual_divisa,
                            prdCostoActualLocal = s.costoActual_local,
                            prdEstatusDivisa = s.admDivisa,
                            precioFacturaDivisa = s.precio_fact_divisa,
                            //
                            autoEmpaque = s.empaque_auto,
                            decimalEmpaque = s.empaque_decimales,
                            estatusEmpCompraPredeterminado = s.empaque_predeterminado_compra,
                            idEmpaqueSeleccionado = s.empaque_seleccionado_id,
                            //
                        };
                        var tp1 = new MySql.Data.MySqlClient.MySqlParameter("idItemPend", s.id);
                        var sql = @"select
                                        id_tipo_empq_vta as idEmpqVta,
                                        desc_empq_vta as descEmpVta,
                                        cont_empq_vta as contEmpVta,
                                        precio_vta_1 as pVta1,
                                        precio_vta_2 as pVta2,
                                        precio_vta_3 as pVta3,
                                        precio_vta_4 as pVta4
                                    from compras_pend_detalle_preciosvta
                                    where id_item_pend=@idItemPend";
                        var _lst = cnn.Database.SqlQuery<DtoLibCompra.Documento.Pendiente.Abrir.PrecioVtaPend>(sql, tp1).ToList();
                        dt.preciosVtaPend = _lst;
                        return dt;
                    }).ToList();
                    doc.items = lista;
                    //
                    result.Entidad = doc;
                }
            }
            catch (Exception e)
            {
                result.Entidad = null; 
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
    }
}
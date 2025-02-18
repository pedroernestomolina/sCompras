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
        public DtoLib.Resultado
            Compra_DocumentoCorrectorFactura(DtoLibCompra.Documento.Corrector.Factura.Ficha docFac)
        {
            var result = new DtoLib.Resultado();
            //
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

        public DtoLib.Resultado
            Compra_DocumentoCorrector_Verificar(string documentoNro, string controlNro, string autoPrv, string autoDoc)
        {
            var rt = new DtoLib.Resultado();
            //
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
            //
            return rt;
        }

        //
        public DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Corrector.GetData.Ficha> 
            Compra_DocumentoCorrector_GetData_ByIdDoc(string idDoc)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Corrector.GetData.Ficha>();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql = @"select 
                                    auto as autoId,
                                    auto_proveedor as provId,
                                    razon_social as provNombre,
                                    ci_rif as provCiRif,
                                    codigo_proveedor as provCodigo,
                                    dir_fiscal as provDirFiscal,
                                    telefono as provTelefono,
                                    documento as documentoNro,
                                    control as controlNro,
                                    orden_compra as ordenCompraNro,
                                    fecha_registro as fechaRegistro,
                                    fecha as fechaEmision,
                                    fecha_vencimiento as fechaVencimiento,
                                    dias as diasCredito,
                                    mes_relacion as mesRelacion,
                                    ano_relacion as anoRelacion,
                                    serie as documentoSerie,
                                    documento_nombre as documentoNombre,
                                    tipo as documentoTipo,
                                    total as montoTotal,
                                    exento as montoExento,
                                    base as montoBase,
                                    impuesto as montoImpuesto,
                                    subtotal_neto as subTotal,
                                    base1 as montoBase1,
                                    base2 as montoBase2,
                                    base3 as montoBase3,
                                    impuesto1 as montoIva1,
                                    impuesto2 as montoIva2,
                                    impuesto3 as montoIva3,
                                    tasa1 as tasaIva1,
                                    tasa2 as tasaIva2,
                                    tasa3 as tasaIva3,
                                    nota as notas,
                                    estatus_fiscal as estatusAplicaLibroSeniat,
                                    estatus_anulado as estatusAnulado
                                from compras
                                where auto=@p1";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", idDoc);
                    var ent = cnn.Database.SqlQuery<DtoLibCompra.Documento.Corrector.GetData.Ficha>(_sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("DOCUMENTO NO ENCONTRADO");
                    }
                    result.Entidad = ent;
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
        public DtoLib.Resultado 
            Compra_DocumentoCorrector_Validar(DtoLibCompra.Documento.Corrector.ActualizarData.Ficha dataAct)
        {
            var rt = new DtoLib.Resultado();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1",dataAct.documentoNro);
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter("@p2",dataAct.controlNro);
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter("@p3",dataAct.provId);
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter("@p4",dataAct.autoId);
                    var _sql = @"select 
                                    1 
                                from compras 
                                where documento=@p1 and 
                                    control=@p2 and
                                    auto_proveedor=@p3 and
                                    auto<>@p4 and
                                    estatus_anulado='0'";
                    var v = cnn.Database.SqlQuery<int>(_sql, p1,p2,p3,p4).FirstOrDefault();
                    if (v==1)
                    {
                        throw new Exception("NUMERO DE CONTROL Y DOCUMENTO YA ESTA REGISTRADO PARA ESTE PROVEEDOR");
                    }
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
            Compra_DocumentoCorrector_Actualizar(DtoLibCompra.Documento.Corrector.ActualizarData.Ficha dataAct)
        {
            var result = new DtoLib.Resultado();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var idDoc= new MySql.Data.MySqlClient.MySqlParameter("@id", dataAct.autoId);
                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@documento", dataAct.documentoNro);
                        var p2= new MySql.Data.MySqlClient.MySqlParameter("@control",dataAct.controlNro);
                        var p3= new MySql.Data.MySqlClient.MySqlParameter("@fecha",dataAct.fechaEmision);
                        var p4= new MySql.Data.MySqlClient.MySqlParameter("@razon_social",dataAct.provNombre);
                        var p5= new MySql.Data.MySqlClient.MySqlParameter("@ci_rif",dataAct.provCiRif);
                        var p6= new MySql.Data.MySqlClient.MySqlParameter("@dir_fiscal",dataAct.provDirFiscal);
                        var p7= new MySql.Data.MySqlClient.MySqlParameter("@nota",dataAct.notas);
                        var p8 = new MySql.Data.MySqlClient.MySqlParameter("@montoTotal", dataAct.montoTotal);
                        var p9 = new MySql.Data.MySqlClient.MySqlParameter("@montoExento", dataAct.montoExento);
                        var p10 = new MySql.Data.MySqlClient.MySqlParameter("@montoBase", dataAct.montoBase);
                        var p11 = new MySql.Data.MySqlClient.MySqlParameter("@montoImpuesto", dataAct.montoImpuesto);
                        var p12 = new MySql.Data.MySqlClient.MySqlParameter("@subTotal", dataAct.subTotal);
                        var p13 = new MySql.Data.MySqlClient.MySqlParameter("@montoBase1", dataAct.montoBase1);
                        var p14 = new MySql.Data.MySqlClient.MySqlParameter("@montoBase2", dataAct.montoBase2);
                        var p15 = new MySql.Data.MySqlClient.MySqlParameter("@montoBase3", dataAct.montoBase3);
                        var p16 = new MySql.Data.MySqlClient.MySqlParameter("@montoIva1", dataAct.montoIva1);
                        var p17 = new MySql.Data.MySqlClient.MySqlParameter("@montoIva2", dataAct.montoIva2);
                        var p18 = new MySql.Data.MySqlClient.MySqlParameter("@montoIva3", dataAct.montoIva3);
                        var _sql = @"update compras set
                                        documento=@documento,
                                        control=@control,
                                        fecha=@fecha,
                                        razon_social=@razon_social,
                                        ci_rif=@ci_rif,
                                        dir_fiscal=@dir_fiscal,
                                        nota=@nota,
                                        total = @montoTotal,
                                        exento = @montoExento,
                                        base = @montoBase,
                                        impuesto = @montoImpuesto,
                                        subtotal_neto = @subTotal,
                                        base1 = @montoBase1,
                                        base2 = @montoBase2,
                                        base3 = @montoBase3,
                                        impuesto1 = @montoIva1,
                                        impuesto2 = @montoIva2,
                                        impuesto3 = @montoIva3
                                    where auto=@id";
                        var i = cnn.Database.ExecuteSqlCommand(_sql, 
                            p1, p2, p3, p4, p5, p6, p7, p8, p9, p10,
                            p11, p12, p13, p14, p15, p16, p17, p18, idDoc);
                        if (i == 0) 
                        {
                            throw new Exception("DOCUMENTO NO PUDO SER ACTUALIZADO");
                        }
                        ts.Complete();
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
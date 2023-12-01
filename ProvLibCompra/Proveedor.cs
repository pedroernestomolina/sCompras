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
    
    public partial class Provider: ILibCompras.IProvider
    {
        public DtoLib.ResultadoLista<DtoLibCompra.Proveedor.Lista.Resumen> 
            Proveedor_GetLista(DtoLibCompra.Proveedor.Lista.Filtro filtro)
        {
            var rt = new DtoLib.ResultadoLista<DtoLibCompra.Proveedor.Lista.Resumen>();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql = @"select p.auto, p.codigo, p.razon_social as nombreRazonSocial, p.ci_rif as ciRif, 
                        p.dir_fiscal as dirFiscal, p.telefono, p.contacto as nombreContacto, p.estatus , 
                        g.nombre as nombreGrupo, e.nombre as nombreEstado, p.fecha_alta as fechaAlta, 
                        p.fecha_ult_compra as fechaUltCompra, p.fecha_baja as fechaBaja 
                        FROM proveedores as p 
                        join proveedores_grupo as g on p.auto_grupo=g.auto 
                        join sistema_estados as e on p.auto_estado=e.auto 
                        where 1=1 ";

                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();

                    var valor = "";
                    if (filtro.cadena != "")
                    {
                        if (filtro.MetodoBusqueda == DtoLibCompra.Proveedor.Enumerados.EnumMetodoBusqueda.Codigo)
                        {
                            var cad = filtro.cadena.Trim().ToUpper();
                            if (cad.Substring(0, 1) == "*")
                            {
                                cad = cad.Substring(1);
                                sql += " and p.codigo like @p";
                                valor = "%" + cad + "%";
                            }
                            else
                            {
                                sql += " and p.codigo like @p";
                                valor = cad + "%";
                            }
                        }
                        if (filtro.MetodoBusqueda == DtoLibCompra.Proveedor.Enumerados.EnumMetodoBusqueda.Nombre )
                        {
                            var cad = filtro.cadena.Trim().ToUpper();
                            if (cad.Substring(0, 1) == "*")
                            {
                                cad = cad.Substring(1);
                                sql += " and p.razon_social like @p";
                                valor = "%" + cad + "%";
                            }
                            else
                            {
                                sql += " and p.razon_social like @p";
                                valor = cad + "%";
                            }
                        }
                        if (filtro.MetodoBusqueda == DtoLibCompra.Proveedor.Enumerados.EnumMetodoBusqueda.CiRif )
                        {
                            var cad = filtro.cadena.Trim().ToUpper();
                            if (cad.Substring(0, 1) == "*")
                            {
                                cad = cad.Substring(1);
                                sql += " and p.ci_rif like @p";
                                valor = "%" + cad + "%";
                            }
                            else
                            {
                                sql += " and p.ci_rif like @p";
                                valor = cad + "%";
                            }
                        }
                        p1.ParameterName = "@p";
                        p1.Value = valor;
                    }

                    if (filtro.autoGrupo != "")
                    {
                        sql += " and p.auto_grupo=@autoGrupo ";
                        p2.ParameterName = "@autoGrupo";
                        p2.Value = filtro.autoGrupo;
                    }
                    if (filtro.autoEstado != "")
                    {
                        sql += " and p.auto_estado=@autoEstado ";
                        p3.ParameterName = "@autoEstado";
                        p3.Value = filtro.autoEstado;
                    }
                    if (filtro.estatus != DtoLibCompra.Proveedor.Enumerados.EnumEstatus.SnDefinir)
                    {
                        var f = "Activo";
                        if (filtro.estatus == DtoLibCompra.Proveedor.Enumerados.EnumEstatus.Inactivo)
                            f = "Inactivo";
                        sql += " and p.estatus=@estatus ";
                        p4.ParameterName = "@estatus";
                        p4.Value = f;
                    }
                    var list = cnn.Database.SqlQuery<DtoLibCompra.Proveedor.Lista.Resumen>(sql, p1, p2, p3, p4).ToList();
                    rt.Lista = list;
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
        public DtoLib.ResultadoEntidad <DtoLibCompra.Proveedor.Data.Ficha> 
            Proveedor_GetFicha(string autoPrv)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCompra.Proveedor.Data.Ficha>();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql = @"select 
                                    prv.auto as autoId,
                                    prv.auto_estado as autoEstado,
                                    prv.auto_grupo as autoGrupo,
                                    prv.ci_rif as ciRif,
                                    prv.codigo as codigo,
                                    prv.dir_fiscal as direccionFiscal,
                                    prv.razon_social as nombreRazonSocial,
                                    prv.contacto as nombreContacto,
                                    prv.telefono as telefono,
                                    prv.codigo_postal as codigoPostal,
                                    prv.denominacion_fiscal as denominacionFiscal,
                                    prv.email as email,
                                    prv.pais as pais,
                                    prv.retencion_iva as retIva,
                                    prv.website as website,
                                    prv.fecha_alta as fechaAlta,
                                    prv.fecha_ult_compra as fechaUltCompra,
                                    prv.fecha_baja as fechaBaja,
                                    prv.estatus as estatus,
                                    prv.codigo_xml_islr as codXmlIslr,
                                    prv.desc_xml_islr as descXmlIslr,
                                    grp.nombre as nombreGrupo,
                                    edo.nombre as nombreEstado
                                from proveedores as prv
                                join proveedores_grupo as grp on grp.auto=prv.auto_grupo
                                join sistema_estados as edo on edo.auto=prv.auto_estado
                                where prv.auto=@idPrv";
                    var p0= new MySql.Data.MySqlClient.MySqlParameter("@idPrv",autoPrv);
                    var _ent = cnn.Database.SqlQuery<DtoLibCompra.Proveedor.Data.Ficha>(_sql, p0).FirstOrDefault();
                    if (_ent == null)
                    {
                        result.Mensaje = "PROVEEDOR NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    //
                    result.Entidad = _ent;
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
        public DtoLib.ResultadoAuto 
            Proveedor_AgregarFicha(DtoLibCompra.Proveedor.Agregar.Ficha ficha)
        {
            var rt = new DtoLib.ResultadoAuto();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        var fechaNula = new DateTime(2000, 1, 1);
                        //
                        var sql = "update sistema_contadores set a_proveedores=a_proveedores+1";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            rt.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        var aPrv = cnn.Database.SqlQuery<int>("select a_proveedores from sistema_contadores").FirstOrDefault();
                        var autoPrv = aPrv.ToString().Trim().PadLeft(10, '0');
                        //
                        sql = @"INSERT INTO proveedores (
                                        `auto` ,
                                        `codigo` ,
                                        `nombre` ,
                                        `ci_rif` ,
                                        `razon_social` ,
                                        `auto_grupo` ,
                                        `dir_fiscal` ,
                                        `contacto` ,
                                        `telefono` ,
                                        `email` ,
                                        `website` ,
                                        `pais` ,
                                        `denominacion_fiscal` ,
                                        `auto_estado` ,
                                        `codigo_postal` ,
                                        `retencion_iva` ,
                                        `retencion_islr` ,
                                        `fecha_alta` ,
                                        `fecha_baja` ,
                                        `fecha_ult_pago` ,
                                        `fecha_ult_compra` ,
                                        `anticipos` ,
                                        `debitos` ,
                                        `creditos` ,
                                        `saldo` ,
                                        `disponible` ,
                                        `memo` ,
                                        `advertencia` ,
                                        `estatus` ,
                                        `auto_codigo_cobrar` ,
                                        `auto_codigo_ingresos` ,
                                        `auto_codigo_anticipos` ,
                                        `beneficiario` ,
                                        `rif` ,
                                        `ctabanco` ,
                                        `nj` ,
                                        `codigo_xml_islr` ,
                                        `desc_xml_islr`)
                                    VALUES (
                                        @auto ,
                                        @codigo ,
                                        @nombre ,
                                        @ci_rif ,
                                        @razon_social ,
                                        @auto_grupo ,
                                        @dir_fiscal ,
                                        @contacto ,
                                        @telefono ,
                                        @email ,
                                        @website ,
                                        @pais ,
                                        @denominacion_fiscal ,
                                        @auto_estado ,
                                        @codigo_postal ,
                                        @retencion_iva ,
                                        @retencion_islr ,
                                        @fecha_alta ,
                                        @fecha_baja ,
                                        @fecha_ult_pago ,
                                        @fecha_ult_compra ,
                                        0 ,
                                        0 ,
                                        0 ,
                                        0 ,
                                        0 ,
                                        '' ,
                                        '' ,
                                        'Activo' ,
                                        '0000000001',
                                        '0000000001',
                                        '0000000001',
                                        '' ,
                                        '' ,
                                        '' ,
                                        '' ,
                                        @codigo_xml_islr ,
                                        @desc_xml_islr)";
                        //
                        var p0 = new MySql.Data.MySqlClient.MySqlParameter("@auto", autoPrv);
                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@codigo", ficha.codigo);
                        var p2 = new MySql.Data.MySqlClient.MySqlParameter("@nombre", ficha.nombre);
                        var p3 = new MySql.Data.MySqlClient.MySqlParameter("@ci_rif", ficha.ciRif);
                        var p4 = new MySql.Data.MySqlClient.MySqlParameter("@razon_social", ficha.razonSocial);
                        var p5 = new MySql.Data.MySqlClient.MySqlParameter("@auto_grupo", ficha.idGrupo);
                        var p6 = new MySql.Data.MySqlClient.MySqlParameter("@dir_fiscal", ficha.dirFiscal);
                        var p7 = new MySql.Data.MySqlClient.MySqlParameter("@contacto", ficha.contacto);
                        var p8 = new MySql.Data.MySqlClient.MySqlParameter("@telefono", ficha.telefono);
                        var p9 = new MySql.Data.MySqlClient.MySqlParameter("@email", ficha.email);
                        //
                        var p10 = new MySql.Data.MySqlClient.MySqlParameter("@website", ficha.webSite);
                        var p11 = new MySql.Data.MySqlClient.MySqlParameter("@pais", ficha.pais);
                        var p12 = new MySql.Data.MySqlClient.MySqlParameter("@denominacion_fiscal", ficha.denFiscal);
                        var p13 = new MySql.Data.MySqlClient.MySqlParameter("@auto_estado", ficha.idEstado);
                        var p14 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_postal", ficha.codPostal);
                        var p15 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_iva", ficha.retIva);
                        var p16 = new MySql.Data.MySqlClient.MySqlParameter("@retencion_islr", ficha.retISLR);
                        var p17 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_alta", fechaSistema);
                        var p18 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_baja", fechaNula);
                        var p19 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_ult_pago", fechaNula);
                        //
                        var p20 = new MySql.Data.MySqlClient.MySqlParameter("@fecha_ult_compra",fechaNula);
                        var p21 = new MySql.Data.MySqlClient.MySqlParameter("@codigo_xml_islr",ficha.codXmlIslr);
                        var p22 = new MySql.Data.MySqlClient.MySqlParameter("@desc_xml_islr", ficha.descXmlIslr);
                        //
                        var r0 = cnn.Database.ExecuteSqlCommand(sql,
                                        p0, p1, p2, p3, p4, p5, p6, p7, p8, p9,
                                        p10, p11, p12, p13, p14, p15, p16, p17, p18, p19,
                                        p20, p21, p22);
                        cnn.SaveChanges();
                        if (r0==0)
                        {
                            throw new Exception("PROBLEMA AL REGISTRAR PROVEEDOR EN TABLA [ PROVEEDORES ]");
                        }
                        //
                        ts.Complete();
                        rt.Auto = autoPrv;
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
            return rt;
        }
        public DtoLib.Resultado 
            Proveedor_AgregarFicha_Validar(DtoLibCompra.Proveedor.Agregar.FichaValidar ficha)
        {
            var rt = new DtoLib.Resultado();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    if (ficha.codigo.Trim() != "")
                    {
                        var entPrv = cnn.proveedores.FirstOrDefault(f => f.codigo.Trim().ToUpper() == ficha.codigo);
                        if (entPrv != null)
                        {
                            rt.Mensaje = "[ CODIGO ] PROVEEDOR YA REGISTRADO";
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                            return rt;
                        };
                    }
                    if (ficha.razonSocial.Trim() != "")
                    {
                        var entPrv = cnn.proveedores.FirstOrDefault(f => f.razon_social.Trim().ToUpper() == ficha.razonSocial);
                        if (entPrv != null)
                        {
                            rt.Mensaje = "[ RAZON SOCIAL ] PROVEEDOR YA REGISTRADO";
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                            return rt;
                        };
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
            Proveedor_EditarFicha(DtoLibCompra.Proveedor.Editar.Ficha ficha)
        {
            var rt = new DtoLib.ResultadoAuto();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var entPrv = cnn.proveedores.Find(ficha.autoPrv);
                        if (entPrv == null)
                        {
                            rt.Mensaje = "[ ID ] PROVEEDOR NO ENCONTRADO";
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        entPrv.auto_estado = ficha.idEstado;
                        entPrv.auto_grupo = ficha.idGrupo;
                        entPrv.ci_rif = ficha.ciRif;
                        entPrv.codigo = ficha.codigo;
                        entPrv.codigo_postal = ficha.codPostal;
                        entPrv.contacto = ficha.contacto;
                        entPrv.denominacion_fiscal = ficha.denFiscal;
                        entPrv.dir_fiscal = ficha.dirFiscal;
                        entPrv.email = ficha.email;
                        entPrv.pais = ficha.pais;
                        entPrv.razon_social = ficha.razonSocial;
                        entPrv.retencion_iva = ficha.retIva;
                        entPrv.telefono = ficha.telefono;
                        entPrv.website = ficha.webSite;
                        cnn.SaveChanges();
                        //
                        var p0 = new MySql.Data.MySqlClient.MySqlParameter("@idPrv", ficha.autoPrv);
                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@codXmlIslr", ficha.codXmlIslr);
                        var p2 = new MySql.Data.MySqlClient.MySqlParameter("@descXmlIslr", ficha.descXmlIslr);
                        var sql = @"update proveedores set 
                                        codigo_xml_islr=@codXmlIslr,
                                        desc_xml_islr=@descXmlIslr
                                    where auto=@idPrv";
                        var r2 = cnn.Database.ExecuteSqlCommand(sql, p0, p1, p2);
                        if (r2 == 0) 
                        {
                            throw new Exception("PROBLEMA AL ACTUALIZAR FICHA PROVEEDOR");
                        }
                        cnn.SaveChanges();
                        //
                        ts.Complete();
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
            return rt;
        }
        public DtoLib.Resultado 
            Proveedor_EditarFicha_Validar(DtoLibCompra.Proveedor.Editar.FichaValidar ficha)
        {
            var rt = new DtoLib.Resultado();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var ent = cnn.proveedores.Find(ficha.autoId);
                    if (ent == null) 
                    {
                        rt.Mensaje = "[ ID ] PROVEEDOR NO ENCONTRADO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    if (ent.estatus.Trim().ToUpper() != "ACTIVO") 
                    {
                        rt.Mensaje = "PROVEEDOR EN ESTADO INACTIVO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    if (ficha.codigo.Trim() != "")
                    {
                        var entPrv = cnn.proveedores.FirstOrDefault(f => f.codigo.Trim().ToUpper() == ficha.codigo && f.auto != ficha.autoId);
                        if (entPrv != null)
                        {
                            rt.Mensaje = "[ CODIGO ] PROVEEDOR YA REGISTRADO";
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                            return rt;
                        };
                    }
                    if (ficha.razonSocial.Trim() != "")
                    {
                        var entPrv = cnn.proveedores.FirstOrDefault(f => f.razon_social.Trim().ToUpper() == ficha.razonSocial && f.auto != ficha.autoId);
                        if (entPrv != null)
                        {
                            rt.Mensaje = "[ RAZON SOCIAL ] PROVEEDOR YA REGISTRADO";
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                            return rt;
                        };
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

        public DtoLib.ResultadoLista<DtoLibCompra.Proveedor.Documento.Ficha> 
            Proveedor_Documento_GetLista(DtoLibCompra.Proveedor.Documento.Filtro filtro)
        {
            var rt = new DtoLib.ResultadoLista<DtoLibCompra.Proveedor.Documento.Ficha>();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql_1 = "SELECT c.fecha, c.documento, c.control as controlNro, c.total as monto, c.monto_divisa as montoDivisa, c.factor_cambio as tasaDivisa, " +
                        "c.estatus_anulado as estatus, c.tipo as codTipoDoc, c.serie, c.signo, c.documento_nombre as nombreTipoDoc  ";
                    var sql_2 = " FROM compras as c";
                    var sql_3 = " where c.auto_proveedor=@p1 and c.fecha>=@p2 and c.fecha<=@p3 ";
                    var sql_4 = "";

                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();

                    p1.ParameterName = "@p1";
                    p1.Value = filtro.autoProv;
                    p2.ParameterName = "@p2";
                    p2.Value = filtro.desde;
                    p3.ParameterName = "@p3";
                    p3.Value = filtro.hasta;

                    switch (filtro.tipoDoc)
                    { 
                        case DtoLibCompra.Proveedor.Documento.Enumerados.enumTipoDoc.Factura:
                            sql_3 += "and c.tipo='01' ";
                            break;
                        case DtoLibCompra.Proveedor.Documento.Enumerados.enumTipoDoc.NotaDebito:
                            sql_3 += "and c.tipo='02' ";
                            break;
                        case DtoLibCompra.Proveedor.Documento.Enumerados.enumTipoDoc.NotaCRedito:
                            sql_3 += "and c.tipo='03' ";
                            break;
                        case DtoLibCompra.Proveedor.Documento.Enumerados.enumTipoDoc.OrdenCompra:
                            sql_3 += "and c.tipo='04' ";
                            break;
                    }

                    var sql = sql_1 + sql_2 + sql_3 + sql_4;
                    var list = cnn.Database.SqlQuery<DtoLibCompra.Proveedor.Documento.Ficha>(sql, p1, p2, p3, p4).ToList();
                    rt.Lista = list;
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

        public DtoLib.ResultadoLista<DtoLibCompra.Proveedor.Articulos.Ficha> Proveedor_CompraArticulos_GetLista(DtoLibCompra.Proveedor.Articulos.Filtro filtro)
        {
            var rt = new DtoLib.ResultadoLista<DtoLibCompra.Proveedor.Articulos.Ficha>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql_1 = "SELECT p.codigo as codigoPrd, p.nombre as nombrePrd, c.fecha, c.documento, "+
                        "cd.cantidad, cd.cantidad_und as cantUnd, cd.empaque, cd.estatus_anulado as estatus, "+
                        "cd.contenido_empaque as contenidoEmp, c.tipo as codTipoDoc, c.serie, c.factor_cambio as tasaCambio, "+
                        "cd.costo_und as costoUnd, c.signo, cd.costo_compra as costo, c.documento_nombre as nombreTipoDoc ";

                    var sql_2 = " FROM compras_detalle as cd "+
                        " join productos as p on cd.auto_producto=p.auto "+
                        " join compras as c on cd.auto_documento=c.auto ";

                    var sql_3 = " where c.auto_proveedor=@p1 and c.fecha>=@p2 and c.fecha<=@p3 ";
                    var sql_4 = "";

                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();

                    p1.ParameterName = "@p1";
                    p1.Value = filtro.autoProv;
                    p2.ParameterName = "@p2";
                    p2.Value = filtro.desde;
                    p3.ParameterName = "@p3";
                    p3.Value = filtro.hasta;

                    var sql = sql_1 + sql_2 + sql_3 + sql_4;
                    var list = cnn.Database.SqlQuery<DtoLibCompra.Proveedor.Articulos.Ficha>(sql, p1, p2, p3, p4).ToList();
                    rt.Lista = list;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return rt;
        }

        public DtoLib.Resultado Proveedor_Activar(DtoLibCompra.Proveedor.ActivarInactivar.Ficha ficha)
        {
            var rt = new DtoLib.Resultado();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        var fechaNula = new DateTime(2000, 1, 1);

                        var entPrv = cnn.proveedores.Find(ficha.id);
                        if (entPrv == null)
                        {
                            rt.Mensaje = "[ ID ] PROVEEDOR NO ENCONTRADO";
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        if (entPrv.estatus.Trim().ToUpper() == "ACTIVO")
                        {
                            rt.Mensaje = "PROVEEDOR YA ACTIVO";
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                            return rt;
                        }

                        entPrv.estatus="Activo";
                        entPrv.fecha_baja = fechaNula;
                        cnn.SaveChanges();
                        ts.Complete();
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

        public DtoLib.Resultado Proveedor_Inactivar(DtoLibCompra.Proveedor.ActivarInactivar.Ficha ficha)
        {
            var rt = new DtoLib.Resultado();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        var fechaNula = new DateTime(2000, 1, 1);

                        var entPrv = cnn.proveedores.Find(ficha.id);
                        if (entPrv == null)
                        {
                            rt.Mensaje = "[ ID ] PROVEEDOR NO ENCONTRADO";
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                            return rt;
                        }
                        if (entPrv.estatus.Trim().ToUpper() == "INACTIVO")
                        {
                            rt.Mensaje = "PROVEEDOR YA INACTIVO";
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                            return rt;
                        }

                        entPrv.estatus = "Inactivo";
                        entPrv.fecha_baja = fechaSistema.Date;
                        cnn.SaveChanges();
                        ts.Complete();
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
    }
}
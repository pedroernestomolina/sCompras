using LibEntityCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCompra
{
    public partial class Provider: ILibCompras.IProvider
    {
        public DtoLib.ResultadoLista<DtoLibCompra.Producto.Lista.Resumen> 
            Producto_GetLista(DtoLibCompra.Producto.Lista.Filtro filtro)
        {
            var rt = new DtoLib.ResultadoLista<DtoLibCompra.Producto.Lista.Resumen>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql_1 = "select p.auto as autoPrd, p.codigo as codigoPrd, p.nombre as descripcionPrd, p.modelo as modeloPrd, "+
                        "p.referencia as rferenciaPrd, p.categoria as categoriaPrd, p.origen as origenPrd, p.tasa as tasaIvaPrd, "+
                        "p.estatus as estatus, p.estatus_divisa as estatusDivisa,p.contenido_compras as contenidoEmpaquePrd, "+
                        "pm.nombre as empaqueCompraPrd, ed.nombre as nombreDepartamento, pg.nombre as nombreGrupo, "+
                        "pmarca.nombre as nombreMarca,etasa.nombre as tasaIvaDescripcion ";

                    var sql_2 = "from productos as p " +
                        "join empresa_departamentos as ed on p.auto_departamento=ed.auto " +
                        "join productos_grupo as pg on p.auto_grupo=pg.auto " +
                        "join productos_medida as pm on p.auto_empaque_compra=pm.auto " +
                        "join productos_marca as pmarca on p.auto_marca=pmarca.auto " +
                        "join empresa_tasas as etasa on p.auto_tasa=etasa.auto ";

                    var sql_3 =" where 1=1 ";

                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p5 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p6 = new MySql.Data.MySqlClient.MySqlParameter();

                    var valor = "";
                    if (filtro.cadena != "")
                    {
                        if (filtro.MetodoBusqueda == DtoLibCompra.Producto.Enumerados.EnumMetodoBusqueda.Codigo)
                        {
                            var cad = filtro.cadena.Trim().ToUpper();
                            if (cad.Substring(0, 1) == "*")
                            {
                                cad = cad.Substring(1);
                                sql_3 += " and p.codigo like @p";
                                valor = "%" + cad + "%";
                            }
                            else
                            {
                                sql_3 += " and p.codigo like @p";
                                valor = cad + "%";
                            }
                        }
                        if (filtro.MetodoBusqueda == DtoLibCompra.Producto.Enumerados.EnumMetodoBusqueda.Nombre)
                        {
                            var cad = filtro.cadena.Trim().ToUpper();
                            if (cad.Substring(0, 1) == "*")
                            {
                                cad = cad.Substring(1);
                                sql_3 += " and p.nombre like @p";
                                valor = "%" + cad + "%";
                            }
                            else
                            {
                                sql_3 += " and p.nombre like @p";
                                valor = cad + "%";
                            }
                        }
                        if (filtro.MetodoBusqueda == DtoLibCompra.Producto.Enumerados.EnumMetodoBusqueda.Referencia)
                        {
                            var cad = filtro.cadena.Trim().ToUpper();
                            if (cad.Substring(0, 1) == "*")
                            {
                                cad = cad.Substring(1);
                                sql_3 += " and p.referencia like @p";
                                valor = "%" + cad + "%";
                            }
                            else
                            {
                                sql_3 += " and p.referencia like @p";
                                valor = cad + "%";
                            }
                        }
                        if (filtro.MetodoBusqueda == DtoLibCompra.Producto.Enumerados.EnumMetodoBusqueda.CodBarra)
                        {
                            sql_2 += " join productos_alterno as alt on alt.auto_producto = p.auto and alt.codigo_alterno=@p ";
                            valor = filtro.cadena;
                        }

                        p1.ParameterName = "@p";
                        p1.Value = valor;
                    }
                    if (filtro.autoDeposito != "")
                    {
                        sql_2 += " join productos_deposito as pDeposito on pDeposito.auto_producto = p.auto and pDeposito.auto_deposito= @autoDeposito ";
                        p6.ParameterName = "@autoDeposito";
                        p6.Value = filtro.autoDeposito;
                    }
                    if (filtro.autoDepartamento != "")
                    {
                        sql_3 += " and p.auto_departamento=@autoDepartamento ";
                        p3.ParameterName = "@autoDepartamento";
                        p3.Value = filtro.autoDepartamento;
                    }
                    if (filtro.autoGrupo != "")
                    {
                        sql_3 += " and p.auto_grupo=@autoGrupo ";
                        p4.ParameterName = "@autoGrupo";
                        p4.Value = filtro.autoGrupo;
                    }
                    if (filtro.autoMarca != "")
                    {
                        sql_3 += " and p.auto_marca=@autoMarca ";
                        p5.ParameterName = "@autoMarca";
                        p5.Value = filtro.autoMarca;
                    }
                    if (filtro.autoProveedor != "")
                    {
                        sql_2 += "join productos_proveedor as pprov on p.auto=pprov.auto_producto ";
                        sql_3 +=" and pprov.auto_proveedor=@autoProveedor ";
                        p2.ParameterName = "@@autoProveedor";
                        p2.Value = filtro.autoProveedor;
                    }
                    var sql = sql_1 + sql_2 + sql_3;
                    var list = cnn.Database.SqlQuery<DtoLibCompra.Producto.Lista.Resumen>(sql, p1, p2, p3, p4, p5, p6).ToList();
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
        public DtoLib.ResultadoEntidad<DtoLibCompra.Producto.Data.Ficha> 
            Producto_GetFicha(string autoPrd)
        {
            var rt = new DtoLib.ResultadoEntidad<DtoLibCompra.Producto.Data.Ficha>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var entPrd = cnn.productos.Find(autoPrd);
                    if (entPrd == null) 
                    {
                        rt.Mensaje = "PRODUCTO NO ENCONTRADO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }

                    var _empCompra = "";
                    var _decimales = "";
                    var entPrdMedCompra = cnn.productos_medida.Find(entPrd.auto_empaque_compra);
                    if (entPrdMedCompra != null) 
                    {
                        _empCompra=entPrdMedCompra.nombre;
                        _decimales=entPrdMedCompra.decimales;
                    }

                    var _depart = entPrd.empresa_departamentos.nombre;
                    var _codDepart = entPrd.empresa_departamentos.codigo;
                    var _grupo = entPrd.productos_grupo.nombre;
                    var _codGrupo = entPrd.productos_grupo.codigo;
                    var _marca = entPrd.productos_marca.nombre;
                    var _nombreTasaIva = entPrd.empresa_tasas.nombre;
                    var _tasaIva = entPrd.empresa_tasas.tasa;
                    var _origen = entPrd.origen;
                    var _categoria = entPrd.categoria;
                    var _estatus = DtoLibCompra.Producto.Enumerados.EnumEstatus.Activo;
                    if  (entPrd.estatus.Trim().ToUpper()=="INACTIVO") 
                         _estatus = DtoLibCompra.Producto.Enumerados.EnumEstatus.Inactivo;
                    var _admDivisa = DtoLibCompra.Producto.Enumerados.EnumAdministradorPorDivisa.Si;
                    if (entPrd.estatus_divisa.Trim().ToUpper() != "1" )
                        _admDivisa = DtoLibCompra.Producto.Enumerados.EnumAdministradorPorDivisa.No;

                    var id = new DtoLibCompra.Producto.Data.Ficha()
                    {
                        AdmPorDivisa = _admDivisa,
                        auto = entPrd.auto,
                        autoDepartamento = entPrd.auto_departamento,
                        autoGrupo = entPrd.auto_grupo,
                        autoMarca = entPrd.auto_marca,
                        autoTasa = entPrd.auto_tasa,
                        autoSubGrupo=entPrd.auto_subgrupo,
                        categoria = _categoria,
                        codigo = entPrd.codigo,
                        codigoDepartamento = _codDepart,
                        codigoGrupo = _codGrupo,
                        contenidoCompra = entPrd.contenido_compras,
                        departamento = _depart,
                        descripcion = entPrd.nombre,
                        empaqueCompra = _empCompra,
                        estatus = _estatus,
                        grupo = _grupo,
                        marca = _marca,
                        modelo = entPrd.modelo,
                        nombre = entPrd.nombre_corto,
                        nombreTasaIva = _nombreTasaIva,
                        origen = _origen,
                        referencia = entPrd.referencia,
                        tasaIva = _tasaIva,
                        fechaUltCambio = entPrd.fecha_cambio,
                        decimales = _decimales,
                        costo = entPrd.costo,
                        costoDivisa = entPrd.divisa,
                    };
                    rt.Entidad = id;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DtoLib.ResultadoEntidad<string> 
            Producto_GetCodigoRefProveedor(DtoLibCompra.Producto.CodigoRefProveedor.Filtro filtro)
        {
            var rt = new DtoLib.ResultadoEntidad<string>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var entPrdPrv = cnn.productos_proveedor.FirstOrDefault(f=>f.auto_producto==filtro.autoPrd && f.auto_proveedor==filtro.autoPrv);
                    if (entPrdPrv == null)
                    {
                        rt.Entidad = "";
                        return rt;
                    }
                    rt.Entidad = entPrdPrv.codigo_producto;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Producto.Utilidad.Ficha> 
            Producto_GetUtilidadPrecio(string auto)
        {
            var rt = new DtoLib.ResultadoEntidad<DtoLibCompra.Producto.Utilidad.Ficha>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var entPrd = cnn.productos.Find(auto);
                    if (entPrd == null)
                    {
                        rt.Mensaje = "PRODUCTO NO ENCONTRADO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }

                    var entPrdExt = cnn.productos_ext.Find(auto);
                    if (entPrdExt == null)
                    {
                        rt.Mensaje = "PRODUCTO EXT NO ENCONTRADO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }

                    var nr = new DtoLibCompra.Producto.Utilidad.Ficha()
                    {
                        auto = entPrd.auto,
                        admDivisa = entPrd.estatus_divisa.Trim().ToUpper() == "1" ? true : false,
                        contenido_1 = entPrd.contenido_1,
                        contenido_2 = entPrd.contenido_2,
                        contenido_3 = entPrd.contenido_3,
                        contenido_4 = entPrd.contenido_4,
                        contenido_5 = entPrd.contenido_pto,
                        tasaIva = entPrd.empresa_tasas.tasa,
                        utilidad_1 = entPrd.utilidad_1,
                        utilidad_2 = entPrd.utilidad_2,
                        utilidad_3 = entPrd.utilidad_3,
                        utilidad_4 = entPrd.utilidad_4,
                        utilidad_5 = entPrd.utilidad_pto,
                        precio_1 = entPrd.precio_1,
                        precio_2 = entPrd.precio_2,
                        precio_3 = entPrd.precio_3,
                        precio_4 = entPrd.precio_4,
                        precio_5 = entPrd.precio_pto,
                        //
                        contenido_may_1 = entPrdExt.contenido_may_1,
                        contenido_may_2 = entPrdExt.contenido_may_2,
                        utilidad_may_1 = entPrdExt.utilidad_may_1,
                        utilidad_may_2 = entPrdExt.utilidad_may_2,
                        precio_may_1 = entPrdExt.precio_may_1,
                        precio_may_2 = entPrdExt.precio_may_2,
                    };
                    rt.Entidad = nr;
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
            Producto_VerificaDepositoAsignado(DtoLibCompra.Producto.VerificarDepositoAsignado.Ficha ficha)
        {
            var rt = new DtoLib.Resultado();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var entPrdDeposito = cnn.productos_deposito.FirstOrDefault(f=>f.auto_producto==ficha.autoPrd && f.auto_deposito==ficha.autoDeposito);
                    if (entPrdDeposito == null)
                    {
                        rt.Mensaje = "DEPOSITO NO ASIGNADO AL PRODUCTO";
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
        public DtoLib.ResultadoEntidad<DtoLibCompra.Producto.Precio.Capturar.Ficha> 
            Producto_Precio_GetCapturar_ById(string idPrd)
        {
            var rt = new DtoLib.ResultadoEntidad<DtoLibCompra.Producto.Precio.Capturar.Ficha>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql_1 = @"SELECT 
                                    p.auto_precio_1 as idEmp1_1, 
                                    p.auto_precio_2 as idEmp1_2, 
                                    p.auto_precio_3 as idEmp1_3,  
                                    p.auto_precio_4 as idEmp1_4, 
                                    p.auto_precio_pto as idEmp1_5,
                                    p.contenido_1 as contEmp1_1, 
                                    p.contenido_2 as contEmp1_2, 
                                    p.contenido_3 as contEmp1_3, 
                                    p.contenido_4 as contEmp1_4,  
                                    p.contenido_pto as contEmp1_5,  
                                    p.utilidad_1 as utEmp1_1,
                                    p.utilidad_2 as utEmp1_2,
                                    p.utilidad_3 as utEmp1_3,
                                    p.utilidad_4 as utEmp1_4,
                                    p.utilidad_pto as utEmp1_5,
                                    p.precio_1 as pnEmp1_1,
                                    p.precio_2 as pnEmp1_2,
                                    p.precio_3 as pnEmp1_3,
                                    p.precio_4 as pnEmp1_4,
                                    p.precio_pto as pnEmp1_5,
                                    p.pdf_1 as pfdEmp1_1,
                                    p.pdf_2 as pfdEmp1_2,
                                    p.pdf_3 as pfdEmp1_3,
                                    p.pdf_4 as pfdEmp1_4,
                                    p.pdf_pto as pfdEmp1_5,

                                    pExt.auto_precio_may_1 as idEmp2_1, 
                                    pExt.auto_precio_may_2 as idEmp2_2, 
                                    pExt.auto_precio_may_3 as idEmp2_3, 
                                    pExt.auto_precio_may_4 as idEmp2_4, 
                                    pExt.contenido_may_1 as contEmp2_1, 
                                    pExt.contenido_may_2 as contEmp2_2, 
                                    pExt.contenido_may_3 as contEmp2_3, 
                                    pExt.cont_may_4 as contEmp2_4, 
                                    pExt.utilidad_may_1 as utEmp2_1,
                                    pExt.utilidad_may_2 as utEmp2_2,
                                    pExt.utilidad_may_3 as utEmp2_3,
                                    pExt.utilidad_may_4 as utEmp2_4,
                                    pExt.precio_may_1 as pnEmp2_1,
                                    pExt.precio_may_2 as pnEmp2_2,
                                    pExt.precio_may_3 as pnEmp2_3,
                                    pExt.precio_may_4 as pnEmp2_4,
                                    pExt.pdmf_1 as pfdEmp2_1,
                                    pExt.pdmf_2 as pfdEmp2_2,
                                    pExt.pdmf_3 as pfdEmp2_3,
                                    pExt.pdmf_4 as pfdEmp2_4,
        
                                    pExt.auto_precio_dsp_1 as idEmp3_1, 
                                    pExt.auto_precio_dsp_2 as idEmp3_2, 
                                    pExt.auto_precio_dsp_3 as idEmp3_3, 
                                    pExt.auto_precio_dsp_4 as idEmp3_4, 
                                    pExt.cont_dsp_1 as contEmp3_1, 
                                    pExt.cont_dsp_2 as contEmp3_2, 
                                    pExt.cont_dsp_3 as contEmp3_3, 
                                    pExt.cont_dsp_4 as contEmp3_4, 
                                    pExt.utilidad_dsp_1 as utEmp3_1,
                                    pExt.utilidad_dsp_2 as utEmp3_2,
                                    pExt.utilidad_dsp_3 as utEmp3_3,
                                    pExt.utilidad_dsp_4 as utEmp3_4,
                                    pExt.precio_dsp_1 as pnEmp3_1,
                                    pExt.precio_dsp_2 as pnEmp3_2,
                                    pExt.precio_dsp_3 as pnEmp3_3,
                                    pExt.precio_dsp_4 as pnEmp3_4,
                                    pExt.pdivisafull_dsp_1 as pfdEmp3_1,
                                    pExt.pdivisafull_dsp_2 as pfdEmp3_2,
                                    pExt.pdivisafull_dsp_3 as pfdEmp3_3,
                                    pExt.pdivisafull_dsp_4 as pfdEmp3_4

                                    FROM productos as p
                                    join productos_ext as pExt on pExt.auto_producto=p.auto
                                    where p.auto=@id";
                    var sql = sql_1;
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@id", idPrd);
                    var _ent = cnn.Database.SqlQuery<DtoLibCompra.Producto.Precio.Capturar.Ficha>(sql, p1).FirstOrDefault();
                    if (_ent == null) 
                    {
                        rt.Mensaje = "PRODUCTO [ ID ] NO ENCONTRADO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    rt.Entidad = _ent;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DtoLib.ResultadoLista<DtoLibCompra.Producto.EmpaqueMedida.Lista.Ficha> 
            Producto_EmpaqueMedida_GetLista()
        {
            var rt = new DtoLib.ResultadoLista<DtoLibCompra.Producto.EmpaqueMedida.Lista.Ficha>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql_1 = @"select 
                                        auto, nombre  
                                    from productos_medida 
                                    where 1=1";
                    var lst = cnn.Database.SqlQuery<DtoLibCompra.Producto.EmpaqueMedida.Lista.Ficha>(sql_1).ToList();
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
        //
        public DtoLib.ResultadoEntidad<DtoLibCompra.Producto.EmpaqueCompra.Ficha> 
            Producto_EmpaquesCompra_GetFicha(string idPrd)
        {
            var rt = new DtoLib.ResultadoEntidad<DtoLibCompra.Producto.EmpaqueCompra.Ficha>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql_1 = @"SELECT 
                                    p.nombre as descPrd, p.auto as autoPrd,
                                    auto_empaque_compra as autoEmpCompra, contenido_compras as contEmpCompra, 
                                    pMed_1.nombre as descEmpCompra, pMed_1.decimales as decEmpCompra,
                                    pExt.auto_emp_inv_1 as autoEmpInv, pExt.cont_emp_inv_1 as contEmpInv, 
                                    pMed_2.nombre as descEmpInv, pMed_2.decimales as decEmpInv
                                from productos as p
                                join productos_medida as pMed_1 on pMed_1.auto=auto_empaque_compra
                                join productos_ext as pExt on pExt.auto_producto=p.auto
                                join productos_medida as pMed_2 on pMed_2.auto=pExt.auto_emp_inv_1
                                where p.auto=@autoPrd";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@autoPrd", idPrd);
                    var ent = cnn.Database.SqlQuery<DtoLibCompra.Producto.EmpaqueCompra.Ficha>(sql_1, p1).FirstOrDefault();
                    if (ent == null) 
                    {
                        rt.Mensaje = "[ ID ] PRODUCTO NO ENCONTRADO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    rt.Entidad = ent;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Producto.ActualizarPrecioVenta.ObtenerData.Ficha> 
            Producto_ActualizarPreciosVenta_ObtenerData_GetById(string idPrd)
        {
            var rt = new DtoLib.ResultadoEntidad<DtoLibCompra.Producto.ActualizarPrecioVenta.ObtenerData.Ficha>();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql_1 = @"SELECT
                                        prdExt.auto_emp_venta_tipo_1 as idEmpVta1,
                                        prdExt.auto_emp_venta_tipo_2 as idEmpVta2,
                                        prdExt.auto_emp_venta_tipo_3 as idEmpVta3,
                                        prdExt.cont_emp_venta_tipo_1 as contEmpVta1,
                                        prdExt.cont_emp_venta_tipo_2 as contEmpVta2,
                                        prdExt.cont_emp_venta_tipo_3 as contEmpVta3,
                                        medEmp1.nombre as descEmpVta1,
                                        medEmp2.nombre as descEmpVta2,
                                        medEmp3.nombre as descEmpVta3,

                                        prd.utilidad_1 as utEmpVta_1_Precio_1,
                                        prd.utilidad_2 as utEmpVta_1_Precio_2,
                                        prd.utilidad_3 as utEmpVta_1_Precio_3,
                                        prd.utilidad_4 as utEmpVta_1_Precio_4,
                                        prd.utilidad_pto as utEmpVta_1_Precio_5,
                                        prd.precio_1 as pnEmpVta_1_Precio_1,
                                        prd.precio_2 as pnEmpVta_1_Precio_2,
                                        prd.precio_3 as pnEmpVta_1_Precio_3,
                                        prd.precio_4 as pnEmpVta_1_Precio_4,
                                        prd.precio_pto as pnEmpVta_1_Precio_5,
                                        prd.pdf_1 as pfdEmpVta_1_Precio_1,
                                        prd.pdf_2 as pfdEmpVta_1_Precio_2,
                                        prd.pdf_3 as pfdEmpVta_1_Precio_3,
                                        prd.pdf_4 as pfdEmpVta_1_Precio_4,
                                        prd.pdf_pto as pfdEmpVta_1_Precio_5,
  
                                        prdExt.utilidad_may_1 as utEmpVta_2_Precio_1,
                                        prdExt.utilidad_may_2 as utEmpVta_2_Precio_2,
                                        prdExt.utilidad_may_3 as utEmpVta_2_Precio_3,
                                        prdExt.utilidad_may_4 as utEmpVta_2_Precio_4,
                                        prdExt.precio_may_1 as pnEmpVta_2_Precio_1,
                                        prdExt.precio_may_2 as pnEmpVta_2_Precio_2,
                                        prdExt.precio_may_3 as pnEmpVta_2_Precio_3,
                                        prdExt.precio_may_4 as pnEmpVta_2_Precio_4,
                                        prdExt.pdmf_1 as pfdEmpVta_2_Precio_1,
                                        prdExt.pdmf_2 as pfdEmpVta_2_Precio_2,
                                        prdExt.pdmf_3 as pfdEmpVta_2_Precio_3,
                                        prdExt.pdmf_4 as pfdEmpVta_2_Precio_4,
  
                                        prdExt.utilidad_dsp_1 as utEmpVta_3_Precio_1,
                                        prdExt.utilidad_dsp_2 as utEmpVta_3_Precio_2,
                                        prdExt.utilidad_dsp_3 as utEmpVta_3_Precio_3,
                                        prdExt.utilidad_dsp_4 as utEmpVta_3_Precio_4,
                                        prdExt.precio_dsp_1 as pnEmpVta_3_Precio_1,
                                        prdExt.precio_dsp_2 as pnEmpVta_3_Precio_2,
                                        prdExt.precio_dsp_3 as pnEmpVta_3_Precio_3,
                                        prdExt.precio_dsp_4 as pnEmpVta_3_Precio_4,
                                        prdExt.pdivisafull_dsp_1 as pfdEmpVta_3_Precio_1,
                                        prdExt.pdivisafull_dsp_2 as pfdEmpVta_3_Precio_2,
                                        prdExt.pdivisafull_dsp_3 as pfdEmpVta_3_Precio_3,
                                        prdExt.pdivisafull_dsp_4 as pfdEmpVta_3_Precio_4
                                  FROM productos as prd
                                  join productos_ext as prdExt on prdExt.auto_producto=prd.auto
                                  join productos_medida as medEmp1 on medEmp1.auto= prdExt.auto_emp_venta_tipo_1
                                  join productos_medida as medEmp2 on medEmp2.auto= prdExt.auto_emp_venta_tipo_2
                                  join productos_medida as medEmp3 on medEmp3.auto= prdExt.auto_emp_venta_tipo_3
                                  where prd.auto=@id";
                    var sql = sql_1;
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@id", idPrd);
                    var _ent = cnn.Database.SqlQuery<DtoLibCompra.Producto.ActualizarPrecioVenta.ObtenerData.Ficha>(sql, p1).FirstOrDefault();
                    if (_ent == null)
                    {
                        rt.Mensaje = "PRODUCTO NO ENCONTRADO";
                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        return rt;
                    }
                    rt.Entidad = _ent;
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
    }
}
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
        public DtoLib.ResultadoLista<DtoLibCompra.Documento.Lista.Resumen>
            Compra_DocumentoGetLista(DtoLibCompra.Documento.Lista.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibCompra.Documento.Lista.Resumen>();
            var _lst = new List<DtoLibCompra.Documento.Lista.Resumen>();

            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p5 = new MySql.Data.MySqlClient.MySqlParameter();
                    var sql_1 = @"SELECT 
                                    c.auto, 
                                    c.fecha as fechaEmision, 
                                    c.tipo, 
                                    c.documento, 
                                    c.signo, 
                                    c.control, 
                                    c.documento_nombre as tipoDocNombre, 
                                    c.fecha_registro as fechaRegistro, 
                                    c.codigo_sucursal as codigoSuc, 
                                    c.razon_social as provNombre, 
                                    c.ci_rif as provCiRif, 
                                    c.total as monto, 
                                    c.situacion, 
                                    c.monto_Divisa as montoDivisa, 
                                    c.estatus_anulado as estatusAnulado, 
                                    c.aplica,
                                    empSuc.nombre as nomSucursal,
                                    c.tipo_documento_compra as estatusDocCompraMercGasto ";
                    var sql_2 = @" FROM compras as c 
                                        join empresa_sucursal as empSuc on empSuc.codigo=c.codigo_sucursal ";
                    var sql_3 = @" where 1=1 ";
                    p1.ParameterName = "@fDesde";
                    p1.Value = filtro.Desde;
                    sql_3 += " and fecha>=@fDesde ";
                    p2.ParameterName = "@fHasta";
                    p2.Value = filtro.Hasta;
                    sql_3 += " and fecha<=@fHasta ";
                    if (filtro.CodigoSuc != "")
                    {
                        p3.ParameterName = "@suc";
                        p3.Value = filtro.CodigoSuc;
                        sql_3 += " and codigo_sucursal=@suc";
                    }
                    if (filtro.TipoDocumento != DtoLibCompra.Enumerados.enumTipoDocumento.SinDefinir)
                    {
                        var xtipo = "";
                        switch (filtro.TipoDocumento)
                        {
                            case DtoLibCompra.Enumerados.enumTipoDocumento.Factura:
                                xtipo = "01";
                                break;
                            case DtoLibCompra.Enumerados.enumTipoDocumento.NotaDebito:
                                xtipo = "02";
                                break;
                            case DtoLibCompra.Enumerados.enumTipoDocumento.NotaCredito:
                                xtipo = "03";
                                break;
                            case DtoLibCompra.Enumerados.enumTipoDocumento.OrdenCompra:
                                xtipo = "04";
                                break;
                            case DtoLibCompra.Enumerados.enumTipoDocumento.Recepcion:
                                xtipo = "05";
                                break;
                        }
                        p4.ParameterName = "@tipo";
                        p4.Value = xtipo;
                        sql_3 += " and tipo=@tipo";
                    }
                    if (filtro.idProveedor != "")
                    {
                        p5.ParameterName = "@autoProv";
                        p5.Value = filtro.idProveedor;
                        sql_3 += " and auto_proveedor =@autoProv";
                    }
                    var sql = sql_1 + sql_2 + sql_3;
                    var lst = cnn.Database.SqlQuery<DtoLibCompra.Documento.Lista.Resumen>(sql, p1, p2, p3, p4, p5).ToList();
                    result.Lista = lst;
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

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
        public DtoLib.ResultadoLista<DtoLibCompra.Documento.ListaRemision.Ficha>
            Compra_DocumentoGetListaRemision(DtoLibCompra.Documento.ListaRemision.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibCompra.Documento.ListaRemision.Ficha>();
            var _lst = new List<DtoLibCompra.Documento.ListaRemision.Ficha>();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var sql_1 = @"SELECT 
                                    auto, 
                                    fecha as fechaEmision, 
                                    documento as docNro, 
                                    control, 
                                    total, 
                                    documento_nombre as docNombre, 
                                    tipo as docTipo, 
                                    monto_divisa as montoDivisa ";
                    var sql_2 = " FROM compras ";
                    var sql_3 = @" Where (tipo='01' or tipo='02' or tipo='FF') and 
                                        estatus_anulado='0' and 
                                        tipo_documento_compra='1' ";
                    if (filtro.autoProveedor != "")
                    {
                        sql_3 += "and auto_proveedor=@autoProv ";
                        p1.ParameterName = "@autoProv";
                        p1.Value = filtro.autoProveedor;
                    }
                    var sql = sql_1 + sql_2 + sql_3;
                    _lst = cnn.Database.SqlQuery<DtoLibCompra.Documento.ListaRemision.Ficha>(sql, p1).ToList();
                }
                //
                result.Lista = _lst;
                return result;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
                return result;
            }
        }
    }
}
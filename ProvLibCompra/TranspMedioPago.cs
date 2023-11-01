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
        public DtoLib.ResultadoLista<DtoLibTransporte.MedioPago.Lista.Ficha> 
            Transporte_MedioPago_GetLista()
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.MedioPago.Lista.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql_1 = @"select 
                                        auto as id, 
                                        codigo, 
                                        nombre 
                                from empresa_medios 
                                where estatus_pago='1'";
                    var sql = sql_1;
                    var list = cnn.Database.SqlQuery<DtoLibTransporte.MedioPago.Lista.Ficha>(sql).ToList();
                    result.Lista = list;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.MedioPago.Entidad.Ficha> 
            Transporte_MedioPago_GetFichaById(string id)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.MedioPago.Entidad.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql_1 = @"select 
                                        auto as id, 
                                        codigo, 
                                        nombre 
                                from empresa_medios 
                                where auto=@id";
                    var sql = sql_1;
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.MedioPago.Entidad.Ficha>(sql).FirstOrDefault();
                    if (_ent == null)
                    {
                        throw new Exception("[ ID ] MEDIO DE PAGO NO ENCONTRADO");
                    }
                    result.Entidad = _ent;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
    }
}
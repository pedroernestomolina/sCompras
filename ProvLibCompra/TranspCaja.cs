using LibEntityCompra;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCompra
{
    public partial class Provider: ILibCompras.IProvider
    {
        public DtoLib.ResultadoLista<DtoLibTransporte.Caja.Lista.Ficha> 
            Transporte_Caja_GetLista()
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Caja.Lista.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"select 
                                        id as id,
                                        codigo,
                                        descripcion,
                                        saldo_inicial as saldoInicial,
                                        monto_ingreso-monto_ingreso_anulado as montoPorIngresos,
                                        monto_egreso-monto_egreso_anulado as montoPorEgresos,
                                        0 as montoPorAnulaciones,
                                        estatus_anulado as estatusAnulado,
                                        es_divisa as esDivisa
                                    FROM transp_caja";
                    var _sql = _sql_1;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Caja.Lista.Ficha>(_sql).ToList();
                    result.Lista = _lst;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Caja.Crud.Entidad.Ficha>
            Transporte_Caja_GetById(int idCja)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Caja.Crud.Entidad.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql_1 = @"SELECT 
                                        id as id,
                                        codigo,
                                        descripcion as descripcion,
                                        fecha_registro as fechaRegistro,
                                        saldo_inicial as saldoInicial,
                                        monto_ingreso as montoIngreso,
                                        monto_egreso as montoEgreso,
                                        monto_ingreso_anulado as montoIngresoAnulado,
                                        monto_egreso_anulado as montoEgresoAnulado,
                                        es_divisa as esDivisa,
                                        estatus_anulado as estatusAnulado
                                    FROM transp_caja
                                    WHERE id=@idCja";
                    var _sql_2 = @"";
                    var _sql = _sql_1 + _sql_2;
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idCja", idCja);
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Caja.Crud.Entidad.Ficha>(_sql, p1).FirstOrDefault();
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
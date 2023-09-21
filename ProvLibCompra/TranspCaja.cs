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
                                        descripcion,
                                        saldo_inicial as saldoInicial,
                                        monto_ingreso as montoPorIngresos,
                                        monto_egreso as montoPorEgresos,
                                        monto_anulado as montoPorAnulaciones,
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
    }
}
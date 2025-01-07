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
        public DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Compras.LibroSeniat.Ficha>
            Transporte_Reportes_Compras_LibroSeniat_GetLista(DtoLibTransporte.Reportes.Compras.LibroSeniat.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Reportes.Compras.LibroSeniat.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                    var _sql_1 = @"SELECT 
                                        fecha as fechaEmision,
                                        ci_rif as prvCiRif,
                                        razon_social as prvRazonSocial,
                                        documento as numDoc,
                                        control as numControl,
                                        tipo as codTipoDoc,
                                        aplica as numDocAplica,
                                        total-igtf_monto as totalDoc,
                                        exento as montoExento,
                                        base1 as montoBase1,
                                        impuesto1 as montoIva1,
                                        tasa1 as tasa1,
                                        base2 as montoBase2,
                                        impuesto2 as montoIva2,
                                        tasa2 as tasa2,
                                        base3 as montoBase3,
                                        impuesto3 as montoIva3,
                                        tasa3 as tasa3,
                                        comprobante_retencion as comprobanteRetencion,
                                        maquina_fiscal as maquinaFiscal,
                                        tasa_retencion_iva as tasaRet,
                                        retencion_iva as montoRet,
                                        fecha_retencion as fechaRet
                                FROM compras";
                    var _sql_2 = @" WHERE 1=1 and estatus_anulado='0' and tipo in ('01','02','03') 
                                    and estatus_fiscal='1' ";
                    if (filtro.Desde.HasValue)
                    {
                        _sql_2 += " and fecha_registro>=@desde ";
                        p1.ParameterName = "@desde";
                        p1.Value = filtro.Desde;
                    }
                    if (filtro.Hasta.HasValue)
                    {
                        _sql_2 += " and fecha_registro<=@hasta ";
                        p2.ParameterName = "@hasta";
                        p2.Value = filtro.Hasta;
                    }
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Reportes.Compras.LibroSeniat.Ficha>(_sql, p1, p2).ToList();
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

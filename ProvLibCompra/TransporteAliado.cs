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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.Entidad.Ficha> 
            Transporte_Aliado_GetFichaById(int id)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.Entidad.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@id", id);
                    var _sql = @"select 
                                    id,
                                    codigo,
                                    ciRif,
                                    nombreRazonSocial,
                                    dirFiscal,
                                    personaContacto,
                                    monto_anticipos_mon_divisa as montoAnticiposDiv,
                                    monto_anticipos_anulado_mon_divisa as montoAnticiposAnuladoDiv,
                                    monto_anticipos_ret_mon_divisa as montoAnticipoRetDiv,
                                    monto_anticipos_ret_anulado_mon_div as montoAnticipoRetAnuladoDiv 
                                from transp_aliado  
                                where id=@id";
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Aliado.Entidad.Ficha>(_sql, p1).FirstOrDefault();
                    if (_ent == null)
                    {
                        throw new Exception("ALIADO NO ENCONTRADO");
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
        public DtoLib.ResultadoLista<DtoLibTransporte.Aliado.Entidad.Ficha> 
            Transporte_Aliado_GetLista()
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Aliado.Entidad.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var _sql_1 = @"select 
                                    id,
                                    codigo,
                                    ciRif,
                                    nombreRazonSocial
                                from transp_aliado ";
                    var _sql_2 = @" where 1=1 ";
                    var _sql = _sql_1 + _sql_2;
                    var _lst = cnn.Database.SqlQuery<DtoLibTransporte.Aliado.Entidad.Ficha>(_sql, p1).ToList();
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

        public DtoLib.ResultadoLista<DtoLibTransporte.Aliado.Pendiente.Ficha> 
            Transporte_Aliado_Pediente_GetLista()
        {
            var result = new DtoLib.ResultadoLista<DtoLibTransporte.Aliado.Pendiente.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql = @"select 
                            aliado.id as aliadoId,
                            aliado.codigo aliadoCod,
                            aliado.cirif as aliadoCiRif,
                            aliado.nombreRazonSocial as aliadoNombre,
                            sum(aliDoc.importe_divisa) as importeDiv,
                            sum(aliDoc.acumulado_divisa) as acumuladoDiv,
                            aliado.monto_anticipos_mon_divisa montoAnticipoDiv,
                            aliado.monto_anticipos_anulado_mon_divisa montoAnticipoAnuladoDiv,
                            aliado.monto_anticipos_ret_mon_divisa as montoAnticipoRetDiv,
                            aliado.monto_anticipos_ret_anulado_mon_div as montoAnticipoRetAnuladoDiv,
                            count(*) as cntDoc
                        from transp_aliado as aliado
                        join transp_aliado_doc as aliDoc on aliDoc.id_aliado=aliado.id and aliDoc.estatus_anulado<>'1'
                        group by aliado.id, aliado.codigo, aliado.ciRif, aliado.nombreRazonSocial";
                    var _lst= cnn.Database.SqlQuery<DtoLibTransporte.Aliado.Pendiente.Ficha>(_sql).ToList();
                    result.Lista = _lst;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result.Mensaje = Helpers.MYSQL_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.Pendiente.Ficha> 
            Transporte_Aliado_Pediente_GetByIdAliado(int idAliado)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Aliado.Pendiente.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql = @"select 
                            aliado.id as aliadoId,
                            aliado.codigo aliadoCod,
                            aliado.cirif as aliadoCiRif,
                            aliado.nombreRazonSocial as aliadoNombre,
                            sum(aliDoc.importe_divisa) as importeDiv,
                            sum(aliDoc.acumulado_divisa) as acumuladoDiv,
                            aliado.monto_anticipos_mon_divisa montoAnticipoDiv,
                            aliado.monto_anticipos_ret_mon_divisa montoAnticipoRetDiv,
                            aliado.monto_anticipos_anulado_mon_divisa montoAnticipoAnuladoDiv,
                            aliado.monto_anticipos_ret_anulado_mon_div montoAnticipoRetAnuladoDiv,
                            count(*) as cntDoc
                        from transp_aliado as aliado
                        join transp_aliado_doc as aliDoc on aliDoc.id_aliado=aliado.id and aliDoc.estatus_anulado<>'1'
                        where aliado.id=@idAliado
                        group by aliado.id, aliado.codigo, aliado.ciRif, aliado.nombreRazonSocial";
                    var p0 = new MySql.Data.MySqlClient.MySqlParameter("@idAliado", idAliado);
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Aliado.Pendiente.Ficha>(_sql, p0).FirstOrDefault();
                    if (_ent == null) 
                    {
                        result.Mensaje = "";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    result.Entidad = _ent;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result.Mensaje = Helpers.MYSQL_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
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
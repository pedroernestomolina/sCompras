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
        public DtoLib.ResultadoEntidad<DtoLibCompra.Documento.GetData.AplicarRetencion.Ficha> 
            Compra_GetData_AplicarRetencion(string idDocCompra)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCompra.Documento.GetData.AplicarRetencion.Ficha>();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1= new MySql.Data.MySqlClient.MySqlParameter("@idDoc",idDocCompra);
                    var _sql = @"select 
                                    auto as idDocCompra,
                                    auto_cxp as idDocCxP,
                                    ano_relacion as anoRelacion,
                                    cargosp as cargoPorct,
                                    control as controlNro,
                                    descuento1p as descuentoPorct,
                                    dias as diasCredito,
                                    documento_nombre as documentoNombre,
                                    documento as documentoNro,
                                    serie as documentoSerie,
                                    tipo as documentoTipo,
                                    estacion as equipoEstacion,
                                    factor_cambio as factorCambio,
                                    fecha as fechaEmision,
                                    fecha_registro as fechaRegistro,
                                    hora as horaRegistro,
                                    fecha_vencimiento as fechaVencimiento,
                                    mes_relacion as mesRelacion,
                                    base as montoBase,
                                    base1 as montoBase1,
                                    base2 as montoBase2,
                                    base3 as montoBase3,
                                    cargos as montoCargo,
                                    descuento1 as montoDescuento,
                                    monto_divisa as montoDivisa,
                                    exento as montoExento,
                                    impuesto as montoImpuesto,
                                    total as montoTotal,
                                    nota as notas,
                                    orden_compra as ordenCompraNro,
                                    auto_proveedor as provAuto,
                                    ci_rif as provCiRif,
                                    codigo_proveedor as provCodigo,
                                    dir_fiscal as provDirFiscal,
                                    razon_social as provNombre,
                                    telefono as provTelefono,
                                    renglones as renglones,
                                    signo as signo,
                                    subtotal_neto as subTotal,
                                    tasa1 as tasaIva1,
                                    tasa2 as tasaIva2,
                                    tasa3 as tasaIva3,
                                    codigo_usuario as usuarioCodigo,
                                    usuario as usuarioNombre,
                                    impuesto1 as montoIva1,
                                    impuesto2 as montoIva2,
                                    impuesto3 as montoIva3,
                                    codigo_sucursal as codigoSucursal,
                                    estatus_fiscal as estatusAplicaLibroSeniat,
                                    auto_sucursal as idSucursal,
                                    desc_sucursal as descSucursal,
                                    tipo_documento_compra as estatusMercanciaGasto
                                from compras
                                where auto=@idDoc ";
                    var ent = cnn.Database.SqlQuery<DtoLibCompra.Documento.GetData.AplicarRetencion.Ficha>(_sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("[ ID ] DOCUMENTO NO ENCONTRADO");
                    }
                    //
                    p1 = new MySql.Data.MySqlClient.MySqlParameter("@idDoc", idDocCompra);
                    _sql = @"select 
                                '1' 
                            from compras_retenciones_detalle 
                            where auto_documento=@idDoc and estatus_anulado='0' and tipo_retencion='07'";
                    var retIva = cnn.Database.SqlQuery<string>(_sql, p1).FirstOrDefault();
                    //
                    p1 = new MySql.Data.MySqlClient.MySqlParameter("@idDoc", idDocCompra);
                    _sql = @"select 
                                '1' 
                            from compras_retenciones_detalle 
                            where auto_documento=@idDoc and estatus_anulado='0' and tipo_retencion='08'";
                    var retIslr = cnn.Database.SqlQuery<string>(_sql, p1).FirstOrDefault();
                    //
                    ent.estatusAplicaRetIva = retIva;
                    ent.estatusAplicaRetIslr = retIslr;
                    result.Entidad = ent;
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
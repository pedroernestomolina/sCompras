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
        public DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Visualizar.Ficha>
            Compra_DocumentoVisualizar(string auto)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCompra.Documento.Visualizar.Ficha>();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var _sql = @"select 
                                    ano_relacion as anoRelacion,
                                    cargosp as cargoPort,
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
                                    aplica as aplica,
                                    estatus_anulado as EstatusDoc,
                                    auto as idDoc
                                from compras
                                where auto=@idDoc";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@idDoc", auto);
                    var entEncabezado = cnn.Database.SqlQuery<DtoLibCompra.Documento.Visualizar.Encabezado>(_sql, p1).FirstOrDefault();
                    if (entEncabezado == null)
                    {
                        throw new Exception("[ ID ] DOCUMENTO NO ENCONTRADO");
                    }
                    _sql = @"select 
                                cantidad as cntFactura,
                                contenido_empaque as contenido,
                                codigo_deposito as depositoCodigo,
                                deposito as depositoNombre,
                                descuento1p as dscto1p,
                                descuento2p as dscto2p,
                                descuento3p as dscto3p,
                                descuento1 as dscto1m,
                                descuento2 as dscto2m,
                                descuento3 as dscto3m,
                                total_neto as importe,
                                empaque as empaqueCompra,
                                codigo as prdCodigo,
                                nombre as prdNombre,
                                costo_bruto as precioFactura,
                                tasa as tasaIva
                            from compras_detalle
                            where auto_documento=@idDoc";
                    p1 = new MySql.Data.MySqlClient.MySqlParameter("@idDoc", auto);
                    var entDetalles = cnn.Database.SqlQuery<DtoLibCompra.Documento.Visualizar.Detalle>(_sql, p1).ToList();
                    result.Entidad = new DtoLibCompra.Documento.Visualizar.Ficha()
                    {
                        encabezado = entEncabezado,
                        detalles = entDetalles,
                    };
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
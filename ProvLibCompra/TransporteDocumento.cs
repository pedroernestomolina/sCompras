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
        public DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Entidad.Ficha> 
            Transporte_Documento_Entidad_CompraGrasto_GetById(string autoDoc)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibTransporte.Documento.Entidad.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql = @"select 
                                    auto as docAuto, 
                                    documento docNumero, 
                                    fecha as docFechaEmision, 
                                    fecha_vencimiento as docFechaVencimiento,  
                                    razon_social as prvNombre, 
                                    dir_fiscal as prvDirFiscal, 
                                    ci_rif as prvCiRif, 
                                    tipo as sistDocCodigo, 
                                    exento as montoExento, 
                                    base1 as montoBase1, 
                                    base2 as montoBase2, 
                                    base3 as montoBase3, 
                                    impuesto1 as montoIva1, 
                                    impuesto2 as montoIva2, 
                                    impuesto3 as montoIva3, 
                                    base as montoBase, 
                                    impuesto as montoImpuesto, 
                                    total as montoTotal, 
                                    tasa1 as tasaIva1, 
                                    tasa2 as tasaIva2, 
                                    tasa3 as tasaIva3, 
                                    nota as docNotas, 
                                    tasa_retencion_iva as tasaRetIva, 
                                    tasa_retencion_islr as tasaRetIslr, 
                                    retencion_iva as montoRetIva, 
                                    retencion_islr as totalRetIslr , 
                                    auto_proveedor as prvAuto, 
                                    codigo_proveedor as prvCodigo, 
                                    mes_relacion as docMesRelacion , 
                                    control as docControl, 
                                    fecha_registro as docFechaRegistro, 
                                    orden_compra as docNumOrdenCompra, 
                                    dias as docDiasCredito, 
                                    estatus_anulado as docEstatus, 
                                    subtotal_neto as subTotalNeto, 
                                    telefono as prvTelefono, 
                                    factor_cambio as factorCambio, 
                                    condicion_pago as docCondicionPago, 
                                    usuario as usuNombre, 
                                    codigo_usuario as usuCodigo, 
                                    codigo_sucursal as sucCodigo, 
                                    hora as docHoraRegistro, 
                                    monto_divisa as montoDivisa, 
                                    estacion as equipoEstacion, 
                                    renglones as docCntRenglones, 
                                    ano_relacion as docAnoRelacion, 
                                    auto_usuario as usuAuto, 
                                    signo as sistDocSigno, 
                                    serie as sistDocSiglas, 
                                    tipo_remision as docAplicaCodDocRef, 
                                    documento_remision as docAplicaNumRef, 
                                    documento_nombre as sistDocNombre, 
                                    subtotal_impuesto as subTotalImpuesto,
                                    subtotal as subTotal, 
                                    auto_cxp as docAutoCxp, 
                                    neto as montoNeto, 
                                    documento_tipo as sistDocModulo, 
                                    estatus_fiscal as docEstatusFiscal, 
                                    id_compras_concepto as conceptoAuto, 
                                    desc_compras_concepto as conceptoDesc, 
                                    codigo_compras_concepto as conceptoCodigo, 
                                    auto_sucursal as sucAuto, 
                                    desc_sucursal as sucDesc, 
                                    igtf_monto as montoIGTF, 
                                    tipo_documento_compra as docTipoDocCompra, 
                                    sustraendo_ret_islr as sustraendoRetIslr , 
                                    monto_ret_islr as montoRetIslr, 
                                    auto_sistema_documento as sistDocAuto 
                                from compras 
                                where auto=@autoDoc";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@autoDoc", autoDoc);
                    var _ent = cnn.Database.SqlQuery<DtoLibTransporte.Documento.Entidad.Documento>(sql, p1).FirstOrDefault();
                    if (_ent == null)
                    {
                        throw new Exception("DOCUMENTO NO ENCONTRADO");
                    }
                    result.Entidad = new DtoLibTransporte.Documento.Entidad.Ficha()
                    {
                        documento = _ent,
                    };
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result.Mensaje = Helpers.MYSQL_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (DbUpdateException ex)
            {
                result.Mensaje = Helpers.ENTITY_VerificaError(ex);
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
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibEntityCompra
{
    using System;
    using System.Collections.Generic;
    
    public partial class compras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public compras()
        {
            this.compras_detalle = new HashSet<compras_detalle>();
        }
    
        public string auto { get; set; }
        public string documento { get; set; }
        public System.DateTime fecha { get; set; }
        public System.DateTime fecha_vencimiento { get; set; }
        public string razon_social { get; set; }
        public string dir_fiscal { get; set; }
        public string ci_rif { get; set; }
        public string tipo { get; set; }
        public decimal exento { get; set; }
        public decimal base1 { get; set; }
        public decimal base2 { get; set; }
        public decimal base3 { get; set; }
        public decimal impuesto1 { get; set; }
        public decimal impuesto2 { get; set; }
        public decimal impuesto3 { get; set; }
        public decimal @base { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }
        public decimal tasa1 { get; set; }
        public decimal tasa2 { get; set; }
        public decimal tasa3 { get; set; }
        public string nota { get; set; }
        public decimal tasa_retencion_iva { get; set; }
        public decimal tasa_retencion_islr { get; set; }
        public decimal retencion_iva { get; set; }
        public decimal retencion_islr { get; set; }
        public string auto_proveedor { get; set; }
        public string codigo_proveedor { get; set; }
        public string mes_relacion { get; set; }
        public string control { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public string orden_compra { get; set; }
        public int dias { get; set; }
        public decimal descuento1 { get; set; }
        public decimal descuento2 { get; set; }
        public decimal cargos { get; set; }
        public decimal descuento1p { get; set; }
        public decimal descuento2p { get; set; }
        public decimal cargosp { get; set; }
        public string columna { get; set; }
        public string estatus_anulado { get; set; }
        public string aplica { get; set; }
        public string comprobante_retencion { get; set; }
        public decimal subtotal_neto { get; set; }
        public string telefono { get; set; }
        public decimal factor_cambio { get; set; }
        public string condicion_pago { get; set; }
        public string usuario { get; set; }
        public string codigo_usuario { get; set; }
        public string codigo_sucursal { get; set; }
        public string hora { get; set; }
        public decimal monto_divisa { get; set; }
        public string estacion { get; set; }
        public int renglones { get; set; }
        public decimal saldo_pendiente { get; set; }
        public string ano_relacion { get; set; }
        public string comprobante_retencion_islr { get; set; }
        public int dias_validez { get; set; }
        public string auto_usuario { get; set; }
        public string situacion { get; set; }
        public int signo { get; set; }
        public string serie { get; set; }
        public string tarifa { get; set; }
        public string tipo_remision { get; set; }
        public string documento_remision { get; set; }
        public string auto_remision { get; set; }
        public string documento_nombre { get; set; }
        public decimal subtotal_impuesto { get; set; }
        public decimal subtotal { get; set; }
        public string auto_cxp { get; set; }
        public string tipo_proveedor { get; set; }
        public string planilla { get; set; }
        public string expediente { get; set; }
        public decimal anticipo_iva { get; set; }
        public decimal terceros_iva { get; set; }
        public decimal neto { get; set; }
        public decimal costo { get; set; }
        public decimal utilidad { get; set; }
        public decimal utilidadp { get; set; }
        public string documento_tipo { get; set; }
        public string denominacion_fiscal { get; set; }
        public string auto_concepto { get; set; }
        public System.DateTime fecha_retencion { get; set; }
        public string estatus_cierre_contable { get; set; }
        public string cierre_ftp { get; set; }
    
        public virtual proveedores proveedores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compras_detalle> compras_detalle { get; set; }
        public virtual usuarios usuarios { get; set; }
    }
}
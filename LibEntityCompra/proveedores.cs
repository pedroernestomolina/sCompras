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
    
    public partial class proveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proveedores()
        {
            this.productos_proveedor = new HashSet<productos_proveedor>();
            this.proveedores_agencias = new HashSet<proveedores_agencias>();
            this.compras_detalle = new HashSet<compras_detalle>();
            this.compras = new HashSet<compras>();
            this.cxp = new HashSet<cxp>();
        }
    
        public string auto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string ci_rif { get; set; }
        public string razon_social { get; set; }
        public string auto_grupo { get; set; }
        public string dir_fiscal { get; set; }
        public string contacto { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string pais { get; set; }
        public string denominacion_fiscal { get; set; }
        public string auto_estado { get; set; }
        public string codigo_postal { get; set; }
        public decimal retencion_iva { get; set; }
        public decimal retencion_islr { get; set; }
        public System.DateTime fecha_alta { get; set; }
        public System.DateTime fecha_baja { get; set; }
        public System.DateTime fecha_ult_pago { get; set; }
        public System.DateTime fecha_ult_compra { get; set; }
        public decimal anticipos { get; set; }
        public decimal debitos { get; set; }
        public decimal creditos { get; set; }
        public decimal saldo { get; set; }
        public decimal disponible { get; set; }
        public string memo { get; set; }
        public string advertencia { get; set; }
        public string estatus { get; set; }
        public string auto_codigo_cobrar { get; set; }
        public string auto_codigo_ingresos { get; set; }
        public string auto_codigo_anticipos { get; set; }
        public string beneficiario { get; set; }
        public string rif { get; set; }
        public string ctabanco { get; set; }
        public string nj { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productos_proveedor> productos_proveedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proveedores_agencias> proveedores_agencias { get; set; }
        public virtual proveedores_grupo proveedores_grupo { get; set; }
        public virtual sistema_estados sistema_estados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compras_detalle> compras_detalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compras> compras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cxp> cxp { get; set; }
    }
}

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
    
    public partial class empresa_depositos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empresa_depositos()
        {
            this.compras_detalle = new HashSet<compras_detalle>();
            this.productos_deposito = new HashSet<productos_deposito>();
            this.productos_kardex = new HashSet<productos_kardex>();
        }
    
        public string auto { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public string codigo_sucursal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compras_detalle> compras_detalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productos_deposito> productos_deposito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productos_kardex> productos_kardex { get; set; }
    }
}

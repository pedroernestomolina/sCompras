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
    
    public partial class empresa_grupo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empresa_grupo()
        {
            this.empresa_sucursal = new HashSet<empresa_sucursal>();
        }
    
        public string auto { get; set; }
        public string nombre { get; set; }
        public string idPrecio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empresa_sucursal> empresa_sucursal { get; set; }
    }
}

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
    
    public partial class proveedores_agencias
    {
        public string auto_proveedor { get; set; }
        public string auto_agencia { get; set; }
        public string cuenta { get; set; }
    
        public virtual proveedores proveedores { get; set; }
    }
}
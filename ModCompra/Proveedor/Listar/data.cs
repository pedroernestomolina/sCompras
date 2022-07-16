using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Proveedor.Listar
{
    
    public class data
    {

        public string auto { get; set; }
        public string rif { get; set; }
        public string nombre { get; set; }
        public bool IsActivo { get; set; }


        public data(OOB.LibCompra.Proveedor.Data.Ficha rg)
        {
            auto = rg.autoId;
            rif = rg.ciRif;
            nombre = rg.nombreRazonSocial;
            IsActivo = rg.identidad.estatus == OOB.LibCompra.Proveedor.Enumerados.EnumEstatus.Activo ? true : false;
        }

    }

}
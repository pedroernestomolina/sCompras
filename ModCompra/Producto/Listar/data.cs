using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Listar
{
    
    public class data
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public decimal tasaIva { get; set; }
        public bool isActivo { get; set; }


        public data(OOB.LibCompra.Producto.Data.Ficha rg)
        {
            auto = rg.auto;
            codigo = rg.codigo;
            nombre = rg.descripcion;
            tasaIva = rg.tasaIva;
            isActivo = rg.estatus == OOB.LibCompra.Producto.Enumerados.EnumEstatus.Activo ? true : false;
        }

    }

}
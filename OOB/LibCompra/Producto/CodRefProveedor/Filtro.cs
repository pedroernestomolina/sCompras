using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Producto.CodRefProveedor
{

    public class Filtro
    {

        public string autoPrd { get; set; }
        public string autoPrv { get; set; }


        public Filtro()
        {
            autoPrd = "";
            autoPrv = "";
        }

    }

}
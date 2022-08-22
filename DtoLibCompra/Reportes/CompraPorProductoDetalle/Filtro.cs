using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCompra.Reportes.CompraPorProductoDetalle
{
    
    public class Filtro: BaseFiltro
    {


        public Filtro()
        {
            autoProveedor = "";
            codSucursal = "";
            desde = DateTime.Now.Date;
            hasta = DateTime.Now.Date;
        }

    }

}
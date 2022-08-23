using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Reportes.CompraConCambioPrecios
{
    
    public class Filtro: BaseFiltro
    {

        public Filtro()
        {
            codSucursal = "";
            autoProveedor = "";
            desde = DateTime.Now.Date;
            hasta = DateTime.Now.Date;
        }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Reportes.CompraporDepartamento
{
    
    public class Filtro: BaseFiltro
    {

        public Filtro()
        {
            desde = DateTime.Now.Date;
            hasta = DateTime.Now.Date;
            codSucursal = "";
            autoProveedor = "";
        }
        
    }

}
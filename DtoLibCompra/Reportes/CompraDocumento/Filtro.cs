using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCompra.Reportes.CompraDocumento
{
    
    public class Filtro: BaseFiltro
    {

        public Enumerados.EnumEstatus estatus { get; set; }


        public Filtro()
        {
            autoProveedor = "";
            codSucursal = "";
            estatus = Enumerados.EnumEstatus.SinDefinir;
            desde = DateTime.Now.Date;
            hasta = DateTime.Now.Date;
        }

    }

}
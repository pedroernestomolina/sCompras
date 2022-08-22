using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Reportes.GeneralDocumentos
{
    
    public class Filtro: BaseFiltro
    {

        public Enumerados.EnumEstatus estatus { get; set; }


        public Filtro()
        {
            codSucursal = "";
            autoProveedor = "";
            estatus = Enumerados.EnumEstatus.SinDefinir;
            desde = DateTime.Now.Date;
            hasta = DateTime.Now.Date;
        }

    }

}
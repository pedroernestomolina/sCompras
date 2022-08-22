using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Reportes
{
    
    public abstract class  BaseFiltro
    {

        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public string codSucursal { get; set; }
        public string autoProveedor { get; set; }

    }

}